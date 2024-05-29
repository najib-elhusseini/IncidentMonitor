<script lang="ts">
	import { goto } from '$app/navigation';
	import Header from '$lib/components/Header.svelte';
	import SettingsButton from '$lib/components/SettingsButton.svelte';
	import { loggedInUser, type User } from '$lib/stores/user_store';
	import { onDestroy, onMount } from 'svelte';

	let localUser: User | undefined;
	let isLoading = false;

	const unsubscribe = loggedInUser.subscribe((u) => {
		if (u.userName === '') {
			localUser = undefined;
		} else {
			localUser = u;
		}
	});

	onMount(() => {
		if (localUser === undefined) {
			goto('/login');
		}
		if (!localUser?.isAdmin) {
			goto('/status?code=403');
		}
	});
	onDestroy(() => {
		unsubscribe();
	});
</script>

{#if localUser}
	<div class="flex flex-col h-screen">
		<Header user={localUser} {isLoading}></Header>
		<div class="flex-grow flex flex-row">
			<div class="w-96 md:w-[250px] bg-slate-100 border-r border-r-slate-300 p-1">
				<SettingsButton destination="users">
					<i class="bi bi-people-fill"></i>
					<span class="">App Users </span>
				</SettingsButton>
				<SettingsButton destination="companies">
					<i class="bi bi-buildings-fill"></i>
					<span class=""> Companies </span>
				</SettingsButton>

				<SettingsButton destination="assyst">
					<i class="bi bi-sliders"></i>
					<span class="">IFS Assyst </span>
				</SettingsButton>				
				<SettingsButton destination="smtp-config">
					<i class="bi bi-envelope-at-fill"></i>
					<span> SMTP Configuration </span>
				</SettingsButton>				
			</div>
			<div class="flex-grow">
				<slot />
			</div>
		</div>
	</div>
{/if}
