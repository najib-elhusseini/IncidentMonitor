<script lang="ts">
	import FormButton from '$lib/components/FormButton.svelte';
	import LabeledFormSelect from '$lib/components/LabeledFormSelect.svelte';
	import LabeledInput from '$lib/components/LabeledInput.svelte';
	import ToggleButton from '$lib/components/ToggleButton.svelte';
	import type { Company } from '$lib/models/company_site';
	import { createEventDispatcher, onMount } from 'svelte';

	const dispatch = createEventDispatcher();

	export let site: Company;
	export let token: string | undefined;
	let offsets: number[] = [];

	let isMounted = false;
	let isClickWithin = false;
	let isLoading = false;

	function cancelDialog(event: MouseEvent) {
		if (isClickWithin || isLoading) {
			isClickWithin = false;
			return;
		}
		const target = event.target as HTMLElement;
		const isToggler = target.dataset.dialogToggle;
		if (isToggler !== 'true') {
			return;
		}
		const isCancel = target.dataset.dialogCancel === 'true';
		if (isCancel) {
			cancelDialogInternal(false);
			return;
		}
	}

	function cancelDialogInternal(isSaved: boolean) {
		if (isLoading) return;
		isMounted = false;
		setTimeout(() => {
			dispatch('dialogClosed', {
				cancel: !isSaved,
				site
			});
		}, 300);
	}

	async function saveChanges() {
		if (site.tzOffset === undefined) {
			return;
		}		
		const url = '/api/companysites/updatecompany';
		const body = new FormData();
		body.append('id', `${site.id}`);
		body.append('companyName', `${site.companyName}`);
		body.append('shiftStartHours', `${site.shiftStartHours}`);
		body.append('shiftStartMinutes', `${site.shiftStartMinutes}`);
		body.append('shiftEndHours', `${site.shiftEndHours}`);
		body.append('shiftEndMinutes', `${site.shiftEndMinutes}`);
		body.append('enableAlarmNotifications', `${site.enableAlarmNotifications}`);
		body.append('enableEmailNotifications', `${site.enableEmailNotifications}`);
		body.append('tzOffset', `${site.tzOffset}`);

		isLoading = true;
		const response = await fetch(url, {
			method: 'post',
			body: body,
			headers: {
				Authorization: `Bearer ${token}`
			}
		});
		isLoading = false;
		if (response.ok) {
			const id = await response.text();
			site.id = Number(id);
			cancelDialogInternal(true);
		}
	}

	function getOffsetString(offset: number) {
		let sign = offset < 0 ? '-' : '+';
		const offsetString = `${sign}${Math.abs(offset)}`;
		return offsetString;
	}

	onMount(() => {
		let _offsets = [];
		for (let i = -12; i < 15; i++) {
			_offsets.push(i);
		}
		
		offsets = [..._offsets];
		setTimeout(() => {
			isMounted = true;
		}, 10);
	});
</script>

<!-- svelte-ignore a11y-click-events-have-key-events -->
<!-- svelte-ignore a11y-no-static-element-interactions -->
<div
	class="fixed inset-0 bg-black/20 flex"
	on:click={cancelDialog}
	data-dialog-toggle="true"
	data-dialog-cancel="true"
>
	<div
		on:mousedown={() => {
			isClickWithin = true;
		}}
		on:mouseup={() => {
			isClickWithin = false;
		}}
		class="w-11/12 md:w-1/2 lg:w-1/3 bg-white m-auto p-2 md:p-4 {isMounted
			? 'scale-100'
			: 'scale-50'} shadow-md rounded-md border border-slate-400 transition-all ease-in-out duration-300"
	>
		<div class="flex">
			<h3 class="text-2xl text-indigo-500 py-3 my-auto">
				<i class="bi bi-buildings-fill"></i>
				{#if site.id === 0}
					Add New Site
				{:else}
					Edit Site
				{/if}
			</h3>
			<button
				type="button"
				class="focus:outline-none text-red-500 hover:text-red-600 ml-auto my-auto disabled:text-slate-300"
				data-dialog-toggle="true"
				data-dialog-cancel="true"
				disabled={isLoading}
				on:click={() => cancelDialogInternal(false)}
			>
				<i class="bi bi-x-circle-fill pointer-events-none text-lg"></i>
			</button>
		</div>
		<hr class=" border-slate-400" />
		<div class="py-2">
			<LabeledInput
				label="Site Name"
				required={true}
				id="companyNameInput"
				name="companyName"
				bind:value={site.companyName}
			/>

			<LabeledFormSelect
				id="timeZonesSelect"
				label="Time Zone Offset"
				required={true}
				validationText="Please select timezone"
				bind:value={site.tzOffset}
			>
				<option value="">---Timezone Offset---</option>
				{#each offsets as offset (offset)}
					<option value={offset} selected={site.tzOffset===offset}>
						{getOffsetString(offset)}
					</option>
				{/each}
			</LabeledFormSelect>
			<div class="grid grid-cols-2 gap-2 my-1">
				<div>
					<span class=" text-slate-500 block mb-1"> Shift Start Time </span>
					<div class="grid grid-cols-2 gap-2">
						<LabeledInput
							id="shiftStartTimeInput"
							placeholder="HH"
							bind:value={site.shiftStartHours}
							isNumeric={true}
							min={0}
							max={23}
							validationText="Invalid value"
						/>
						<LabeledInput
							id="shiftEndTimeInput"
							placeholder="MM"
							bind:value={site.shiftStartMinutes}
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
							bind:value={site.shiftEndHours}
							isNumeric={true}
							min={0}
							max={23}
							validationText="Invalid value"
						/>
						<LabeledInput
							id="shiftEndTimeInput"
							placeholder="MM"
							bind:value={site.shiftEndMinutes}
							isNumeric={true}
							min={0}
							max={59}
							validationText="Invalid value"
						/>
					</div>
				</div>
			</div>
			<div class="space-y-2">
				<ToggleButton
					label="Enable email notifications"
					bind:checked={site.enableEmailNotifications}
				/>
				<ToggleButton
					label="Enable alarm notifications"
					bind:checked={site.enableAlarmNotifications}
				/>
			</div>
			<div class="grid grid-cols-2 gap-2 my-2">
				<FormButton role="primary" on:click={saveChanges} disabled={isLoading}>
					<i class="bi bi-floppy-fill" />
					Save
				</FormButton>
				<FormButton
					role="secondary"
					on:click={() => cancelDialogInternal(false)}
					disabled={isLoading}>Cancel</FormButton
				>
			</div>
		</div>
	</div>
</div>
