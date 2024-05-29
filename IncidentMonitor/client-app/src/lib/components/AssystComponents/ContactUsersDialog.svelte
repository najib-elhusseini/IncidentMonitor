<script lang="ts">
	import type { ContactUserDto } from '$lib/models/assyst-user';
	import type { User } from '$lib/stores/user_store';
	import SearchModalDialog from '../SearchModalDialog.svelte';

	export let departmentId: number | undefined = undefined;
	export let loggedInUser: User;
	let users: ContactUserDto[] = [];
	let usersFiltered: ContactUserDto[] = [];
	let isLoading = false;
	let queryText = '';

	$: {
		if (departmentId === undefined || departmentId <= 0) {
		} else {
			getContactUsers();
		}
	}

	function handleQueryChanged(event: CustomEvent) {
		const query = event.detail.query as string;
		queryText = query;
		filterUsers();
	}

	function filterUsers() {
		console.log(queryText);
		if (queryText === '') {
			usersFiltered = [...users];
			return;
		}
		let _users = [];
		for (const user of users) {
			if (user.name?.includes(queryText) || user.emailAddress?.includes(queryText)) {
				_users.push(user);
			}
		}
		usersFiltered = _users;
	}

	async function getContactUsers() {
		if ((departmentId === undefined || departmentId === 0) && !queryText) {
			return;
		}

		const url = `/api/assystinfrastructure/getcontactUsers?departmentIds=${departmentId}`;
		users = [];
		isLoading = true;

		// return;
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${loggedInUser.token}`
			}
		});
		if (response.ok) {
			const _contacts: ContactUserDto[] = await response.json();
			users = _contacts;
			filterUsers();
		}
		isLoading = false;
	}
</script>

<SearchModalDialog buttonLabel="Search contact users" on:queryChanged={handleQueryChanged}>
	<div class="divide-y">
		{#each usersFiltered as user (user.id)}
			<div class="bg-white odd:bg-slate-50 py-1">
				<div>
					{user.name}
				</div>
                {#if user.emailAddress}
				<span class="text-sm">({user.emailAddress})</span>
                {/if}
			</div>
		{/each}
	</div>
</SearchModalDialog>
