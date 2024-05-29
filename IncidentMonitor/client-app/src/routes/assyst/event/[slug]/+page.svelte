<script lang="ts">
	import Button from '$lib/components/Button.svelte';
	import ButtonsToolbar from '$lib/components/ButtonsToolbar.svelte';
	import DataTableCell from '$lib/components/DataTableCell.svelte';
	import DataTableRow from '$lib/components/DataTableRow.svelte';
	import Header from '$lib/components/Header.svelte';

	import LabeledFormInput from '$lib/components/LabeledFormInput.svelte';
	import { formatDate } from '$lib/helpers/date-helper.js';
	import type { ActionDto } from '$lib/models/event-action.js';
	import { fireSuccessToast } from '$lib/swal_helper';
	import { readonly } from 'svelte/store';

	export let data;
	let event = data.event;
	let isLoading = false;
	let loggedInDate: string = '';
	let client: string = '';
	let selectedActions: ActionDto[] = [];
	$: {
		if (event.dateLogged) {
			loggedInDate = formatDate(event.dateLogged);
		}

		client = event.department?.section?.name ?? '';
	}

	function checkSelected(action: ActionDto): boolean {
		for (const selectedAction of selectedActions) {
			if (selectedAction.id === action.id) {
				return true;
			}
		}
		return false;
	}

	function toggleSelected(action: ActionDto) {
		let _actions: ActionDto[] = [];
		let exists = false;
		for (const selectedAction of selectedActions) {
			if (selectedAction.id === action.id) {
				exists = true;
				continue;
			}
			_actions.push(selectedAction);
		}
		console.log(exists);
		if (!exists) {
			_actions.push(action);
		}

		selectedActions = [..._actions];
		event.actions = [...(event.actions ?? [])];
	}

	async function postActionsToFreshService() {
		const url = '/api/integrations/postactionstofreshservice';
		const ids = [];
		for (const selectedAction of selectedActions) {
			ids.push(selectedAction.id);
		}
		const formData = new FormData();
		formData.append('userReference', event.userReference ?? '');
		formData.append('ids', JSON.stringify(ids));
		const response = await fetch(url, {
			method: 'POST',
			headers: {
				Authorization: `Bearer ${data.user.token}`
			},
			body: formData
		});
		if (response.ok) {
			fireSuccessToast('Actions posted with success');
		}
	}

	async function postActionsToCarrixServiceNow() {
		const url = '/api/integrations/carrixpostactionstoservicenow';
		const ids = [];
		for (const selectedAction of selectedActions) {
			ids.push(selectedAction.id);
		}
		const formData = new FormData();
		formData.append('userReference', event.userReference ?? '');
		formData.append('ids', JSON.stringify(ids));
		const response = await fetch(url, {
			method: 'POST',
			headers: {
				Authorization: `Bearer ${data.user.token}`
			},
			body: formData
		});
		if (response.ok) {
			fireSuccessToast('Actions posted with success');
		}
	}
</script>

<Header user={data.user} {isLoading}></Header>

<div class="p-2 md:p-10 lg:p-16">
	{#if event.serviceOffering}
		<div class="text-xs text-indigo-600">
			{event.serviceOffering.name ?? ''}
		</div>
	{/if}
	<h3 class="text-lg font-bold text-indigo-600">
		#{event.formattedReference}
	</h3>
	<div class="grid grid-cols-5 gap-4">
		<LabeledFormInput
			value={event.affectedUserName}
			labelText="Affected User Name"
			readonly={true}
		/>
		<LabeledFormInput
			value={event.affectedUserEmail}
			labelText="Affected User Email"
			readonly={true}
		/>

		<LabeledFormInput value={loggedInDate} labelText="Date Logged" readonly={true} />
		<LabeledFormInput value={client} labelText="Client" readonly={true} />
		<LabeledFormInput value={event.userReference} labelText="User Reference" readonly={true} />
	</div>

	{#if event.actions}
		<div class="my-2">
			<h3 class="my-2 text-xl py-2 border-b border-b-slate-300">Actions</h3>
			{#if event.affectedUserId === 712}
				<div class="text-right">
					<Button type="button" buttonStyle="link" on:click={postActionsToFreshService}>
						Post selected actions
					</Button>
				</div>
			{/if}
			{#if event.affectedUserId === 714 || event.departmentId === 43}
				<div class="text-right">
					<Button type="button" buttonStyle="link" on:click={postActionsToCarrixServiceNow}>
						Post selected actions
					</Button>
				</div>
			{/if}
			<div class="border border-slate-300 bg-white rounded-lg overflow-clip">
				<table class="w-full">
					<thead class="bg-gray-500 text-gray-50 border-b-2 border-b-gray-700">
						<tr>
							<DataTableCell isHeader={true} width={50}>#</DataTableCell>
							<DataTableCell isHeader={true}>Action</DataTableCell>
							<DataTableCell isHeader={true} width={75}>Date</DataTableCell>
							<DataTableCell isHeader={true}>User</DataTableCell>
						</tr>
					</thead>
					<tbody>
						{#each event.actions as action (action.id)}
							<DataTableRow>
								<DataTableCell>
									<!-- {action.id} -->
									<button
										type="button"
										class="text-blue-500"
										on:click={() => toggleSelected(action)}
									>
										{#if checkSelected(action)}
											<i class="bi bi-check-circle-fill"></i>
										{:else}
											<i class="bi bi-circle" />
										{/if}
									</button>
								</DataTableCell>
								<DataTableCell>
									<div class="font-bold">
										{action.actionType?.name}
									</div>
									{#if action.richRemarks}
										<div class="text-sm break-words">
											{@html action.richRemarks?.content ??
												action.richRemarks.plainTextContent ??
												''}
										</div>
									{/if}
								</DataTableCell>
								<DataTableCell>
									<span class="text-sm ">
										{#if action.dateActioned}
											{formatDate(action.dateActioned, 'short', 'short')}
										{/if}
									</span>
								</DataTableCell>
								<DataTableCell>
									<div class="w-fit">
										<span class="whitespace-nowrap lowercase">
											{action.modifyId}
										</span>
									</div>
								</DataTableCell>
							</DataTableRow>
						{/each}
					</tbody>
				</table>
			</div>
		</div>
	{/if}
</div>
