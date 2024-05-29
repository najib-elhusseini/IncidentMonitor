<script lang="ts">
	import type { KeyValue } from '$lib/models/misc';
	import { createEventDispatcher } from 'svelte';

	const dispacth = createEventDispatcher();
	export let value: string | number | undefined = undefined;
	export let options: KeyValue<string | number, string>[] = [];
	export let labelText: string | undefined = undefined;

	function handleValueChanged(newValue: string | number) {
		value = newValue;
		dispacth('change', {
			value
		});
	}
</script>

<div>
	{#if labelText}
		<span class="mb-1 block text-slate-600 dark:text-neutral-200">
			{labelText}
		</span>
	{/if}
	<div class="grid" style="grid-template-columns: repeat({options.length}, minmax(0, 1fr));">
		{#each options as option}
			<!-- svelte-ignore a11y-role-supports-aria-props -->
			<button
				type="button"
				data-selected={option.key === value ? 'true' : ''}
				on:click={() => handleValueChanged(option.key)}
				class="first:rounded-l-lg border border-blue-500 text-blue-500 last-of-type:rounded-r-lg
		hover:bg-blue-100 active:bg-blue-500 active:text-blue-50 active:ring ring-blue-500/40
				data-[selected='true']:bg-blue-500 data-[selected='true']:text-blue-50
				px-2 py-1 transition-all ease-in-out duration-150
				"
			>
				{@html option.value}
			</button>
		{/each}
	</div>
</div>
