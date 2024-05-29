<script lang="ts">
	import ContactUsersDialog from '$lib/components/AssystComponents/ContactUsersDialog.svelte';
	import Button from '$lib/components/Button.svelte';
	import DataTable from '$lib/components/DataTable.svelte';
	import DataTableRow from '$lib/components/DataTableRow.svelte';
	import DataTableCell from '$lib/components/DataTableCell.svelte';

	import EventRow from '$lib/components/EventRow.svelte';
	import Header from '$lib/components/Header.svelte';
	import LabeledDropDownSaarch from '$lib/components/LabeledDropDownSaarch.svelte';
	import MultiSelectDialog from '$lib/components/SearchModalDialog.svelte';
	import type { DepartmentDto } from '$lib/models/assyst-department.js';
	import { getEventFormattedStatus, type EventDto } from '$lib/models/assyst-event.js';
	import type { KeyValuePair } from '$lib/models/keyvaluepair.js';
	import { onMount, tick } from 'svelte';
	import DataTableMenuButton from '$lib/components/DataTableMenuButton.svelte';
	import {
		fireErrorToast,
		fireSaveErrorToast,
		fireSaveSuccessToast,
		fireSuccessToast
	} from '$lib/swal_helper.js';

	import HyperLink from '$lib/components/HyperLink.svelte';
	import Breadcrumb from '$lib/components/Breadcrumb.svelte';
	import ModalDialog from '$lib/components/ModalDialog.svelte';
	import AssystActionEdit from '$lib/components/AssystActionEdit.svelte';

	export let data;
	let isLoading = false;
	let departments: DepartmentDto[] = [];
	let departmentKvp: KeyValuePair<number, string>[] = [];
	let isLoadingDepartments = false;
	let departmentId: number | undefined = 0;
	let query: string = '';
	let events: EventDto[] = [];

	enum DepartmentIds {
		DiamondVogel = 47,
		Carrix = 43
	}

	async function getDepartments() {
		isLoadingDepartments = true;
		departmentKvp = [];

		const url = '/api/assystinfrastructure/getdepartments';
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});

		if (response.ok) {
			departments = await response.json();
			for (const department of departments) {
				departmentKvp.push({
					key: department.id!,
					value: department.sectionName ?? 'Not Set'
				});
			}

			departmentKvp = [...departmentKvp];
		}

		isLoadingDepartments = false;
	}

	async function handleDepartmentChanged(event: CustomEvent) {
		const detail: KeyValuePair<number, string> = event.detail.item;

		departmentId = detail.key;
	}

	async function doWork() {
		let searchQuery = '';

		if (departmentId && departmentId > 0) {
			searchQuery = `departmentId=${departmentId}`;
		}
		if (!searchQuery) {
			return;
		}
		searchQuery = `?searchQuery=${searchQuery}`;

		const url = `/api/assyst/searchEvents${searchQuery}`;
		isLoading = true;

		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		if (response.ok) {
			// events = await response.json();
		}
		isLoading = false;
	}

	async function handleSearch(event: CustomEvent) {
		const _query: string = event.detail.value;
		query = _query;
		getEvents();
	}

	async function getEvents() {
		let url = '/api/assyst/searchevents';

		let ids = query.split(',');
		let eventRefQuery = '';

		if (query) {
			eventRefQuery = 'eventRef=';
			for (let id of ids) {
				id = id.replace('T', '');
				// let idNumeric = Number(id);
				// console.log(idNumeric);
				eventRefQuery = `${eventRefQuery}${id},`;
			}
		}
		if (eventRefQuery) {
			eventRefQuery = eventRefQuery.substring(0, eventRefQuery.length - 1);
		}
		let searchParam = `${eventRefQuery}`;

		if (searchParam) {
			url += '?searchQuery=' + searchParam;
		}
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

	async function connectDiamondVogel(event: EventDto) {
		const url = `/api/integrations/connecttodiamondvogel?eventId=${event.id}`;
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			},
			method: 'POST'
		});
		if (response.ok) {
			fireSuccessToast('Tickets connected');
		} else {
			fireErrorToast('Failed to connect tickets');
		}
	}

	async function updateCarrixHoistNumber(event: EventDto) {
		const url = `/api/integrations/carrixupdatehoistnumber`;
		const body = new FormData();
		body.append('id', `${event.id}`);
		body.append('userReference', `${event.userReference}`);
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			},
			method: 'POST',
			body: body
		});
		if (response.ok) {
			fireSuccessToast('Hoist Number updated');
		} else {
			fireErrorToast('Failed to update Hoist Number');
		}
	}

	function exportCsv() {
		let csvContent = '';
		let header = ['#', 'Affected User', 'Client', 'Client Ref', 'Dpartment', 'Status'];
		const row = header.join(',');
		csvContent += row + '\r\n';

		for (const event of events) {
			let arr = [
				event.formattedReference,
				event.affectedUserEmail,
				event.department?.section?.name ?? event.department?.sectionDepartmentName,
				event.userReference,
				event.assignedServDept?.name ?? '',
				getEventFormattedStatus(event)
			].join(',');
			csvContent = csvContent + arr + '\r\n';
		}

		let blob = new Blob([csvContent], { type: 'data:text/csv;charset=utf-8' });
		let url = URL.createObjectURL(blob);
		const link = document.createElement('a');
		link.href = url;
		link.download = `search_data.csv`;

		link.click();
	}

	onMount(() => {
		getDepartments();
	});
</script>

<Header user={data.user} {isLoading}>
	<div class="flex w-full"></div>
</Header>

<div class="p-2">
	<Breadcrumb paths={['assyst']} currentLocation="event-search" />
	<div class="text-right">
		<Button type="button" buttonStyle="link" disabled={!events} on:click={exportCsv}>
			Export CSV
		</Button>
	</div>
	<DataTable
		isBusy={isLoading}
		hasAdvancedSearch={true}
		searchHint="Search events by reference"
		on:search={handleSearch}
		on:refresh={getEvents}
	>
		<span slot="title"> Assyst Events Search </span>
		<div slot="advancedsearch" class="p-2">
			<div class="grid grid-cols-4 gap-2">
				<LabeledDropDownSaarch
					name="departmentId"
					disabled={isLoadingDepartments}
					data={departmentKvp}
					labelKey="value"
					labelText="Department"
					dataKey="key"
					placeholder="Select department"
					on:selectionchanged={handleDepartmentChanged}
				/>
				<ContactUsersDialog {departmentId} loggedInUser={data.user} />
				<Button disabled={isLoading} type="button" on:click={doWork}>Go, not the lang</Button>
			</div>
		</div>

		<tr slot="header">
			<DataTableCell width={75} isHeader={true}>#</DataTableCell>
			<DataTableCell isHeader={true}>Affected User</DataTableCell>
			<DataTableCell isHeader={true}>Client</DataTableCell>
			<DataTableCell isHeader={true}>Client Reference</DataTableCell>
			<DataTableCell isHeader={true}>Serv. Department</DataTableCell>
			<DataTableCell isHeader={true}>Description</DataTableCell>
			<DataTableCell isHeader={true}>Status</DataTableCell>
			<DataTableCell isHeader={true} width={50}></DataTableCell>
		</tr>

		{#each events as event (event.id)}
			<DataTableRow>
				<DataTableCell>
					<HyperLink href="/assyst/event/{event.id}">
						{event.formattedReference}
					</HyperLink>
					<div class="text-xs">
						{event.id}
					</div>
				</DataTableCell>
				<DataTableCell>
					<span>{event.affectedUserName}</span>
					<small class="block text-sm">
						{event.affectedUserEmail}
					</small>
				</DataTableCell>
				<DataTableCell>
					{event.department?.section?.name ?? event.department?.sectionDepartmentName}
				</DataTableCell>
				<DataTableCell>
					{event.userReference}
				</DataTableCell>
				<DataTableCell>
					{event.assignedServDept?.name ?? ''}
				</DataTableCell>

				<DataTableCell>
					{event.shortDescription}
				</DataTableCell>
				<DataTableCell>
					<span class="whitespace-nowrap capitalize">
						{getEventFormattedStatus(event)}
					</span>
				</DataTableCell>

				<DataTableCell>
					<DataTableMenuButton menuWidth={300} showDelete={false} showEdit={false}>
						{#if event.departmentId === DepartmentIds.DiamondVogel}
							<button
								type="button"
								data-menu-item="true"
								on:click={(evt) => connectDiamondVogel(event)}
							>
								<i class="bi bi-arrow-repeat"></i>
								<span> Connect Diamond Vogel </span>
							</button>
						{/if}
						{#if event.departmentId === DepartmentIds.Carrix}
							<button
								type="button"
								data-menu-item="true"
								on:click={() => updateCarrixHoistNumber(event)}
							>
								<span> Update Hoist Number </span>
							</button>
						{/if}
						{#if event.departmentId === DepartmentIds.Carrix || event.departmentId === DepartmentIds.DiamondVogel}
							<a href="/assyst/compare/{event.id}" data-menu-item="true"> Compare </a>
						{/if}
					</DataTableMenuButton>
				</DataTableCell>
			</DataTableRow>
		{/each}
	</DataTable>
</div>
