<script lang="ts">
	import { onMount } from 'svelte';

	import type { User } from '$lib/stores/user_store';
	import { goto, invalidate, invalidateAll } from '$app/navigation';
	import {
		fireDeleteConfirmationDialog,
		fireSuccessToast,
		ColorTheme,
		fireSaveErrorToast,
		fireSaveSuccessToast,
		fireErrorToast
	} from '$lib/swal_helper.js';
	import Swal from 'sweetalert2';
	import type { Company } from '$lib/models/company_site.js';

	import DataTable from '$lib/components/DataTable.svelte';
	import DataTableRow from '$lib/components/DataTableRow.svelte';
	import DataTableCell from '$lib/components/DataTableCell.svelte';

	import Link from '$lib/components/HyperLink.svelte';

	import DataTableMenuButton from '$lib/components/DataTableMenuButton.svelte';
	import Button from '$lib/components/Button.svelte';
	import { incident_users } from '$lib/incident-queue';

	export let data;
	let users: User[] = [];
	let companies: Company[] = [];
	let offsets: number[] = [];
	$: {
		users = data.users;
		companies = data.companies;
	}
	// let selectedUser: User | undefined = undefined;

	async function handleRefresh() {
		await invalidateAll();
	}

	function handleAddNew() {
		goto('/settings/assyst/assyst-users');
	}

	function handleEdit(user: User) {
		goto('/settings/users/' + user.id);
	}

	async function deleteUser(selectedUser: User) {
		if (selectedUser?.id === '') {
			return;
		}
		const url = '/api/users/deleteuser';
		const formData = new FormData();
		formData.append('id', `${selectedUser?.id ?? ''}`);
		const response = await fetch(url, {
			headers: { Authorization: `Bearer ${data.user.token}` },
			body: formData,
			method: 'DELETE'
		});
		if (response.ok) {
			await invalidateAll();
			fireSuccessToast('User deleted', ColorTheme.sys);
		} else {
			fireErrorToast('Failed to delete user', ColorTheme.sys);
		}
	}

	async function handleResetPasswordClicked(selectedUser: User) {
		const { value: password } = await Swal.fire({
			title: `Reset Password for ${selectedUser?.userName}`,
			input: 'password',
			inputLabel: 'Password',
			inputPlaceholder: 'New password',
			inputAttributes: {
				autocapitalize: 'off',
				autocorrect: 'off'
			},
			showCancelButton: true
		});

		if (password === '' || password === undefined) {
			return;
		}
		const url = '/api/users/resetpassword';
		const formData = new FormData();
		formData.append('id', `${selectedUser?.id ?? ''}`);
		formData.append('password', password);
		const response = await fetch(url, {
			headers: { Authorization: `Bearer ${data.user.token}` },
			body: formData,
			method: 'POST'
		});
		if (response.ok) {
			fireSuccessToast('Password was reset', ColorTheme.sys);
		} else {
			fireErrorToast('Failed to reset password');
		}
	}

	function loadAssystUsers() {
		const users = incident_users;
		let emails = '';
		for (const user of users) {
			emails += user.emailAddress + ';';
		}
		navigator.clipboard.writeText(emails);
		
	}

	onMount(() => {
		let _offsets = [];
		for (let i = -12; i < 15; i++) {
			_offsets.push(i);
		}

		offsets = [..._offsets];
	});
</script>

<div class="p-2">
	<Button type="button" on:click={loadAssystUsers}>Incident queue users</Button>
	<DataTable on:addnew={handleAddNew} on:refresh={handleRefresh}>
		<span slot="title" class="space-x-2">
			<i class="bi bi-people-fill" />
			<span> App Users </span>
		</span>
		<tr slot="header">
			<DataTableCell isHeader={true}>User name</DataTableCell>
			<DataTableCell isHeader={true}>Full Name</DataTableCell>
			<DataTableCell isHeader={true}>Email</DataTableCell>
			<DataTableCell isHeader={true}>Company</DataTableCell>
			<DataTableCell width={50}></DataTableCell>
		</tr>
		{#each users as user (user.id)}
			<DataTableRow>
				<DataTableCell>
					<Link href={`/settings/users/${user.id}`}>
						{user.userName}
					</Link>
				</DataTableCell>
				<DataTableCell>
					{user.fullName}
				</DataTableCell>
				<DataTableCell>
					{user.email}
				</DataTableCell>
				<DataTableCell>
					{user.companySiteName ?? ''}
				</DataTableCell>
				<DataTableCell>
					<DataTableMenuButton
						on:delete={() => {
							deleteUser(user);
						}}
						on:edit={() => handleEdit(user)}
					></DataTableMenuButton>
				</DataTableCell>
			</DataTableRow>
		{/each}
	</DataTable>
</div>

<!-- 
<div class=" w-full h-full flex p-2">
	<ul class="space-y-1 border border-slate-300 overflow-y-auto p-2 rounded-md w-[300px]">
		<li class="py-2 border-b-2 border-b-slate-300 flex">
			<h3 class="text-2xl text-slate-600">Users</h3>
			<div class="ml-auto flex">
				<button
					type="button"
					class="px-2 py-1.5 rounded-l-md
				bg-teal-500 text-teal-50 focus:outline-none focus:ring active:ring ring-teal-500/20
				hover:bg-teal-600 disabled:bg-slate-100 disabled:text-slate-300
				"
					on:click={handleRefreshButtonClicked}
				>
					<i class="bi bi-arrow-clockwise"></i>
				</button>
				<button
					type="button"
					class="px-2 py-1.5 rounded-r-md
				bg-indigo-500 text-indigo-50 focus:outline-none focus:ring active:ring ring-indigo-500/20
				hover:bg-indigo-600 disabled:bg-slate-100 disabled:text-slate-300
				"
					on:click={handleAddNewUserButtonClicked}
				>
					<i class="bi bi-plus-lg" />
				</button>
			</div>
		</li>
		{#each users as user (user.id)}
			<li>
				<button
					type="button"
					data-checked={selectedUser?.id === user.id ? 'true' : 'false'}
					class="px-1 py-1 w-full text-left
					data-[checked=true]:text-indigo-500 group text-slate-500
					hover:text-slate-700 focus:outline-slate-500"
					on:click={() => {
						selectUser(user);
					}}
				>
					<div class="text-base flex">
						<span>
							{user.fullName}
						</span>
						<i class="bi bi-check-lg ml-auto hidden group-data-[checked=true]:inline-block" />
					</div>
				</button>
			</li>
		{/each}
	</ul>
	{#if selectedUser}
		<div class="border border-slate-300 min-w-[300px] rounded-md bg-white mx-2 flex-grow px-2">
			<div class="border-b-2 border-b-slate-300 py-3 flex">
				<h3 class="text-2xl text-indigo-500">Selected User Information</h3>
				<div class="ml-auto flex">
					<button
						type="button"
						class="px-2 py-1.5 rounded-l-md
					bg-red-500 text-red-50 focus:outline-none focus:ring active:ring ring-red-500/20
					hover:bg-red-600 disabled:bg-slate-100 disabled:text-slate-300 xl:w-[100px] space-x-2
					"
						on:click={deleteUser}
					>
						<i class="bi bi-trash3-fill"></i>
						<span class="hidden xl:inline">Delete</span>
					</button>
					<button
						type="button"
						class="px-2 py-1.5 rounded-r-md
					bg-indigo-500 text-indigo-50 focus:outline-none focus:ring active:ring ring-indigo-500/20
					hover:bg-indigo-600 disabled:bg-slate-100 disabled:text-slate-300 xl:w-[100px] space-x-2
					"
						on:click={saveChanges}
					>
						<i class="bi bi-floppy-fill"></i>
						<span class="hidden xl:inline"> Save </span>
					</button>
				</div>
			</div>
			<div class="grid grid-cols-2 gap-2 p-2">
				<div>
					<label for="firstNameInput" class="block w-full text-slate-600 my-1"> First Name </label>
					<input
						id="firstNameInput"
						type="text"
						bind:value={selectedUser.firstName}
						class="border border-slate-300 px-2 py-1.5 w-full rounded-md
							focus:outline-none focus:ring ring-indigo-500/20 disabled:bg-slate-100 disabled:text-slate-300"
					/>
				</div>
				<div>
					<label for="lastNameInput" class="block w-full text-slate-600 my-1"> Last Name </label>
					<input
						id="lastNameInput"
						type="text"
						bind:value={selectedUser.lastName}
						class="border border-slate-300 px-2 py-1.5 w-full rounded-md
							focus:outline-none focus:ring ring-indigo-500/20 disabled:bg-slate-100 disabled:text-slate-300"
					/>
				</div>
				<div>
					<label for="userNameInput" class="block w-full text-slate-600 my-1"> User name </label>
					<input
						id="userNameInput"
						type="text"
						disabled={selectedUser.userName === 'admin'}
						bind:value={selectedUser.userName}
						class="border border-slate-300 px-2 py-1.5 w-full rounded-md
							focus:outline-none focus:ring ring-indigo-500/20 disabled:bg-slate-100 disabled:text-slate-300"
					/>
				</div>
				<div>
					<label for="emailInput" class="block w-full text-slate-600 my-1"> Email </label>
					<input
						id="emailInput"
						type="text"
						bind:value={selectedUser.email}
						class="border border-slate-300 px-2 py-1.5 w-full rounded-md
							focus:outline-none focus:ring ring-indigo-500/20 disabled:bg-slate-100 disabled:text-slate-300"
					/>
				</div>
				<div class="">
					<LabeledFormSelect
						name="company"
						id="companySelect"
						label="Company"
						bind:value={selectedUser.companySiteId}
						on:change={companyChanged}
					>
						<option value={undefined} selected={selectedUser.companySiteId === undefined}
							>---Select Company---</option
						>
						{#each companies as company (company.id)}
							<option value={company.id} selected={selectedUser.companySiteId === company.id}>
								{company.companyName}
							</option>
						{/each}
					</LabeledFormSelect>
				</div>
				<div>
					<LabeledFormSelect
						name="tzOffset"
						id="timeZoneOffsetSelect"
						required={selectedUser.userName !== 'admin'}
						label="Timezone offset"
						bind:value={selectedUser.tzOffset}
					>
						<option value="" selected={selectedUser.tzOffset === undefined}
							>---Timezone Offset---</option
						>
						{#each offsets as offset (offset)}
							<option value={offset} selected={selectedUser.tzOffset === offset}>
								{getOffsetString(offset)}
							</option>
						{/each}
					</LabeledFormSelect>
				</div>
				<div>
					<span class=" text-slate-500 block mb-1"> Shift Start Time </span>
					<div class="grid grid-cols-2 gap-2">
						<LabeledInput
							id="shiftStartTimeInput"
							placeholder="HH"
							bind:value={selectedUser.shiftStartHours}
							isNumeric={true}
							min={0}
							max={23}
							validationText="Invalid value"
						/>
						<LabeledInput
							id="shiftEndTimeInput"
							placeholder="MM"
							bind:value={selectedUser.shiftStartMinutes}
							isNumeric={true}
							min={0}
							max={59}
							validationText="Invalid value"
						/>
					</div>
				</div>

				<div>
					<span class=" text-slate-500 block mb-1"> Shift End Time </span>
					<div class="grid grid-cols-2 gap-2">
						<LabeledInput
							id="shiftStartTimeInput"
							placeholder="HH"
							bind:value={selectedUser.shiftEndHours}
							isNumeric={true}
							min={0}
							max={23}
							validationText="Invalid value"
						/>
						<LabeledInput
							id="shiftEndTimeInput"
							placeholder="MM"
							bind:value={selectedUser.shiftEndMinutes}
							isNumeric={true}
							min={0}
							max={59}
							validationText="Invalid value"
						/>
					</div>
				</div>
			</div>
			<div class="px-2">
				<label class="flex">
					<input type="checkbox" class="w-4 h-4 my-auto" bind:checked={selectedUser.isActive} />
					<span class="text-slate-600 my-auto mx-2 blo">user is active</span>
				</label>
				<div>
					<label class="flex">
						<input
							type="checkbox"
							class="w-4 h-4 my-auto"
							bind:checked={selectedUser.enableEmailNotifications}
						/>
						<span class="text-slate-600 my-auto mx-2 blo">Receives email notifications</span>
					</label>
				</div>
				<div>
					<label class="flex">
						<input type="checkbox" class="w-4 h-4 my-auto" bind:checked={selectedUser.isAdmin} />
						<span class="text-slate-600 my-auto mx-2 blo">Admin user</span>
					</label>
				</div>
			</div>
			<div class="grid grid-cols-2 gap-2 p-2">
				<button
					type="button"
					on:click={handleResetPasswordClicked}
					class="bg-orange-400 px-2 py-1.5 rounded-md text-orange-50 hover:bg-orange-500 active:bg-orange-600
					focus:otline-none focus:ring active:ring ring-orange-500/20
					"
				>
					<i class="bi bi-key" />
					<span> Reset Password </span>
				</button>
			</div>
		</div>
	{/if}
</div> -->
