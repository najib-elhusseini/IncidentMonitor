<script lang="ts">
	import DataTable from '$lib/components/DataTable.svelte';
	import DataTableCell from '$lib/components/DataTableCell.svelte';
	import LabeledDropDownSaarch from '$lib/components/LabeledDropDownSaarch.svelte';
	import DataTableRow from '$lib/components/DataTableRow.svelte';
	import DatePresenter from '$lib/components/DatePresenter.svelte';
	import BooleanPresenter from '$lib/components/BooleanPresenter.svelte';
	import { getEventAction, getEventFormattedStatus, type EventDto } from '$lib/models/assyst-event';
	import { exportCsv } from '$lib/helpers/csv-helper.js';

	export let data;
	let departmentId = -1;
	let isLoading: boolean = false;
	let events: EventDto[] = [];
	let totalCount: number = 0;

	async function refreshData() {
		let params: string[] = [];
		if (departmentId !== -1) {
			params.push(`departmentId=${departmentId}`);
		}
		params.push('eventType=INCIDENT');
		params.push('eventStatus=1');
		params.push('$orderby=id:desc');

		let query = params.join('&');
		query = encodeURIComponent(query);
		const url = `/api/assyst/queryevents?searchQuery=${query}&additionalFields=customFields`;
		isLoading = true;

		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		if (response.ok) {
			const result = await response.json();
			totalCount = result.count;
			events = result.result;
		}

		isLoading = false;
	}

	function handleDepartmentChanged(event: CustomEvent) {
		let id = event.detail.item?.id ?? -1;
		departmentId = id;
		refreshData();
	}

	function getActionDate(
		event: EventDto,
		shortCode: 'FIRST FOLLOW UP' | 'SECOND FOLLOW UP' | 'THIRD FOLLOW UP'
	): string {
		const formatter = new Intl.DateTimeFormat(undefined, {
			dateStyle: 'long',
			timeStyle: 'short',
			timeZone: 'UTC'
		});
		let actions = getEventAction(event, shortCode);
		if (!actions) {
			return 'N/A';
		}
		if (actions.length === 0) {
			return 'N/A';
		}
		let date = actions[0].dateActioned;
		console.log(date);
		if (date && typeof date === 'string') {
			date = new Date(date);
			// console.log(date);
		}
		return formatter.format(date);
	}

	function exportCsvData() {
		const formatter = new Intl.DateTimeFormat(undefined, {
			dateStyle: 'long',
			timeStyle: 'short',
			timeZone: 'UTC'
		});

		const titles: string[] = [
			'Ref',
			'User Ref',
			'Customer Case Id',
			'Date Logged',
			'Affected User Name',
			'Affected User Email',
			'Assigned User',
			'Status',
			'Awaiting Vendor',
			'First Follow Up',
			'Second Follow Up',
			'Third Follow Up'
		];
		let rows: string[][] = [];
		rows.push(titles);
		for (const event of events) {
			let dateLogged = event.dateLogged;
			if (typeof dateLogged === 'string') {
				dateLogged = new Date(dateLogged);
			}
			const dateLoggedFormatted = formatter.format(dateLogged);
			let status = getEventFormattedStatus(event);

			const _dataRow: Array<string> = [
				event.formattedReference ?? '',
				event.userReference ?? 'N/A',
				event.customerCaseId ?? 'N/A',
				dateLoggedFormatted,
				event.affectedUserName ?? 'N/A',
				event.affectedUserEmail ?? 'N/A',
				event.assignedUser?.email ?? 'N/A',
				status,
				event.isAwaitingVendor ? 'TRUE' : 'FALSE',
				getActionDate(event, 'FIRST FOLLOW UP'),
				getActionDate(event, 'SECOND FOLLOW UP'),
				getActionDate(event, 'THIRD FOLLOW UP')
			];

			rows.push(_dataRow);
		}

		exportCsv(rows, 'follow_up_report');
	}
</script>

<DataTable
	allowAdd={false}
	hasAdvancedSearch={true}
	on:refresh={refreshData}
	isBusy={isLoading}
	popupMenuItems={[
		{
			id: 0,
			content: 'Export CSV',
			action: exportCsvData,
			disabled: events.length === 0
		}
	]}
>
	<span slot="title"> Follow Ups Report </span>
	<div slot="advancedsearch" class="grid grid-cols-1 md:grid-cols-3 xl:grid-cols-6 p-2 gap-2">
		<LabeledDropDownSaarch
			labelText="Departments"
			data={data.departments}
			labelKey="sectionName"
			dataKey="id"
			on:selectionchanged={handleDepartmentChanged}
		/>
	</div>

	<tr slot="header">
		<DataTableCell isHeader={true} width={75}>#</DataTableCell>
		<DataTableCell isHeader={true} width={100}>User Ref</DataTableCell>
		<DataTableCell isHeader={true}>Date Logged</DataTableCell>
		<DataTableCell isHeader={true}>Summary</DataTableCell>
		<DataTableCell isHeader={true}>Affected User</DataTableCell>
		<DataTableCell isHeader={true}>Assigned User</DataTableCell>
		<DataTableCell isHeader={true}>Status</DataTableCell>
		<DataTableCell isHeader={true} width={75}>
			<i class="bi bi-person-fill-dash" title="Awaiting vendor"></i>
		</DataTableCell>
	</tr>
	{#each events as event (event.id)}
		<DataTableRow>
			<DataTableCell>
				<span>
					{event.formattedReference}
				</span>
				<div class="text-xs text-slate-600">
					{event.id}
				</div>
			</DataTableCell>
			<DataTableCell>
				<span class="text-sm">
					{event.userReference}
				</span>
				{#if event.customerCaseId}
					<div class="text-sm">
						{event.customerCaseId}
					</div>
				{/if}
			</DataTableCell>
			<DataTableCell>
				{#if event.dateLogged}
					<DatePresenter date={event.dateLogged} />
				{/if}
			</DataTableCell>
			<DataTableCell>
				<div class="text-xs">
					{event.shortDescription}
				</div>
			</DataTableCell>
			<DataTableCell>
				<span>
					{event.affectedUserName}
				</span>
				{#if event.affectedUserEmail}
					<div class="text-sm">
						{event.affectedUserEmail}
					</div>
				{/if}
			</DataTableCell>
			<DataTableCell>
				{event.assignedUser?.name ?? 'N/A'}
			</DataTableCell>
			<DataTableCell>
				<span class="whitespace-nowrap">
					{getEventFormattedStatus(event)}
				</span>
			</DataTableCell>
			<DataTableCell>
				<BooleanPresenter value={event.isAwaitingVendor} />
			</DataTableCell>
		</DataTableRow>
	{/each}
</DataTable>
