<script lang="ts">
	import Breadcrumb from '$lib/components/Breadcrumb.svelte';
	import DataTable from '$lib/components/DataTable.svelte';
	import DataTableCell from '$lib/components/DataTableCell.svelte';
	import DataTableRow from '$lib/components/DataTableRow.svelte';
	import DatePresenter from '$lib/components/DatePresenter.svelte';
	import LabeledDatePicker from '$lib/components/LabeledDatePicker.svelte';
	import { exportCsv, exportExcel } from '$lib/helpers/csv-helper';
	import type { EventDto } from '$lib/models/assyst-event.js';
	import type { ActionDto } from '$lib/models/event-action.js';

	import { onMount } from 'svelte';

	export let data;
	let dateFrom: Date = new Date();
	let dateTo: Date = new Date();
	let isLoading = false;
	let events: EventDto[] = [];
	let actions: ActionDto[] = [];
	let dataTable: DataTable;
	let usersToInclude = `206,917,916`;

	function exportToExcel() {
		let row =
			'<thead><tr><td>User</td><td>Email</td><td>Date</td><td>Incident</td><td>Task</td><td>Time (Minutes)</td></tr></thead>';
		let html = `${row}`;
		for (const action of actions) {
			let row = `<tr><td>${action.actionedBy?.name ?? 'N/A'}</td><td>${action.actionedBy?.emailAddress ?? 'N/A'}</td><td>${action.dateActioned}</td><td>${action.event?.formattedReference}</td><td><b>${action.actionType?.name} : </b><span>${action.richRemarks?.content}</span></td><td>${getServiceTimeMinutes(action)}</td></tr>`;
			html += row;
		}
		exportExcel(html, 'time-registration-report.xls');
	}

	function getServiceTimeMinutes(action: ActionDto) {
		if (action.serviceTime == null) {
			return 0;
		}
		action.serviceTime.value ??= 0;
		return action.serviceTime.value / 60000;
	}

	async function getTimeRegistrationActions(event: EventDto) {
		if (!event.actions) {
			return;
		}

		for (const action of event.actions) {
			if (!action.actionType?.shortCode?.includes('TIME REGISTRATION')) {
				continue;
			}
			action.richRemarks ??= {
				content: ''
			};
			action.richRemarks.content = `<div>Event Ref #${event.formattedReference}</div>${action.richRemarks.content}`;
			if (action.serviceTime && action.serviceTime.value && action.serviceTime.value > 0) {
				actions.push(action);
			}
		}
	}

	async function getEvents() {
		isLoading = true;
		actions = [];
		const url = `/api/assyst/GetActionsInRange?from=${dateFrom.toJSON()}&to=${dateTo.toJSON()}`;
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		if (response.ok) {
			actions = await response.json();
		}
		isLoading = false;
	}

	onMount(() => {
		let day = 1;
		let month = dateFrom.getMonth();
		let year = dateFrom.getFullYear();
		dateFrom = new Date(year, month, day, 0, 0, 0);
	});
</script>

<div class="p-2">
	<Breadcrumb currentLocation="Time Registration" paths={['reports']} />
	<DataTable
		bind:this={dataTable}
		isBusy={isLoading}
		allowAdd={false}
		on:refresh={getEvents}
		hasAdvancedSearch={true}
		popupMenuItems={[
			{
				id: 0,
				content: 'Export',
				action: exportToExcel,
				disabled: isLoading
			}
		]}
	>
		<div slot="advancedsearch" class="grid grid-cols-2 md:grid-cols-4 p-2 gap-2">
			<LabeledDatePicker bind:value={dateFrom} labelText="From" />
			<LabeledDatePicker bind:value={dateTo} labelText="To" />
		</div>
		<span slot="title"> Time Registration Report </span>
		<tr slot="header">
			<DataTableCell isHeader={true}>User</DataTableCell>
			<DataTableCell isHeader={true}>Date</DataTableCell>
			<DataTableCell isHeader={true}>Incident</DataTableCell>
			<DataTableCell isHeader={true}>Description</DataTableCell>
			<DataTableCell isHeader={true}>
				<span class="whitespace-nowrap"> Service Time(Minutes) </span>
			</DataTableCell>
		</tr>

		{#each actions as action (action.id)}
			<DataTableRow>
				<DataTableCell>
					<ul>
						<li>
							<span>{action.actionedBy?.name ?? 'N/A'}</span>
						</li>
						<li>
							<span>
								{action.actionedBy?.emailAddress ?? 'N/A'}
							</span>
						</li>
					</ul>
				</DataTableCell>
				<DataTableCell>
					{#if action.dateActioned}
						<DatePresenter date={action.dateActioned} />
					{/if}
				</DataTableCell>
				<DataTableCell>
					{action.event?.formattedReference}
				</DataTableCell>

				<DataTableCell>
					<div>
						<b>
							{action.actionType?.name}
						</b>
					</div>
					<div class="text-sm">
						{@html action.richRemarks?.content}
					</div>
				</DataTableCell>
				<DataTableCell>
					{getServiceTimeMinutes(action)}
				</DataTableCell>
			</DataTableRow>
		{/each}
	</DataTable>
</div>
