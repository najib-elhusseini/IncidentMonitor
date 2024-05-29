<script lang="ts">
	import { invalidateAll } from '$app/navigation';

	import Button from '$lib/components/Button.svelte';
	import DataTable from '$lib/components/DataTable.svelte';
	import DataTableCell from '$lib/components/DataTableCell.svelte';
	import DataTableMenuButton from '$lib/components/DataTableMenuButton.svelte';
	import DataTableRow from '$lib/components/DataTableRow.svelte';

	import LabeledInput from '$lib/components/LabeledInput.svelte';
	import LabeledSelect from '$lib/components/LabeledSelect.svelte';
	import ModalDialog from '$lib/components/ModalDialog.svelte';
	import ToggleButton from '$lib/components/ToggleButton.svelte';

	import type { Company } from '$lib/models/company_site.js';
	import {
		fireDeleteConfirmationDialog,
		fireSaveErrorToast,
		fireSaveSuccessToast
	} from '$lib/swal_helper.js';
	import { onMount } from 'svelte';

	export let data;
	let sites: Company[] = [];
	$: {
		sites = data.sites;
	}
	let contextSite: Company | undefined = undefined;
	let isBusy = true;
	let dialog: ModalDialog;
	let offsets: number[] = [];
	let isLoading = false;

	function getOffsetString(offset: number) {
		let sign = offset < 0 ? '-' : '+';
		const offsetString = `${sign}${Math.abs(offset)}`;
		return offsetString;
	}

	function addNewCompany() {
		contextSite = {
			id: 0,
			companyName: 'new site',
			shiftStartHours: 10,
			shiftStartMinutes: 30,
			shiftEndHours: 18,
			shiftEndMinutes: 30,
			enableAlarmNotifications: true,
			enableEmailNotifications: true,
			alarmInterval: 3000
		};
		dialog.openDialog();
	}

	function editCompany(company: Company) {
		contextSite = company;
		dialog.openDialog();
	}

	async function deleteCompany(id: number) {
		const response = await fireDeleteConfirmationDialog();
		if (!response.isConfirmed) {
			return;
		}
		const url = '/api/companysites/deletecompany?companyid=' + id;
		const result = await fetch(url, {
			method: 'DELETE',
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		if (result.ok) {
			refreshData();
		}
	}

	function handleDialogCanceled(event: CustomEvent) {
		dialog.dismissDialog();
		contextSite = undefined;
	}

	async function handleSubmit(event: CustomEvent) {
		let site = contextSite;
		if (!site) {
			return;
		}
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
				Authorization: `Bearer ${data.user.token}`
			}
		});
		if (response.ok) {			
			await invalidateAll();
			fireSaveSuccessToast();
			dialog.dismissDialog();
		} else {
			fireSaveErrorToast();
		}

		isLoading = false;
	}

	async function refreshData() {
		isBusy = true;
		await invalidateAll();
		isBusy = false;
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
	<DataTable on:addnew={addNewCompany} on:refresh={refreshData} allowSearch={false}>
		<span slot="title">
			<i class="bi bi-buildings" />
			<span> Companies </span>
		</span>

		<tr slot="header">
			<DataTableCell isHeader={true}>Name</DataTableCell>
			<DataTableCell isHeader={true}>Shift start time</DataTableCell>
			<DataTableCell isHeader={true}>Shift end time</DataTableCell>
			<DataTableCell isHeader={true} width={100}></DataTableCell>
		</tr>
		{#each sites as site (site.id)}
			<DataTableRow>
				<DataTableCell>
					<Button buttonStyle="link" type="button" on:click={() => editCompany(site)}>
						{site.companyName}
					</Button>
				</DataTableCell>
				<DataTableCell>
					{site.shiftStartHours}:{site.shiftStartMinutes}
				</DataTableCell>
				<DataTableCell>
					{site.shiftEndHours}:{site.shiftEndMinutes}
				</DataTableCell>
				<DataTableCell>
					<DataTableMenuButton
						on:delete={() => deleteCompany(site.id)}
						on:edit={() => editCompany(site)}
					/>
				</DataTableCell>
			</DataTableRow>
		{/each}
	</DataTable>
</div>

<ModalDialog
	bind:this={dialog}
	on:cancel={handleDialogCanceled}
	on:submit={handleSubmit}
	busy={isLoading}
>
	<span slot="title">
		{contextSite?.id !== 0 ? 'Edit Site' : 'Add Site'}
	</span>
	{#if contextSite}
		<div class="py-2">
			<LabeledInput
				label="Site Name"
				required={true}
				id="companyNameInput"
				name="companyName"
				bind:value={contextSite.companyName}
			/>

			<LabeledSelect
				id="timeZonesSelect"
				validationText="Please select timezone"
				required={true}
				labelText="Time Zone Offset"
				bind:value={contextSite.tzOffset}
			>
				<option value="">---Timezone Offset---</option>
				{#each offsets as offset (offset)}
					<option value={offset} selected={contextSite.tzOffset === offset}>
						{getOffsetString(offset)}
					</option>
				{/each}
			</LabeledSelect>
			<div class="grid grid-cols-2 gap-2 my-1">
				<div>
					<span class=" text-slate-500 block mb-1"> Shift Start Time </span>
					<div class="grid grid-cols-2 gap-2">
						<LabeledInput
							id="shiftStartTimeInput"
							placeholder="HH"
							bind:value={contextSite.shiftStartHours}
							isNumeric={true}
							min={0}
							max={23}
							validationText="Invalid value"
						/>
						<LabeledInput
							id="shiftEndTimeInput"
							placeholder="MM"
							bind:value={contextSite.shiftStartMinutes}
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
							bind:value={contextSite.shiftEndHours}
							isNumeric={true}
							min={0}
							max={23}
							validationText="Invalid value"
						/>
						<LabeledInput
							id="shiftEndTimeInput"
							placeholder="MM"
							bind:value={contextSite.shiftEndMinutes}
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
					bind:checked={contextSite.enableEmailNotifications}
				/>
				<ToggleButton
					label="Enable alarm notifications"
					bind:checked={contextSite.enableAlarmNotifications}
				/>
			</div>
			<!-- <div class="grid grid-cols-2 gap-2 my-2">
			<FormButton role="primary" on:click={saveChanges} disabled={isLoading}>
				<i class="bi bi-floppy-fill" />
				Save
			</FormButton>
			<FormButton
				role="secondary"
				on:click={() => cancelDialogInternal(false)}
				disabled={isLoading}>Cancel</FormButton
			>
		</div> -->
		</div>
	{/if}
</ModalDialog>

<!-- {#if contextSite !== undefined}
	<CompanySiteEditor
		site={contextSite}
		token={data.user.token}
		on:dialogClosed={handleDialogClosed}
	/>
{/if} -->
