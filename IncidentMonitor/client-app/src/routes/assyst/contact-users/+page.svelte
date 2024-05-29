<script lang="ts">
	import DataTable, { type PopupMenuItem } from '$lib/components/DataTable.svelte';
	import type { AssystUserDto, ContactUserDto } from '$lib/models/assyst-user.js';
	import LabeledDropDownSearch from '$lib/components/LabeledDropDownSaarch.svelte';
	import { onMount } from 'svelte';
	import type { DepartmentDto } from '$lib/models/assyst-department.js';
	import type { KeyValuePair } from '$lib/models/keyvaluepair.js';
	import Header from '$lib/components/Header.svelte';
	import DataTableRow from '$lib/components/DataTableRow.svelte';
	import DataTableCell from '$lib/components/DataTableCell.svelte';
	import Button from '$lib/components/Button.svelte';
	import CheckBoxButton from '$lib/components/CheckBoxButton.svelte';
	import { eventTypesEnum } from '$lib/models/assyst.js';
	import DepartmentsDialog from '$lib/components/AssystComponents/DepartmentsDialog.svelte';
	import DataPaginator from '$lib/components/DataPaginator.svelte';
	import { fireSaveSuccessToast } from '$lib/swal_helper.js';
	import Breadcrumb from '$lib/components/Breadcrumb.svelte';

	let isLoading = false;
	let departments: DepartmentDto[] = [];
	let departmentKvp: KeyValuePair<number, string>[] = [];
	let isLoadingDepartments = false;
	let departmentId: number | undefined = -1;
	export let data;
	let users: ContactUserDto[] = [];
	let selectedUserIds: number[] = [];
	let query = '';

	let menuItems: PopupMenuItem[] = [];
	let departmensDialog: DepartmentsDialog;

	export let totalCount = 0;
	export let pageIndex = 0;
	export let resultsPerSearch = 25;

	async function showDepartmentsDialog(params?: any) {
		departmensDialog.openDialog();
	}

	async function getContactUsers() {
		selectedUserIds = [];
		const skip = pageIndex * resultsPerSearch;
		isLoading = true;
		users = [];
		const url = `/api/assystinfrastructure/getcontactUsers?departmentIds=${departmentId}&query=${query}&skip=${skip}&top=${resultsPerSearch}`;
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		if (response.ok) {
			const result = await response.json();
			totalCount = result.totalCount;
			users = result.contactUsers;
		}
		isLoading = false;
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

	async function handleQueryChanged(event: CustomEvent) {
		const value = event.detail.value as string;
		query = value;
		pageIndex = 0;
		totalCount = 0;

		getContactUsers();
	}

	async function handleDepartmentChanged(event: CustomEvent) {
		const detail: KeyValuePair<number, string> = event.detail.item;
		departmentId = detail.key;
		pageIndex = 0;
		getContactUsers();
	}

	async function assignUsersToDepartment(departmentId: number) {
		const url = `/api/assystinfrastructure/assigncontactuserstodepartment`;
		isLoading = true;
		const body = new FormData();
		body.append('departmentId', `${departmentId}`);
		body.append('userIds', JSON.stringify(selectedUserIds));
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			},
			method: 'POST',
			body: body
		});
		if (response.ok) {
			await getContactUsers();
			fireSaveSuccessToast();
		}
		isLoading = false;
	}

	function setupMenuItems() {
		menuItems = [
			{
				id: 0,
				content: 'Update Department',
				action: showDepartmentsDialog,
				disabled: selectedUserIds.length === 0
			}
		];
	}

	async function handleCheckChanged(event: CustomEvent) {
		const isChecked = event.detail.isChecked === true;
		const id: number = event.detail.value;

		if (isChecked === true) {
			selectedUserIds = [...selectedUserIds, id];
		} else {
			let newIds: number[] = [];
			for (const userId of selectedUserIds) {
				if (id === userId) {
					continue;
				}
				newIds.push(userId);
			}
			selectedUserIds = newIds;
		}
		setupMenuItems();
	}

	async function handleDepartmentDialogSubmited(event: CustomEvent) {
		const departmentIds: number[] | undefined = event.detail.selectedIds;
		if (!departmentIds || departmentIds.length === 0) {
			return;
		}
		assignUsersToDepartment(departmentIds[0]);
	}

	async function handleIndexChanged(event: CustomEvent) {
		let newIndex = event.detail.index;
		pageIndex = newIndex;
		getContactUsers();
	}

	onMount(() => {
		getDepartments();
		getContactUsers();
		setupMenuItems();
	});
</script>

<div class="h-screen flex flex-col">
	<Header user={data.user} {isLoading}>
		<!-- <Button type="button" on:click={assignUsersToDepartment}>Assign</Button> -->
	</Header>

	<div class="p-2 overflow-y-scroll flex-grow">
		<Breadcrumb paths={['assyst']} currentLocation="contact-users" />
		<DataTable
			isBusy={isLoading}
			hasAdvancedSearch={true}
			allowAdd={false}
			on:search={handleQueryChanged}
			popupMenuItems={menuItems}
		>
			<div slot="title">Contact Users</div>
			<div slot="advancedsearch" class="p-2">
				<div class="grid grid-cols-1 md:grid-cols-4 gap-2">
					<LabeledDropDownSearch
						name="departmentId"
						disabled={isLoadingDepartments}
						data={departmentKvp}
						labelKey="value"
						labelText="Department"
						dataKey="key"
						placeholder="Select department"
						on:selectionchanged={handleDepartmentChanged}
					/>
				</div>
			</div>
			<tr slot="header">
				<DataTableCell isHeader={true} width={40}></DataTableCell>
				<DataTableCell isHeader={true}>Name</DataTableCell>
				<DataTableCell isHeader={true}>Email</DataTableCell>
				<DataTableCell isHeader={true}>Section</DataTableCell>
				<DataTableCell isHeader={true}></DataTableCell>
			</tr>
			{#each users as user (user.id)}
				<DataTableRow>
					<DataTableCell>
						<div class="flex">
							<div class="m-auto">
								<CheckBoxButton value={user.id} on:checkchanged={handleCheckChanged} />
							</div>
						</div>
					</DataTableCell>
					<DataTableCell>
						{user.name}
						<div class="text-xs text-slate-500">
							{user.shortCode}
						</div>
					</DataTableCell>
					<DataTableCell>
						{user.email}
					</DataTableCell>
					<DataTableCell>
						{user.department?.section?.name ?? ''}
					</DataTableCell>
					<DataTableCell></DataTableCell>
				</DataTableRow>
			{/each}
		</DataTable>
	</div>
	<DataPaginator
		on:indexchanged={handleIndexChanged}
		bind:currentIndex={pageIndex}
		bind:resultsPerSearch
		bind:totalCount
	/>
</div>

<DepartmentsDialog
	bind:this={departmensDialog}
	loggedInUser={data.user}
	{departments}
	selection="single"
	on:submit={handleDepartmentDialogSubmited}
></DepartmentsDialog>
