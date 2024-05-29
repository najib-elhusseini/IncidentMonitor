<script lang="ts">
	import { downloadJsonFile } from '$lib/code-gen/code-gen-helper.js';
	import Button from '$lib/components/Button.svelte';
	import Header from '$lib/components/Header.svelte';
	import { stringEquals } from '$lib/helpers/string-helper.js';
	import type { RemedyForceTask, TaskHistory } from '$lib/models/remedy_force';

	type TaskHistoryPresenter = {
		taskId?: string;
		histories?: TaskHistory[];
	};

	export let data;
	let isLoading = false;
	let tasks: RemedyForceTask[] = [];
	let getOpenTasks = false;
	let message = 'Click on the Get Tasks button to continue!';

	async function getTasks(Event: Event) {
		tasks = [];

		let startDate = new Date();
		const url = `/api/remedyforceincidents/gettasks?getOpenTasks=${getOpenTasks}`;
		isLoading = true;
		message = '';
		const response = await fetch(url, {
			method: 'GET',
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		if (response.ok) {
			const data: RemedyForceTask[] = await response.json();
			tasks = data;
		}
		let endDate = new Date();
		let ellapsed = endDate.getTime() - startDate.getTime();
		isLoading = false;
		message = `Fetching done, ${tasks.length} records found.<br/>Time ellapsed(ms) : ${ellapsed} <br/>Time ellapsed(s) :${ellapsed / 1000} Seconds.`;
	}

	function exportTasks() {
		let _tasks: RemedyForceTask[] = [];
		let histories: TaskHistoryPresenter[] = [];

		let _crimTasks: RemedyForceTask[] = [];
		let _crimTaskHistories: TaskHistoryPresenter[] = [];
		for (const task of tasks) {
			let incident = task.BMCServiceDesk__FKIncident__r;
			if (!incident) {
				continue;
			}

			if (
				stringEquals(incident.BMCServiceDesk__queueName__c, 'CRIM Queue') ||
				incident.CRIM__c === true ||
				stringEquals(incident.BMCServiceDesk__Queue__c, 'CRIM Queue')
			) {
				_crimTasks.push({ ...task, TaskHistories: [] });
				_crimTaskHistories.push({
					taskId: task.Name! ?? task.Id,
					histories: task.TaskHistories
				});
				continue;
			}

			_tasks.push({ ...task, TaskHistories: [] });
			histories.push({
				taskId: task.Name! ?? task.Id,
				histories: task.TaskHistories
			});
		}

		downloadJsonFile(_tasks, `incident_tasks_${getOpenTasks ? 'open' : 'historic'}`);
		downloadJsonFile(histories, `incident_task_histories_${getOpenTasks ? 'open' : 'historic'}`);

		downloadJsonFile(_crimTasks, `crim_tasks_${getOpenTasks ? 'open' : 'historic'}`);
		downloadJsonFile(
			_crimTaskHistories,
			`crim_task_histories_${getOpenTasks ? 'open' : 'historic'}`
		);
	}
</script>

<Header user={data.user} {isLoading}>
	<div class="my-auto space-x-4">
		<Button buttonStyle="primary" on:click={getTasks} disabled={isLoading}>Get Tasks</Button>
		<Button buttonStyle="success" disabled={tasks.length === 0} on:click={exportTasks}>
			<span> Export Tasks </span>
		</Button>
		<label>
			<input type="checkbox" bind:checked={getOpenTasks} />
			<span> Get open tasks </span>
		</label>
	</div>
</Header>

<div class="p-2 flex">
	{#if isLoading}
		<h3 class="mx-auto text-2xl font-bold text-slate-800 animate-pulse">
			Loading tasks,please wait...
		</h3>
	{:else}
		<h3 class="mx-auto text-2xl font-bold text-slate-800">
			{@html message}
		</h3>
	{/if}
</div>
