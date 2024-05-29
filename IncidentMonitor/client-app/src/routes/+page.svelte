<script lang="ts">
	import { goto } from '$app/navigation';
	import { AssystEventActionTypes } from '$lib/models/assyst';
	import AssystActionEdit from '$lib/components/AssystActionEdit.svelte';
	import DataTable from '$lib/components/DataTable.svelte';
	import DataTableCell from '$lib/components/DataTableCell.svelte';

	import EventRow from '$lib/components/EventRow.svelte';
	import Header from '$lib/components/Header.svelte';

	import ModalDialog from '$lib/components/ModalDialog.svelte';

	import type { EventDto } from '$lib/models/assyst-event';
	import type { AssystUserDto } from '$lib/models/assyst-user';

	import { IncidentespondedStatus, type RemedyForceIncident } from '$lib/models/remedy_force';
	import { loggedInUser, type User } from '$lib/stores/user_store';
	import { fireSaveErrorToast, fireSaveSuccessToast } from '$lib/swal_helper';
	import { onDestroy, onMount } from 'svelte';
	import Link from '$lib/components/HyperLink.svelte';

	let localUser: User | undefined;

	export let data;
	let incidents: EventDto[] = [];
	let isLoading = false;
	let timeInterval: number | undefined = undefined;
	let withinShift_unrespondedCount: number = 0;
	let withinShift_respondedCount: number = 0;
	let notWithn_unrespondedCount: number = 0;
	let notWithin_respondedCount: number = 0;
	let forceRefresh = false;
	let dialog: ModalDialog;
	let isLoadingUsers: boolean = false;
	let assystUsers: AssystUserDto[] = [];
	let externalUserId = data.user.externalId ?? '-1';
	let externalUserShortCode: string | undefined = undefined;
	let contextEvent: EventDto | undefined = undefined;
	let isSavingEvent = false;
	let timeOut: number = 60000;
	let contextActionType: AssystEventActionTypes | undefined = undefined;

	const unsubscribe = loggedInUser.subscribe((u) => {
		if (u.userName === '') {
			localUser = undefined;
		} else {
			localUser = u;
		}
	});

	async function refresh() {
		if (timeInterval !== undefined) {
			clearInterval(timeInterval);
		}
		forceRefresh = true;
		await startInterval();
	}

	async function getAssystIncidents() {
		let url = '/api/assyst/getTodayIncidents';
		if (forceRefresh) {
			url = '/api/assyst/refreshincidents';
			forceRefresh = false;
		}

		isLoading = true;
		incidents = [];
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		if (response.ok) {
			const _incidents: EventDto[] = await response.json();
			withinShift_unrespondedCount = 0;
			withinShift_respondedCount = 0;
			notWithn_unrespondedCount = 0;
			notWithin_respondedCount = 0;
			for (const incident of _incidents) {
				if (incident.dateLogged && typeof incident.dateLogged === 'string') {
					try {
						incident.dateLogged = new Date(incident.dateLogged);
					} catch (error) {
						console.log(error);
					}
					switch (incident.eventAcknowledgedStatus) {
						case IncidentespondedStatus.RespondedNotInShift:
							notWithin_respondedCount += 1;
							break;
						case IncidentespondedStatus.RespondedInShift:
							withinShift_respondedCount += 1;
							break;
						case IncidentespondedStatus.UnrespondedInShift:
							withinShift_unrespondedCount += 1;
							break;
						case IncidentespondedStatus.UnsrespondedNotInShift:
							notWithn_unrespondedCount += 1;
							break;
						default:
							break;
					}
				}
			}
			incidents = _incidents;
		}
		isLoading = false;
	}

	function stopInterval() {
		if (timeInterval !== undefined) {
			clearInterval(timeInterval);
			timeInterval = undefined;
		}
	}

	function resumeInterval() {
		timeInterval = setInterval(() => {
			getAssystIncidents();
		}, timeOut);
	}

	async function startInterval() {
		await getAssystIncidents();
		stopInterval();
		resumeInterval();
	}

	async function getUsers() {
		isLoadingUsers = true;
		const url = `/api/users/getassysthelpdeskusers`;
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		isLoadingUsers = false;
		if (response.ok) {
			assystUsers = await response.json();
		}
	}

	async function createEventAction(event: CustomEvent) {
		const _assystEvent = event.detail.event as EventDto;		
		if (!_assystEvent) {
			return;
		}
		
		stopInterval();
		contextEvent = _assystEvent;
		contextActionType = event.detail.actionTypeId;
		
		dialog.openDialog();
	}

	function hideAcknowlededDialog() {
		dialog.dismissDialog();
		setTimeout(() => {
			contextEvent = undefined;
			resumeInterval();
		}, 150);
	}


	async function handleSubmit(evt: CustomEvent) {
		if (!contextEvent) {
			return;
		}

		const body = evt.detail as FormData;
		// if (!externalUserShortCode) {
		// 	return;
		// }
		
		isSavingEvent = true;
		const url = `/api/assyst/posteventaction`;
		const response = await fetch(url, {
			method: 'POST',
			headers: {
				Authorization: `Bearer ${data.user.token}`
			},
			body: body
		});

		if (response.ok) {
			dialog.dismissDialog();
			fireSaveSuccessToast();
			const events: EventDto[] = await response.json();
			incidents = events;
		} else {
			fireSaveErrorToast();
			resumeInterval();
		}
		isSavingEvent = false;
	}

	onMount(() => {
		if (localUser === undefined) {
			goto('/login');
			return;
		}
		getUsers();
		startInterval();
	});
	onDestroy(() => {
		unsubscribe();
	});
</script>

<div class="h-screen flex flex-col">
	<Header user={data.user} {isLoading}>
		<div class="flex w-full">
			<div class="ml-auto my-auto flex space-x-2">
				<!-- <a
					href="/incident-search"
					class="px-2 py-1.5 text-slate-500 hover:text-indigo-600 active:text-indigo-500
							transition-all ease-in-out duration-300
							disabled:text-slate-300"
				>
					<i class="bi bi-search"></i>
					<span>RF Search </span>
				</a>
				 -->
				<Link href="/assyst/event-search">
					<i class="bi bi-search"></i>
					<span>Assyst Event Search </span>
				</Link>

			</div>
		</div>
	</Header>

	<div class="p-2 flex-grow overflow-y-scroll">
		<DataTable
			allowAdd={false}
			allowSearch={false}
			showSearch={false}
			on:refresh={() => refresh()}
			isBusy={isLoading}
		>
			<span slot="title"> Incidents </span>
			<tr slot="header">
				<DataTableCell isHeader={true} width={75}>#</DataTableCell>
				<DataTableCell isHeader={true}>
					<i class="bi bi-headset"></i>
				</DataTableCell>
				<DataTableCell isHeader={true}>Title</DataTableCell>
				<DataTableCell isHeader={true}>Affected User</DataTableCell>
				<DataTableCell isHeader={true}>Queue/SevDept</DataTableCell>
				<DataTableCell isHeader={true}>Assigned User</DataTableCell>
				<DataTableCell isHeader={true}>Client</DataTableCell>
				<DataTableCell isHeader={true}>Created At</DataTableCell>
				<DataTableCell isHeader={true}>Status</DataTableCell>
				<DataTableCell isHeader={true} width={50}></DataTableCell>
			</tr>
			{#each incidents as incident}
				<EventRow event={incident} user={data.user} on:createaction={createEventAction} />
				<!-- <IncidentRow {incident} /> -->
			{/each}
		</DataTable>
	</div>
	<footer class="border-t border-t-slate-300 mt-2 bg-slate-50 shadow-sm">
		<div class="flex px-2 py-1.5 text-xs">
			<div>
				{#if isLoading}
					<div class="flex">
						<svg
							class="animate-spin -ml-1 mr-3 h-4 w-4 text-slate-700"
							xmlns="http://www.w3.org/2000/svg"
							fill="none"
							viewBox="0 0 24 24"
						>
							<circle
								class="opacity-25"
								cx="12"
								cy="12"
								r="10"
								stroke="currentColor"
								stroke-width="4"
							></circle>
							<path
								class="opacity-75"
								fill="currentColor"
								d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"
							></path>
						</svg>
						<span class="text-slate-600"> Loading,please wait... </span>
					</div>
				{:else if incidents.length === 0}
					<span> No incidents... </span>
				{:else}
					<ul class="flex space-x-2">
						<li>
							{incidents.length} Incidents
						</li>
						<li class="text-red-500" title="Unresponded incidents">
							<i class="bi bi-circle-fill" />
							{withinShift_unrespondedCount}
						</li>
						<li class="text-amber-600" title="Unresponded incidents not within shift">
							<i class="bi bi-circle-fill" />
							{notWithn_unrespondedCount}
						</li>
						<li class="text-emerald-600" title="Responded incidents">
							<i class="bi bi-circle-fill text-xs" />
							{withinShift_respondedCount + notWithin_respondedCount}
						</li>
					</ul>
				{/if}
			</div>
			<div class="ml-auto"></div>
		</div>
	</footer>
</div>

<ModalDialog
	bind:this={dialog}
	on:cancel={hideAcknowlededDialog}
	on:submit={handleSubmit}
	busy={isSavingEvent}
>
	<span slot="title"> Send Acknowledgement </span>
	{#if contextEvent && contextActionType}
		<AssystActionEdit
			{assystUsers}
			event={contextEvent}
			{externalUserId}
			eventActionTypeId={contextActionType}
		/>
		<!-- <div class="my-4 grid gap-y-2">
			<input type="hidden" name="eventId" value={contextEvent.id} />
			<LabeledTextArea labelText="Description" required={true} name="remarks"></LabeledTextArea>
			<LabeledSelect
				labelText="Assyst User"
				value={externalUserId}
				disabled={isLoadingUsers}
				on:change={handleAssysUserChanged}
				required={true}
			>
				<option value="-1"> ---Select User--- </option>
				{#each assystUsers as _user (_user.id)}
					<option value={_user.id}>
						{_user.name}
					</option>
				{/each}
			</LabeledSelect>
		</div> -->
	{/if}
</ModalDialog>
