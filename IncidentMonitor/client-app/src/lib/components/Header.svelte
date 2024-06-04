<script lang="ts">
	import type { User } from '$lib/stores/user_store';
	import UserMenu from './UserMenu.svelte';

	export let user: User;
	export let isLoading: boolean = false;
</script>

<header class="p-2 bg-white border-b border-b-slate-400 shadow-md flex">
	<div class="flex">
		<a href="/">
			<img
				src="/resources/images/hoist_gear.png"
				alt="HOIST GEAR"
				width="64"
				height="64"
				class="object-scale-down my-auto"
			/></a
		>
		<div class="px-2 my-auto">
			<h1 class="text-xl font-bold text-slate-700">Incident Monitor</h1>
		</div>
	</div>
	<div class="flex-grow flex">
		<slot />
	</div>
	<div class="my-auto flex">
		<UserMenu {user} disabled={isLoading} />
	</div>
</header>
