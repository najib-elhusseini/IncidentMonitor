<script lang="ts">
	import type { EventDto } from '$lib/models/assyst-event.js';
	import { onMount } from 'svelte';
	import Header from '$lib/components/Header.svelte';

	let event: EventDto | undefined = undefined;
	let isLoading = false;

	async function getEvent() {
		isLoading = true;
		let url = `/api/assyst/getevent?eventId=${data.eventId}`;
		const response = await fetch(url, {
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		if (response.ok) {
			event = await response.json();
		}
		isLoading = false;
	}

	export let data;
	onMount(() => {
		// console.log(data.user);
		getEvent();
	});
</script>

<Header user={data.user} {isLoading} />
<div class="p-2">
	{#if event}
		{event.formattedReference}
	{/if}
</div>
