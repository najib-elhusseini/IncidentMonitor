<script lang="ts">
	import type { DepartmentDto } from '$lib/models/assyst-department';
	import type { User } from '$lib/stores/user_store';
	import { createEventDispatcher, onMount } from 'svelte';
	import SearchModalDialog from '../SearchModalDialog.svelte';

	import CheckListItem from '../CheckListItem.svelte';

	export let loggedInUser: User;
	export let selection: 'single' | 'multiple' = 'single';

	export let departments: DepartmentDto[] = [];
	const dispatch = createEventDispatcher();
	let departmentsFiltered: DepartmentDto[] = [];
	let dialog: SearchModalDialog;
	let isLoading = false;
	let query = '';
	let selectedIds: number[] = [];

	function filterDepartments() {
		if (!query || query.trim() === '') {
			departmentsFiltered = [...departments];
			return;
		}
		query = query.toLowerCase();
		departmentsFiltered = [];
		for (const department of departments) {
			if (
				department.shortCode?.toLowerCase().includes(query) ||
				department.sectionName?.toLowerCase().includes(query)
			) {
				departmentsFiltered.push(department);
			}
		}
		departmentsFiltered = [...departmentsFiltered];
	}

	async function handleQueryChanged(event: CustomEvent) {
		query = event.detail.query;
		filterDepartments();
	}

	async function getAllDepartments() {
		isLoading = true;
		departments = [];
		departmentsFiltered = [];

		const url = '/api/assystinfrastructure/getdepartments';
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${loggedInUser.token}`
			}
		});

		if (response.ok) {
			departments = await response.json();
			filterDepartments();
		}
		isLoading = false;
	}

	export function openDialog() {
		dialog.openDialog();
	}

	function handleCheckChanged(event: CustomEvent) {
		if (selection === 'single') {
			selectedIds = [];
		}
		let isChecked = event.detail.isChecked === true;
		let id = event.detail.value;
		if (isChecked) {
			selectedIds = [...selectedIds, id];
		} else {
			let _ids = [];
			for (const _id of selectedIds) {
				if (_id === id) {
					continue;
				}
				_ids.push(_id);
			}
			selectedIds = _ids;
		}
		departmentsFiltered = departmentsFiltered;
	}

	function isDepartmentChecked(department: DepartmentDto): boolean {
		if (!department.id) {
			return false;
		}
		for (const _id of selectedIds) {
			if (_id === department.id) {
				return true;
			}
		}
		return false;
	}

	function handleSubmit() {
		dispatch('submit', {
			selectedIds
		});
        dialog.dismissDialog();
	}

	onMount(() => {
		if (!departments || departments.length === 0) {
			getAllDepartments();
		} else {
			filterDepartments();
		}
	});
</script>

<SearchModalDialog
	bind:this={dialog}
	buttonLabel="Search Departments"
	buttonVisible={false}
	on:queryChanged={handleQueryChanged}
	on:submit={handleSubmit}
>
	<div class="divide-y">
		{#each departmentsFiltered as department (department.id)}
			<CheckListItem
				isChecked={isDepartmentChecked(department)}
				value={department.id}
				on:checkchanged={handleCheckChanged}
			>
				{department.sectionName}
			</CheckListItem>
			<!-- <div class="bg-white odd:bg-slate-50 py-1">
				<div>
					{user.name}
				</div>
				{#if user.emailAddress}
					<span class="text-sm">({user.emailAddress})</span>
				{/if}
			</div> -->
		{/each}
	</div>
</SearchModalDialog>
