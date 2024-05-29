<script lang="ts">
	import CardHeader from "./CardHeader.svelte";

	export let isCard = true;
	export let showHeader=true;
</script>

<div class="p-2 {isCard ? 'border border-slate-300 shadow-md rounded-md bg-white' : ''}">
	{#if showHeader}
		<CardHeader>
			<slot name="title" />
		</CardHeader>
	{/if}
	
	<slot />
</div>
