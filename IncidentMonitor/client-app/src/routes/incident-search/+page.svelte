<script lang="ts">
	import Header from '$lib/components/Header.svelte';
	import type { RemedyForceHistoryEntry, RemedyForceIncident } from '$lib/models/remedy_force.js';	
	import { downloadJsonFile } from '$lib/code-gen/code-gen-helper.js';
	import Button from '$lib/components/Button.svelte';
	import { stringEquals } from '$lib/helpers/string-helper.js';

	export let data;
	let months = [1, 2, 3, 4]; //, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
	let isLoading = false;
	// let dateFrom: Date;
	// let dateTo: Date;
	let incidents: RemedyForceIncident[] = [];
	type IncidentHistoryPresenter = {
		incidentId?: string;
		histories?: RemedyForceHistoryEntry[];
	};
	let month: number = 1;
	let year: number = 2022;
	let openIncidents = true;

	// async function getIncidents(Event: Event) {
	// 	incidents = [];
	// 	const url = `/api/remedyforceincidents/getincidentsinmonth?year=${year}&month=${month}`;
	// 	isLoading = true;
	// 	const response = await fetch(url, {
	// 		method: 'GET',
	// 		headers: {
	// 			Authorization: `Bearer ${data.user.token}`
	// 		}
	// 	});
	// 	if (response.ok) {
	// 		const data: RemedyForceIncident[] = await response.json();
	// 		incidents = data;
	// 	}

	// 	isLoading = false;
	// }

	async function getIncidentHistories(Event: Event) {
		const url = `/api/remedyforceincidents/getIncidentsHistoric?openIncidents=${openIncidents}&year=${year}&period=${month}`;
		isLoading = true;
		const response = await fetch(url, {
			method: 'GET',
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		if (response.ok) {
			const data: RemedyForceIncident[] = await response.json();
			incidents = data;
		}

		isLoading = false;
	}

	function downloadJson() {
		const incidentQueue: RemedyForceIncident[] = [];
		const crimQueue: RemedyForceIncident[] = [];
		const incidentHistories: IncidentHistoryPresenter[] = [];
		const crimHistories: IncidentHistoryPresenter[] = [];
		for (const incident of incidents) {
			if (
				stringEquals(incident.BMCServiceDesk__queueName__c, 'CRIM Queue') ||
				incident.CRIM__c === true ||
				stringEquals(incident.BMCServiceDesk__Queue__c, 'CRIM Queue')
			) {
				crimQueue.push(incident);
				crimHistories.push({
					incidentId: incident.Name!,
					histories: incident.BMCServiceDesk__Incident_Histories__r
				});
				continue;
			}
			// for all others just add to incident queue
			incidentQueue.push(incident);
			incidentHistories.push({
				incidentId: incident.Name!,
				histories: incident.BMCServiceDesk__Incident_Histories__r
			});

			// if (incident.BMCServiceDesk__queueName__c === 'Incident Queue') {

			// }
		}
		downloadJsonFile(
			incidentQueue,
			(openIncidents ? 'OPEN__' : 'HISTORIC__') + 'Incident_Queue_' + month + '_' + year
		);
		downloadJsonFile(
			crimQueue,
			(openIncidents ? 'OPEN__' : 'HISTORIC__') + 'CRIM_Queue_' + month + '_' + year
		);
		downloadJsonFile(
			incidentHistories,
			(openIncidents ? 'OPEN__' : 'HISTORIC__') + 'Incident_Histories_' + month + '_' + year
		);
		downloadJsonFile(
			crimHistories,
			(openIncidents ? 'OPEN__' : 'HISTORIC__') + 'CRIM_Histories_' + month + '_' + year
		);

		// navigator.clipboard.writeText(JSON.stringify(incidents));
	}
</script>

<div class="h-screen flex flex-col">
	<Header user={data.user} {isLoading}>
		<div class="flex w-full">
			<div class="mx-auto my-auto space-x-2 flex">
				<label>
					<span class="text-slate-600 mr-1"> Year </span>
					<select
						class="px-2 py-1 border border-slate-300 rounded-md focus:outline-none"
						bind:value={year}
					>
						<option value={2022}>2022</option>
						<option value={2023}>2023</option>
						<option value={2024}>2024</option>
					</select>
				</label>
				<label>
					<span class="text-slate-600 mr-1"> Month </span>
					<select
						class="px-2 py-1 border border-slate-300 rounded-md focus:outline-none"
						bind:value={month}
					>
						{#each months as month (month)}
							<option value={month}>{month}</option>
						{/each}
					</select>
				</label>

				<!-- <button
					disabled={isLoading}
					type="button"
					class="bg-indigo-500 rounded-md text-indigo-50 min-w-[120px] px-2 flex-grow
                    hover:bg-indigo-600 focus:outline-none focus:ring
                    active:ring ring-indigo-600/20 transition-all ease-in-out
                    disabled:bg-slate-100 disabled:text-slate-300
                    "
					on:click={getIncidents}
				>
					<span> Get Incidents in month </span>
				</button> -->

				<button
					disabled={isLoading}
					type="button"
					class="bg-indigo-500 rounded-md text-indigo-50 min-w-[120px] px-2 flex-grow
                    hover:bg-indigo-600 focus:outline-none focus:ring
                    active:ring ring-indigo-600/20 transition-all ease-in-out
                    disabled:bg-slate-100 disabled:text-slate-300
                    "
					on:click={getIncidentHistories}
				>
					<span> Get {openIncidents ? 'open' : 'closed'} Incidents</span>
				</button>
				<Button type="button" href="/task-search">Get Tasks</Button>
				<label class="my-auto">
					<input type="checkbox" bind:checked={openIncidents} />
					Open Incidents
				</label>
			</div>
		</div>
	</Header>
	<div class="text-right">
		<button
			on:click={downloadJson}
			type="button"
			disabled={incidents.length === 0 || isLoading}
			class="px-2 py-1.5 focus:outline-none hover:underline hover:text-indigo-500 disabled:text-slate-300"
		>
			<span> Export JSON </span>
		</button>
		<!-- <button
			on:click={exportHistoriesJson}
			type="button"
			disabled={incidents.length === 0}
			class="px-2 py-1.5 focus:outline-none hover:underline hover:text-indigo-500 disabled:text-slate-300"
		>
			<span> Export Histories JSON </span>
		</button> -->
	</div>
	<div class="p-2 flex-grow overflow-y-scroll">
		<div></div>
		<!-- <table class="border border-slate-300 w-full">
			<thead>
				<tr class="border-b border-b-slate-300 bg-neutral-500 text-neutral-50">
					<th
						class="text-left px-2 py-2 border-r
					border-r-slate-300 last-of-type:border-r-0"
					>
						#
					</th>
					<th
						class="text-left px-2 py-2 border-r
					border-r-slate-300 last-of-type:border-r-0 w-[40px]"
					>
						<i class="bi bi-headset"></i>
					</th>
					<th
						class="text-left px-2 py-2 border-r
					border-r-slate-300 last-of-type:border-r-0"
					>
						Title
					</th>
					<th
						class="text-left px-2 py-2 border-r
					border-r-slate-300 last-of-type:border-r-0"
					>
						User
					</th>
					<th
						class="text-left px-2 py-2 border-r
					border-r-slate-300 last-of-type:border-r-0"
					>
						Queue
					</th>
					<th
						class="text-left px-2 py-2 border-r
					border-r-slate-300 last-of-type:border-r-0"
					>
						Client
					</th>
					<th
						class="text-left px-2 py-2 border-r
					border-r-slate-300 last-of-type:border-r-0"
					>
						Created At
					</th>
					<th
						class="text-left px-2 py-2 border-r
					border-r-slate-300 last-of-type:border-r-0"
					>
						Status
					</th>
				</tr>
			</thead>
			<tbody>
				{#each incidents as incident}
					<IncidentRow {incident} />
				{/each}
			</tbody>
		</table> -->
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
					Incidents : {incidents.length}
				{/if}
			</div>
			<div class="ml-auto"></div>
		</div>
	</footer>
</div>
