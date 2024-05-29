<script lang="ts">
	import { createEventDispatcher } from 'svelte';

	export let isChecked = false;
	export let value: number | string | undefined = undefined;

	const dispatch = createEventDispatcher();

	function handleCheckChanged() {
		isChecked = !isChecked;
		dispatch('checkchanged', { isChecked, value });
	}
</script>

<button
	type="button"
	data-checked={isChecked}
	on:click={handleCheckChanged}
	class="text-slate-500 hover:text-blue-500 data-[checked='true']:text-blue-500"
>
	{#if isChecked}
		<i class="bi bi-check-circle-fill"></i>
	{:else}
		<i class="bi bi-circle"></i>
	{/if}
</button>
