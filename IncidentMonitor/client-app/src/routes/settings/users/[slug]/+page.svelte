<script lang="ts">
	import { invalidateAll } from '$app/navigation';
	import Breadcrumb from '$lib/components/Breadcrumb.svelte';
	import Button from '$lib/components/Button.svelte';
	import Form from '$lib/components/Form.svelte';
	import LabeledFormSelect from '$lib/components/LabeledFormSelect.svelte';
	import LabeledInput from '$lib/components/LabeledInput.svelte';
	import type { Company } from '$lib/models/company_site.js';
	import { fireSaveErrorToast, fireSaveSuccessToast } from '$lib/swal_helper';

	export let data;
	let user = data.contextUser;
	let companies: Company[] = data.companies;
	let offsets: number[] = data.offsets;
	let isLoading = false;

	function companyChanged(event: CustomEvent) {
		const companyId = user.companySiteId;
		console.log(companyId);
		if (!companyId || !user) {
			return;
		}

		let company: Company | undefined = undefined;
		for (const _comp of companies) {
			if (_comp.id === companyId) {
				company = _comp;
				break;
			}
		}
		if (company === undefined) {
			return;
		}
		user.shiftStartHours = company.shiftStartHours;
		user.shiftStartMinutes = company.shiftStartMinutes;
		user.shiftEndHours = company.shiftEndHours;
		user.shiftEndMinutes = company.shiftEndMinutes;
		user.tzOffset = company.tzOffset;
	}

	function getOffsetString(offset: number) {
		let sign = offset < 0 ? '-' : '+';
		const offsetString = `${sign}${Math.abs(offset)}`;
		return offsetString;
	}

	async function saveChanges() {
		const url = '/api/users/saveuser';
		const formData = new FormData();
		formData.append('id', `${user?.id ?? ''}`);
		formData.append('firstName', `${user?.firstName ?? ''}`);
		formData.append('lastName', `${user?.lastName ?? ''}`);
		formData.append('email', `${user?.email ?? ''}`);
		formData.append('userName', `${user?.userName ?? ''}`);
		formData.append('receivesNotifications', `${user?.enableEmailNotifications}`);
		formData.append('isActive', `${user?.isActive}`);
		formData.append('isAdmin', `${user?.isAdmin}`);
		formData.append('companyId', `${user?.companySiteId}`);
		formData.append('tzOffset', `${user?.tzOffset}`);
		formData.append('shiftStartHours', `${user?.shiftStartHours}`);
		formData.append('shiftStartMinutes', `${user?.shiftStartMinutes}`);
		formData.append('shiftEndHours', `${user?.shiftEndHours}`);
		formData.append('shiftEndMinutes', `${user?.shiftEndMinutes}`);
		isLoading = true;
		const response = await fetch(url, {
			headers: { Authorization: `Bearer ${data.user.token}` },
			body: formData,
			method: 'POST'
		});
		if (response.ok) {
			fireSaveSuccessToast();
			await invalidateAll();
			user = data.contextUser;
		} else {
			fireSaveErrorToast();
		}
		isLoading = false;
	}
</script>

<div class="p-2">
	<Breadcrumb paths={['settings', 'users']} currentLocation="User" />
</div>

<div class="flex">
	<div class="mx-0 md:mx-auto w-full md:w-2/3 lg:w-1/2">
		<Form isCard={true} on:submit={saveChanges}>
			<span slot="title">
				<i class="bi bi-person-fill"></i>
				<span>
					Edit User {user.fullName}
				</span>
			</span>
			<div class="grid grid-cols-2 gap-2 p-2">
				<div>
					<label for="firstNameInput" class="block w-full text-slate-600 my-1"> First Name </label>
					<input
						id="firstNameInput"
						type="text"
						bind:value={user.firstName}
						class="border border-slate-300 px-2 py-1.5 w-full rounded-md
							focus:outline-none focus:ring ring-indigo-500/20 disabled:bg-slate-100 disabled:text-slate-300"
					/>
				</div>
				<div>
					<label for="lastNameInput" class="block w-full text-slate-600 my-1"> Last Name </label>
					<input
						id="lastNameInput"
						type="text"
						bind:value={user.lastName}
						class="border border-slate-300 px-2 py-1.5 w-full rounded-md
							focus:outline-none focus:ring ring-indigo-500/20 disabled:bg-slate-100 disabled:text-slate-300"
					/>
				</div>
				<div>
					<label for="userNameInput" class="block w-full text-slate-600 my-1"> User name </label>
					<input
						id="userNameInput"
						type="text"
						disabled={user.userName === 'admin'}
						bind:value={user.userName}
						class="border border-slate-300 px-2 py-1.5 w-full rounded-md
							focus:outline-none focus:ring ring-indigo-500/20 disabled:bg-slate-100 disabled:text-slate-300"
					/>
				</div>
				<div>
					<label for="emailInput" class="block w-full text-slate-600 my-1"> Email </label>
					<input
						id="emailInput"
						type="text"
						bind:value={user.email}
						class="border border-slate-300 px-2 py-1.5 w-full rounded-md
							focus:outline-none focus:ring ring-indigo-500/20 disabled:bg-slate-100 disabled:text-slate-300"
					/>
				</div>
				<div class="">
					<LabeledFormSelect
						name="company"
						id="companySelect"
						label="Company"
						bind:value={user.companySiteId}
						on:change={companyChanged}
					>
						<option value={undefined} selected={user.companySiteId === undefined}
							>---Select Company---</option
						>
						{#each companies as company (company.id)}
							<option value={company.id} selected={user.companySiteId === company.id}>
								{company.companyName}
							</option>
						{/each}
					</LabeledFormSelect>
				</div>
				<div>
					<LabeledFormSelect
						name="tzOffset"
						id="timeZoneOffsetSelect"
						required={user.userName !== 'admin'}
						label="Timezone offset"
						bind:value={user.tzOffset}
					>
						<option value="" selected={user.tzOffset === undefined}>---Timezone Offset---</option>
						{#each offsets as offset (offset)}
							<option value={offset} selected={user.tzOffset === offset}>
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
							bind:value={user.shiftStartHours}
							isNumeric={true}
							min={0}
							max={23}
							validationText="Invalid value"
						/>
						<LabeledInput
							id="shiftEndTimeInput"
							placeholder="MM"
							bind:value={user.shiftStartMinutes}
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
							bind:value={user.shiftEndHours}
							isNumeric={true}
							min={0}
							max={23}
							validationText="Invalid value"
						/>
						<LabeledInput
							id="shiftEndTimeInput"
							placeholder="MM"
							bind:value={user.shiftEndMinutes}
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
					<input type="checkbox" class="w-4 h-4 my-auto" bind:checked={user.isActive} />
					<span class="text-slate-600 my-auto mx-2 blo">user is active</span>
				</label>
				<div>
					<label class="flex">
						<input
							type="checkbox"
							class="w-4 h-4 my-auto"
							bind:checked={user.enableEmailNotifications}
						/>
						<span class="text-slate-600 my-auto mx-2 blo">Receives email notifications</span>
					</label>
				</div>
				<div>
					<label class="flex">
						<input type="checkbox" class="w-4 h-4 my-auto" bind:checked={user.isAdmin} />
						<span class="text-slate-600 my-auto mx-2 blo">Admin user</span>
					</label>
				</div>
			</div>
			<div class="grid gap-2 p-2">
				<Button type="submit" disabled={isLoading}>
					<i class="bi bi-cloud-download-fill"></i>
					<span> Save Changes </span>
				</Button>
			</div>
			<!-- <div class="grid grid-cols-2 gap-2 p-2">
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
			</div> -->
		</Form>
	</div>
</div>
