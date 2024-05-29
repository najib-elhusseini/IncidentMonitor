<script lang="ts">
	import DataTable from '$lib/components/DataTable.svelte';
	import DataTableCell from '$lib/components/DataTableCell.svelte';
	import DataTableRow from '$lib/components/DataTableRow.svelte';
	import { formatDate } from '$lib/helpers/date-helper';
	import type { RemedyForceIncident } from '$lib/models/remedy_force.js';
	import { onMount } from 'svelte';
	export let data;
	let incidents: RemedyForceIncident[] = [];
	let isLoading: boolean = false;
	let year = '2022';
	let years: any[] = [
		{
			id: 2022,
			content: '2022',
			action: () => {
				year = '2022';
				getHistoricData();
			}
		},
		{
			id: 2023,
			content: '2023',
			action: () => {
				year = '2023';
				getHistoricData();
			}
		},
		{
			id: 2024,
			content: '2024',
			action: () => {
				year = '2024';
				getHistoricData();
			}
		},
		{
			id: 1,
			content: 'Download CSV',
			action: () => {
				downloadCsv();
			}
		}
	];

	async function getHistoricData() {
		incidents = []
		const url = `/api/remedyforceincidents/gethistoricincidents?year=${year}`;
		isLoading = true;
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		if (response.ok) {
			const result = await response.json();
			incidents = result.incidents;
			console.log(incidents[0]);
		}

		isLoading = false;
	}

	function timeDiff(incident: RemedyForceIncident) {
		let from: Date | string | undefined = incident.CreatedDate;
		let to: Date | string | undefined = incident.BMCServiceDesk__closeDateTime__c;
		if (!from || !to) {
			return 'N/A';
		}
		if (typeof from === 'string') {
			from = new Date(from);
		}
		if (typeof to === 'string') {
			to = new Date(to);
		}
		const diffMillis = to.valueOf() - from.valueOf();

		const diffSeconds = diffMillis / 60;
		const diffMinutes = diffSeconds / 60;
		return diffMinutes;
	}

	function downloadCsv() {
		let csvContent = '';
		let header = ['#', 'Client', 'Created At', 'Closed At', 'Impact/Urgency', 'Status', 'Minutes'];
		const row = header.join(',');
		csvContent += row + '\r\n';

		for (const incident of incidents) {
			let createdAt = (
				incident.CreatedDate ? formatDate(incident.CreatedDate, 'short', 'short') : 'N/A'
			).replace(',', '_');
			let closedAt = (
				incident.BMCServiceDesk__closeDateTime__c
					? formatDate(incident.BMCServiceDesk__closeDateTime__c, 'short', 'short')
					: 'N/A'
			).replace(',', '_');

			let impact_urgency = `Impact : ${incident.BMCServiceDesk__FKImpact__r?.Name ?? 'N/A'}/ Urgency : ${incident.BMCServiceDesk__FKUrgency__r?.Name ?? 'N/A'}`.trim();
			let status = incident.BMCServiceDesk__FKStatus__r?.Name ?? 'N/A';
			let arr = [
				incident.Name,
				incident.BMCServiceDesk__Client_Account__c,
				createdAt,
				closedAt,
				impact_urgency,
				status,
				timeDiff(incident)
			].join(',');
			csvContent = csvContent + arr + '\r\n';
		}

		let blob = new Blob([csvContent], { type: 'data:text/csv;charset=utf-8' });
		let url = URL.createObjectURL(blob);
		const link = document.createElement('a');
		link.href = url;
		link.download = `${year}_data.csv`;

		link.click();
	}

	onMount(() => {
		getHistoricData();
	});
</script>

<div class="p-2">
	<DataTable allowAdd={false} popupMenuItems={years} isBusy={isLoading}>
		<div slot="title">
			<div>Historic Data Search</div>
			<div class="text-base text-slate-500">
				Period : {year}
			</div>
		</div>

		<tr slot="header">
			<DataTableCell isHeader={true} width={75}>#</DataTableCell>
			<DataTableCell isHeader={true}>Client</DataTableCell>
			<DataTableCell isHeader={true}>Created At</DataTableCell>
			<DataTableCell isHeader={true}>Closed At</DataTableCell>
			<DataTableCell isHeader={true}>Impact/Urgency</DataTableCell>
			<DataTableCell isHeader={true}>Status</DataTableCell>
			<DataTableCell isHeader={true}>Minutes</DataTableCell>
		</tr>
		{#each incidents as incident}
			<DataTableRow>
				<DataTableCell>
					IN{incident.Name}
				</DataTableCell>
				<DataTableCell>
					{incident.BMCServiceDesk__Client_Account__c}
				</DataTableCell>
				<DataTableCell>
					{#if incident.CreatedDate}
						{formatDate(incident.CreatedDate)}
					{:else}
						<span> N/A </span>
					{/if}
				</DataTableCell>
				<DataTableCell>
					{#if incident.BMCServiceDesk__closeDateTime__c}
						{formatDate(incident.BMCServiceDesk__closeDateTime__c)}
					{:else}
						<span> N/A </span>
					{/if}
				</DataTableCell>
				<DataTableCell>
					<div class="text-sm">
						<div>
							Impact : {incident.BMCServiceDesk__FKImpact__r?.Name ?? 'N/A'}
						</div>
						<div>
							Urgency: {incident.BMCServiceDesk__FKUrgency__r?.Name ?? 'N/A'}
						</div>
					</div>
				</DataTableCell>
				<DataTableCell>
					{incident.BMCServiceDesk__FKStatus__r?.Name}
				</DataTableCell>
				<DataTableCell>
					{timeDiff(incident)}
				</DataTableCell>
			</DataTableRow>
		{/each}
	</DataTable>
</div>

<!-- 
<table class="w-full">
	<thead>
		<tr>
			<th>#</th>
			<th>Opened At</th>
			<th> Closed At</th>
			<th>Total Work Time</th>
		</tr>
	</thead>
	<tbody>
		{#each result as incident}
			<tr>
				<td>
					IN{incident.Name ?? '-'}
				</td>
				<td>
					{incident.BMCServiceDesk__openDateTime__c ?? '-'}
				</td>
				<td>
					{incident.BMCServiceDesk__closeDateTime__c ?? '-'}
				</td>
				<td>
					{incident.BMCServiceDesk__TotalWorkTime__c ?? '-'}
				</td>
			</tr>
		{/each}
	</tbody>
</table> -->
