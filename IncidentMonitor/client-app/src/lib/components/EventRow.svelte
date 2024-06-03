<script lang="ts">
	import { getEventFormattedStatus, type EventDto } from '$lib/models/assyst-event';
	import type { UserDto } from '$lib/models/assyst-user';
	import { IncidentespondedStatus } from '$lib/models/remedy_force';
	import type { User } from '$lib/stores/user_store';
	import { createEventDispatcher, onMount } from 'svelte';
	import DataTableCell from './DataTableCell.svelte';
	import DataTableMenuButton from './DataTableMenuButton.svelte';
	import DataTableRow from './DataTableRow.svelte';
	import DatePresenter from './DatePresenter.svelte';
	import LabeledSelect from './LabeledSelect.svelte';
	import LabeledTextArea from './LabeledTextArea.svelte';
	import ModalDialog from './ModalDialog.svelte';
	import { AssystEventActionTypes, eventStatus } from '$lib/models/assyst';
	import HyperLink from './HyperLink.svelte';

	const dispatch = createEventDispatcher();

	export let event: EventDto;
	export let user: User;
	let assystUsers: UserDto[] = [];

	let dialog: ModalDialog;
	let externalUserId = user.externalId ?? '-1';
	let shortCode: string | undefined = undefined;
	let isLoadingUsers = false;

	async function showEventActionDialog(actionTypeId: AssystEventActionTypes) {
		dispatch('createaction', { event, actionTypeId });
	}
</script>

<DataTableRow>
	<DataTableCell>
		<HyperLink href="/assyst/event/{event.id}">
			{event.formattedReference}
		</HyperLink>
	</DataTableCell>
	<DataTableCell>
		{#if event.eventAcknowledgedStatus === IncidentespondedStatus.RespondedInShift || event.eventAcknowledgedStatus === IncidentespondedStatus.RespondedNotInShift || event.eventAcknowledgedStatus === IncidentespondedStatus.CallbackNotRequired}
			<i class="bi bi-check2-circle text-emerald-500" />
		{:else}
			<i
				class="bi bi-exclamation-diamond-fill {event.eventAcknowledgedStatus ===
				IncidentespondedStatus.UnrespondedInShift
					? 'text-red-500'
					: 'text-yellow-400'}"
			/>
		{/if}
	</DataTableCell>
	<DataTableCell>
		{event.shortDescription}
	</DataTableCell>
	<DataTableCell>
		<span>{event.affectedUserName}</span>
		<small class="block text-sm">
			{event.affectedUserEmail}
		</small>
	</DataTableCell>
	<DataTableCell>
		{event.assignedServDept?.name ?? ''}
	</DataTableCell>
	<DataTableCell>
		{event.assignedUser?.name ?? 'N/A'}
	</DataTableCell>
	<DataTableCell>
		{event.department?.section?.name ?? event.department?.sectionDepartmentName}
	</DataTableCell>
	<DataTableCell>
		{#if event.dateLogged}
			<DatePresenter date={event.dateLogged} /> 
		{/if}
	</DataTableCell>
	<DataTableCell>
		<span class="whitespace-nowrap">
			{getEventFormattedStatus(event)}
		</span>
	</DataTableCell>
	<DataTableCell>
		<DataTableMenuButton menuWidth={250} showDelete={false} showEdit={false}>
			<li>
				<button
					type="button"
					data-menu-item="true"
					disabled={event.acknowledged || event.eventStatusEnum !== 'OPEN'}
					on:click={(evt) =>
						showEventActionDialog(AssystEventActionTypes.AcknowledgmentActionTypeId)}
				>
					<i class="bi bi-check2-circle"></i>
					<span> Acknowledge </span>
				</button>
			</li>
			<li>
				<button
					type="button"
					data-menu-item="true"
					disabled={event.eventStatusEnum !== 'OPEN'}
					on:click={(evt) => showEventActionDialog(AssystEventActionTypes.CommentActionTypeId)}
				>
					<i class="bi bi-stopwatch"></i>
					<span> Comment </span>
				</button>
			</li>
			<li>
				<hr />
			</li>
			<li class="whitespace-nowrap">
				{#if !event.lastSlaClockStop}
					<button
						type="button"
						data-menu-item="true"
						disabled={event.eventStatusEnum !== 'OPEN'}
						on:click={(evt) =>
							showEventActionDialog(AssystEventActionTypes.WaitingOnCustomerInputActionTypeId)}
					>
						<i class="bi bi-stopwatch"></i>
						<span> Waiting on customer </span>
					</button>
				{:else}
					<button
						type="button"
						data-menu-item="true"
						disabled={event.eventStatusEnum !== 'OPEN'}
						on:click={(evt) =>
							showEventActionDialog(AssystEventActionTypes.CustomerInputReceivedActionTypeId)}
					>
						<i class="bi bi-chat-dots"></i>
						<span> Customer Input Received </span>
					</button>
				{/if}
			</li>
		</DataTableMenuButton>
	</DataTableCell>
</DataTableRow>
<!-- 
<ModalDialog bind:this={dialog} on:cancel={hideAcknowlededDialog} on:submit={handleSubmit}>
	<span slot="title"> Send Acknowledgement </span>

	<div class="my-4 grid gap-y-2">
		<input type="hidden" name="eventId" value={event.id} />
		<LabeledTextArea labelText="Description" required={true} name="remarks"></LabeledTextArea>
		<LabeledSelect
			labelText="Assyst User"
			value={externalUserId}
			disabled={isLoadingUsers}
			on:change={handleAssysUserChanged}
		>
			<option value="-1"> ---Select User--- </option>
			{#each assystUsers as _user (_user.id)}
				<option value={_user.id}>
					{_user.name}
				</option>
			{/each}
		</LabeledSelect>
	</div>
</ModalDialog> -->
