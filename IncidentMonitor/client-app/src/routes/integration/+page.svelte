<script lang="ts">
	import Paginator from '$lib/components/Paginator.svelte';
	import Breadcrumb from '$lib/components/Breadcrumb.svelte';
	import DataTable from '$lib/components/DataTable.svelte';
	import DataTableCell from '$lib/components/DataTableCell.svelte';
	import DataTableRow from '$lib/components/DataTableRow.svelte';
	import Header from '$lib/components/Header.svelte';
	import LabeledSelect from '$lib/components/LabeledSelect.svelte';
	import type { EventDto } from '$lib/models/assyst-event';
	import { eventStatus } from '$lib/models/assyst.js';
	import { onMount } from 'svelte';
	import DataPaginator from '$lib/components/DataPaginator.svelte';
	import DatePresenter from '$lib/components/DatePresenter.svelte';
	import Button from '$lib/components/Button.svelte';
	import HyperLink from '$lib/components/HyperLink.svelte';
	import ModalDialog from '$lib/components/ModalDialog.svelte';
	import LabeledInput from '$lib/components/LabeledInput.svelte';
	import { fireSaveErrorToast, fireSuccessToast } from '$lib/swal_helper.js';
	import { casedata } from '$lib/data/cases.js';
	import { exportCsv } from '$lib/helpers/csv-helper.js';

	export let data;
	let departmenId: string = '';
	let isLoading = false;
	let searchQuery = '';
	let events: EventDto[] = [];
	let status: eventStatus = eventStatus.OPEN;
	let statuses: eventStatus[] = [eventStatus.OPEN, eventStatus.PENDING, eventStatus.CLOSED];
	let totalRowsCount = 0;
	let currentPage = 0;
	let rowsPerPage = 30;
	let isLoadingSnowCases = false;
	let modalDialog: ModalDialog;

	function buildSearchQuery() {
		let query = `departmentId=${departmenId}&eventType=INCIDENT&eventStatus=${status}&$orderby=id:desc`;

		return encodeURIComponent(query);
	}

	async function getEventsCount() {
		if (!departmenId) {
			return;
		}
		const query = buildSearchQuery();
		let url = `/api/assyst/getsearchcount?query=${query}`;
		isLoading = true;
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});

		if (response.ok) {
			let count: number | string = await response.text();
			count = Number(count);
			totalRowsCount = count;
		}
		isLoading = false;
	}

	async function getEvents() {
		if (!departmenId) {
			return;
		}
		let query = buildSearchQuery();
		query = query + `%26$skip=${currentPage * rowsPerPage}%26$top=${rowsPerPage}`;
		let url = `/api/assyst/searchevents?searchQuery=${query}`;
		isLoading = true;

		events = [];
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});

		if (response.ok) {
			events = await response.json();
		}
		isLoading = false;
	}

	function handleIndexChanged(event: CustomEvent) {
		const index = event.detail.index;
		currentPage = index;
		getEvents();
	}

	async function refreshEevnts() {
		currentPage = 0;

		await getEventsCount();
		await getEvents();
	}

	function handleSearch(event: CustomEvent) {
		const _query = event.detail.value as string;
		searchQuery = _query;
		refreshEevnts();
	}

	async function getCaseDetails() {
		
		const params = new URLSearchParams();
		isLoadingSnowCases = true;

		for (const event of events) {
			if (!event.userReference) {
				continue;
			}
			params.append('numbers', `${event.userReference}`);
		}
		const url = `/api/integrations/CarrixGetCaseDetails?` + params;

		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		if (response.ok) {
			const cases = await response.json();
			console.log(cases);
			for (const _case of cases) {
			}
		} else {
		}
		isLoadingSnowCases = false;
	}

	function showModalDialog() {
		modalDialog.openDialog();
	}

	function dismissDialog() {
		modalDialog.dismissDialog();
	}

	async function addIntegration(event: CustomEvent) {
		const url = '/api/integrations/createintegration';
		const body: FormData = event.detail;
		body.append('deprtmentId', `${47}`);
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			},
			body,
			method: 'POST'
		});
		if (response.ok) {
			fireSuccessToast('Ticket created');
			dismissDialog();
		} else {
			fireSaveErrorToast();
		}
	}

	onMount(() => {
		refreshEevnts();
	});
</script>

<div class="flex h-screen flex-col">
	<Header user={data.user} isLoading={false}></Header>
	<div class="p-2 overflow-y-scroll flex-grow">
		<DataTable
			hasAdvancedSearch={true}
			allowAdd={true}
			isBusy={isLoading}
			on:search={handleSearch}
			on:addnew={showModalDialog}
		>
			<div slot="title">Integrations</div>
			<div
				slot="advancedsearch"
				class="grid grid-cols-1 md:grid-cols-3 lg:grid-cols-4 p-2 gap-2 md:gap-3"
			>
				<LabeledSelect bind:value={departmenId} on:change={refreshEevnts}>
					<option value=""> ---Select Department--- </option>
					<option value="43" selected={departmenId === '43'}> Carrix </option>
					<option value="47"> Diamond Vogel </option>
					<option value="46"> DHC </option>
				</LabeledSelect>
				<LabeledSelect bind:value={status} on:change={refreshEevnts}>
					{#each statuses as stat (stat)}
						<option value={stat}>
							{stat}
						</option>
					{/each}
				</LabeledSelect>
				<Button on:click={getCaseDetails} disabled={isLoadingSnowCases}>Get Details</Button>
			</div>
			<tr slot="header">
				<DataTableCell isHeader={true}>#</DataTableCell>
				<DataTableCell isHeader={true}>Date</DataTableCell>
				<DataTableCell isHeader={true}>Affected User</DataTableCell>
				<DataTableCell isHeader={true}>Assigned User</DataTableCell>
				<DataTableCell isHeader={true}>User Reference</DataTableCell>
				<DataTableCell isHeader={true}>Description</DataTableCell>
			</tr>

			{#each events as event (event.id)}
				<DataTableRow>
					<DataTableCell>
						{#if event.userReference}
							<HyperLink target="_blank" href="/assyst/compare/{event.id}">
								{event.formattedReference}
							</HyperLink>
						{:else}
							<span class="text-blue-900">
								{event.formattedReference}
							</span>
						{/if}
						<div class="text-xs">
							{event.id}
						</div>
					</DataTableCell>
					<DataTableCell>
						{#if event.dateLogged}
							<DatePresenter date={event.dateLogged} />
						{/if}
					</DataTableCell>
					<DataTableCell>
						{event.affectedUserName}
					</DataTableCell>
					<DataTableCell>
						{event.assignedUser?.name ?? 'Not Assigned'}
					</DataTableCell>
					<DataTableCell>
						{event.userReference}
					</DataTableCell>
					<DataTableCell>
						<small>
							{event.shortDescription}
						</small>
					</DataTableCell>
				</DataTableRow>
			{/each}
		</DataTable>
	</div>

	<div class="border-t border-t-slate-400">
		<DataPaginator
			currentIndex={currentPage}
			resultsPerSearch={rowsPerPage}
			totalCount={totalRowsCount}
			on:indexchanged={handleIndexChanged}
		/>
	</div>
</div>

<ModalDialog bind:this={modalDialog} on:cancel={dismissDialog} on:submit={addIntegration}>
	<span slot="title"> Add integration </span>
	<div>
		<LabeledInput
			name="ticketId"
			label="Ticket Id"
			placeholder="Enter third party ticket id"
			required={true}
			id="input-ticket-id"
		></LabeledInput>
	</div>
</ModalDialog>
