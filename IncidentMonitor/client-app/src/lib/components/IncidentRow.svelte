<script lang="ts">
	import { IncidentespondedStatus, type RemedyForceIncident } from '$lib/models/remedy_force';
	import type { User } from '$lib/stores/user_store';

	// export let user: User;
	export let incident: RemedyForceIncident;

	function getDate(literal?: string): string {
		if (literal === undefined) return 'N/A';
		let date = new Date(literal);
		const dateFormatted = Intl.DateTimeFormat(undefined, {
			dateStyle: 'medium'
		}).format(date);
		const timeFormatted = Intl.DateTimeFormat(undefined, {
			timeStyle: 'short'
		}).format(date);
		return `<div class="">${dateFormatted}</div><div class="">${timeFormatted}</div>`;
	}

	function getUrl(incident: RemedyForceIncident): string | undefined {
		const div = document.createElement('div');
		div.innerHTML = incident.BMCServiceDesk__Launch_console__c ?? '';
		const link = div.querySelector('a');
		if (link) {
			const location = window.location.toString();
			let url = link?.href.replace(location, '');

			return `${incident.InstanceUrl}/${url}`;
		}
		return undefined;
	}
</script>

<tr class="border-b border-b-slate-300 last-of-type:border-b-0 bg-white odd:bg-slate-50">
	<td
		class="text-left px-2 py-2 border-r
    border-r-slate-300 last-of-type:border-r-0 text-sm"
	>
		<a
			href={getUrl(incident)}
			class="hover:underline hover:text-indigo-500 outline-indigo-500 px-1"
			target="_blank"
		>
			IN{incident.Name}
		</a>
	</td>
	<td
		class="text-left px-2 py-2 border-r
    border-r-slate-300 last-of-type:border-r-0"
	>
		{#if incident.IncidentStatus === IncidentespondedStatus.RespondedInShift || incident.IncidentStatus === IncidentespondedStatus.RespondedNotInShift}
			<i class="bi bi-check2-circle text-emerald-500" />
		{:else}
			<i
				class="bi bi-exclamation-circle {incident.IncidentStatus ===
				IncidentespondedStatus.UnrespondedInShift
					? 'text-red-500'
					: 'text-yellow-300'}"
			/>
		{/if}
	</td>
	<td
		class="text-left px-2 py-2 border-r
    border-r-slate-300 last-of-type:border-r-0 text-sm"
	>
		{incident.Title__c}
	</td>
	<td
		class="text-left px-2 py-2 border-r
    border-r-slate-300 last-of-type:border-r-0 text-sm"
	>
		{incident.BMCServiceDesk__FKClient__r?.Name ?? incident.BMCServiceDesk__FKClient__r?.Username}
	</td>
	<td
		class="text-left px-2 py-2 border-r
    border-r-slate-300 last-of-type:border-r-0 text-sm"
	>
		{incident.BMCServiceDesk__queueName__c}
	</td>
	<td
		class="text-left px-2 py-2 border-r
    border-r-slate-300 last-of-type:border-r-0 text-sm"
	>
		{incident.BMCServiceDesk__Client_Account__c ?? 'N/A'}
	</td>
	<td
		class="text-left px-2 py-2 border-r
    border-r-slate-300 last-of-type:border-r-0 text-sm whitespace-nowrap"
	>
		{@html getDate(incident.CreatedDate)}
	</td>
	<td
		class="text-left px-2 py-2 border-r
    border-r-slate-300 last-of-type:border-r-0 text-sm"
	>
		{incident.BMCServiceDesk__FKStatus__r?.Name ?? 'ERR'}
	</td>
</tr>
