<script lang="ts">
	import { goto } from '$app/navigation';
	import Breadcrumb from '$lib/components/Breadcrumb.svelte';
	import DataTable from '$lib/components/DataTable.svelte';
	import DataTableCell from '$lib/components/DataTableCell.svelte';
	import DataTableRow from '$lib/components/DataTableRow.svelte';
	import LabeledFormInput from '$lib/components/LabeledFormInput.svelte';
	import LabeledInput from '$lib/components/LabeledInput.svelte';
	import LoadingSpinner from '$lib/components/LoadingSpinner.svelte';
	import ModalDialog from '$lib/components/ModalDialog.svelte';
	import Paginator from '$lib/components/Paginator.svelte';

	import type { AssystUserDto } from '$lib/models/assyst-user.js';
	import type { User } from '$lib/stores/user_store.js';
	import { capitalize } from '$lib/helpers/string-helper';
	import {
		fireErrorToast,
		fireSaveErrorToast,
		fireSaveSuccessToast,
		fireSuccessToast
	} from '$lib/swal_helper.js';
	import type { AtRule } from 'postcss';

	import { onDestroy, onMount } from 'svelte';

	export let data;
	let usersCount = 0;
	let isLoading = false;
	let rowsPerPage: number = 25;
	let currentPage: number = 0;
	let totalPages: number = 0;

	let users: AssystUserDto[] = [];
	let query: string = '';
	let container: HTMLDivElement;
	$: {
		totalPages = Math.ceil(usersCount / rowsPerPage);
	}

	//Add AssystUser Region
	let addUserDialog: ModalDialog;
	let newUserEmail: string = '';
	let isBusy_AddUser = false;

	function showAddAssystUserDialog() {
		newUserEmail = '';
		addUserDialog.openDialog();
	}

	function dismissNewUserDialog() {
		addUserDialog.dismissDialog();
	}
	async function saveNewUserDialog() {
		if (!newUserEmail) {
			return;
		}
		let splitted = newUserEmail.split('@');

		if (splitted.length === 0) {
			return;
		}

		splitted = splitted[0].split('.');
		for (let index = 0; index < splitted.length; index++) {
			splitted[index] = capitalize(splitted[index]);
		}
		const url = '/api/users/addassystuser';
		const body = new FormData();
		body.append('email', newUserEmail);
		body.append('name', splitted.join(' '));
		isBusy_AddUser = true;
		const response = await fetch(url, {
			method: 'POST',
			body,
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		isBusy_AddUser = false;
		if (response.ok) {
			dismissNewUserDialog();
			fireSaveSuccessToast();
		} else {
			fireErrorToast('Failed to add user');
		}
	}
	//end region

	async function getPageData() {
		isLoading = true;
		users = [];
		var skip = currentPage * rowsPerPage;

		const url = `/api/users/getassystusers?skip=${skip}&top=${rowsPerPage}&query=${query}`;
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		if (response.ok) {
			const _data: any = await response.json();
			usersCount = _data.count;
			users = _data.users;
		} else {
			usersCount = 0;
		}

		isLoading = false;
	}

	async function handleSearch(event: CustomEvent) {
		query = event.detail.value;
		currentPage = 0;

		await getPageData();
	}

	async function importUserFromAssyst(event: Event, user: AssystUserDto) {
		const button = event.target as HTMLButtonElement;
		button.disabled = true;
		const url = `/api/users/importUser?id=${user.id}`;
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			},
			method: 'POST'
		});
		if (response.ok) {
			const userId: string = await response.text();
			fireSuccessToast('Assyst User added successfully');
			await goto('/settings/users/' + userId);
		} else {
			fireErrorToast('Failed to add Assyst User');
			button.disabled = false;
		}
	}

	function handleGotoFirstPage() {
		currentPage = 0;
		getPageData();
	}

	function handleGotoPreviousPage() {
		currentPage--;
		if (currentPage < 0) {
			currentPage = 0;
		}
		getPageData();
	}

	function handleGotoNextPage() {
		currentPage++;
		if (currentPage === totalPages) {
			currentPage = totalPages - 1;
		}
		getPageData();
	}

	function handleGotoLastPage() {
		currentPage = totalPages - 1;
		getPageData();
	}

	onMount(() => {
		let parent = container.parentElement;
		if (parent) {
			parent.style.display = 'flex';
		}
		getPageData();
	});

	onDestroy(() => {
		let parent = container.parentElement;
		if (parent) {
			parent.style.display = 'block';
		}
	});
</script>

<div class="relative flex-grow" bind:this={container}>
	<div class="absolute inset-x-0 top-0 bottom-10 p-2 overflow-y-scroll">
		<div>
			<Breadcrumb paths={['settings', 'users']} currentLocation="Assyst Users" />
		</div>
		<DataTable
			allowAdd={true}
			on:search={handleSearch}
			on:addnew={showAddAssystUserDialog}
			isBusy={isLoading}
		>
			<span slot="title"> Assyst Users </span>
			<tr slot="header">
				<DataTableCell isHeader={true}>User</DataTableCell>
				<DataTableCell isHeader={true}>Email</DataTableCell>
				<DataTableCell isHeader={true}>Roles</DataTableCell>
				<DataTableCell isHeader={true} width={70}></DataTableCell>
			</tr>
			{#each users as user (user.id)}
				<DataTableRow>
					<DataTableCell>
						{user.name}
					</DataTableCell>
					<DataTableCell>
						{user.emailAddress === '' ? 'N/A' : user.emailAddress}
					</DataTableCell>
					<DataTableCell>
						{#if user.privilegeGroupMemberships}
							<ul class="space-y-1">
								{#each user.privilegeGroupMemberships as prevMembership}
									{#if prevMembership.privilegeGroup}
										<li class="">
											<span class="text-xs">
												{prevMembership.privilegeGroup.name}
											</span>
										</li>
									{/if}
								{/each}
							</ul>
						{/if}
					</DataTableCell>
					<DataTableCell>
						<div class="text-center">
							<button
								type="button"
								class="bg-blue-500 text-blue-50 px-3 py-1.5 rounded-md
                                    hover:bg-blue-600 active:ring focus:outline-none focus:ring
                                    disabled:bg-slate-100 disabled:text-slate-300
                                    ring-blue-600/20 transition-all"
								on:click={(evt) => importUserFromAssyst(evt, user)}
							>
								<i class="bi bi-download pointer-events-none"></i>
							</button>
						</div>
					</DataTableCell>
				</DataTableRow>
			{/each}
		</DataTable>
	</div>
	<div
		class="absolute inset-x-0 bottom-0 h-10 border-t border-t-slate-300 flex px-2 text-sm text-slate-600"
	>
		{#if !isLoading}
			<div class="ml-auto my-auto mr-2">
				<button
					disabled={currentPage === 0 || totalPages <= 1}
					type="button"
					class="text-slate-600
                    focus:outline-none hover:text-blue-500 active:text-blue-600 px-1
                    disabled:text-slate-300
                    "
					on:click={handleGotoFirstPage}
				>
					<i class="bi bi-chevron-double-left"></i>
				</button>
				<button
					disabled={currentPage === 0 || totalPages <= 1}
					type="button"
					class="text-slate-600
                    focus:outline-none hover:text-blue-500 active:text-blue-600 px-1
                    disabled:text-slate-300
                    "
					on:click={handleGotoPreviousPage}
				>
					<i class="bi bi-chevron-left"></i>
				</button>
				<span>
					{currentPage + 1} of {totalPages}
				</span>
				<button
					disabled={currentPage === totalPages - 1 || totalPages <= 1}
					type="button"
					class="text-slate-600
                    focus:outline-none hover:text-blue-500 active:text-blue-600 px-1
                    disabled:text-slate-300
                    "
					on:click={handleGotoNextPage}
				>
					<i class="bi bi-chevron-right"></i>
				</button>
				<button
					disabled={currentPage === totalPages - 1 || totalPages <= 1}
					type="button"
					class="text-slate-600
                    focus:outline-none hover:text-blue-500 active:text-blue-600 px-1
                    disabled:text-slate-300
                    "
					on:click={handleGotoLastPage}
				>
					<i class="bi bi-chevron-double-right"></i>
				</button>
			</div>
		{:else}
			<div class="my-auto flex">
				<LoadingSpinner />
				<span> Loading, please wait.... </span>
			</div>
		{/if}
	</div>
</div>

<ModalDialog
	bind:this={addUserDialog}
	allowSubmit={true}
	on:submit={saveNewUserDialog}
	on:cancel={dismissNewUserDialog}
	busy={isBusy_AddUser}
>
	<div slot="title">Add Assyst User</div>
	<div class="my-2">
		<LabeledFormInput
			id="addNewUserInput"
			required={true}
			labelText="Email Address"
			placeholder="Enter the email address for the new user"
			bind:value={newUserEmail}
		/>
	</div>
</ModalDialog>
