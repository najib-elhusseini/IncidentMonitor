<script lang="ts">
	import { invalidateAll } from '$app/navigation';
	import CompanySiteEditor from '$lib/admin/CompanySiteEditor.svelte';

	import type { Company } from '$lib/models/company_site.js';
	import { fireDeleteConfirmationDialog } from '$lib/swal_helper.js';
	import { onMount } from 'svelte';

	export let data;
	let sites: Company[] = [];
	$: {
		sites = data.sites;
	}
	let contextSite: Company | undefined = undefined;
	let isBusy = true;

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

	function handleDialogClosed(event: CustomEvent) {
		let cancel = event.detail.cancel as boolean;
		contextSite = undefined;
		if (cancel) {
			return;
		}
		refreshData();
	}

	async function refreshData() {
		isBusy = true;
		await invalidateAll();
		isBusy = false;
	}

	onMount(() => {});
</script>

<div>
	<div class="bg-slate-100 p-2 md:py-3 lg:py-4 border-b border-b-slate-300 shadow">
		<button
			on:click={addNewCompany}
			type="button"
			class="text-slate-600 hover:text-indigo-500 active:text-indigo-600 px-2 py-1.5
		 rounded-sm"
		>
			<i class="bi bi-plus-circle-fill" />
			<span> New Site </span>
		</button>
		<button
			on:click={refreshData}
			type="button"
			class="text-slate-600 hover:text-indigo-500 active:text-indigo-600 px-2 py-1.5
		 rounded-sm"
		>
			<i class="bi bi-arrow-clockwise"></i>
			<span> Refresh </span>
		</button>
	</div>
	<div class="p-2">
		<div class="border border-slate-300 rounded-md overflow-clip">
			<table class=" w-full border-collapse">
				<thead>
					<tr class="bg-slate-600 text-slate-50 border-b-2 border-b-slate-900">
						<th class="px-2 py-1.5 border-r border-r-slate-300 text-left"> Site </th>
						<th class="px-2 py-1.5 border-r border-r-slate-300 text-left"> Shift Start </th>
						<th class="px-2 py-1.5 border-r border-r-slate-300 text-left"> Shift End </th>
						<th class="w-[70px]"> </th>
					</tr>
				</thead>
				<tbody>
					{#each sites as site (site.id)}
						<tr class="border-b border-b-slate-300 last-of-type:border-b-0">
							<td class="border-r border-r-slate-300 px-2 py-1.5">
								<button
									on:click={() => (contextSite = site)}
									type="button"
									class="text-indigo-500 hover:text-indigo-600 hover:underline focus:outline-none"
								>
									{site.companyName}
								</button>
							</td>
							<td class="border-r border-r-slate-300 px-2 py-1.5">
								{site.shiftStartHours}:{site.shiftStartMinutes}
							</td>
							<td class="border-r border-r-slate-300 px-2 py-1.5">
								{site.shiftEndHours}:{site.shiftEndMinutes}
							</td>
							<td class="px-2 py-1.5 text-center">
								<button
									type="button"
									class="text-red-500 hover:text-red-600 focus:outline-none"
									on:click={() => {
										deleteCompany(site.id);
									}}
								>
									<i class="bi bi-trash3-fill"></i>
								</button>
							</td>
						</tr>
					{/each}
				</tbody>
			</table>
		</div>
	</div>
</div>

{#if contextSite !== undefined}
	<CompanySiteEditor
		site={contextSite}
		token={data.user.token}
		on:dialogClosed={handleDialogClosed}
	/>
{/if}
