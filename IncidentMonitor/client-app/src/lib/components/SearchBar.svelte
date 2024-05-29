<script lang="ts">
	import { onMount, createEventDispatcher } from 'svelte';

	export let id: string | undefined = undefined;
	export let readonly: boolean = false;
	export let disabled = false;
	export let value: string | undefined = undefined;
	export let name: string | undefined = undefined;
	export let placeholder: string | undefined = 'Search';
	export let autocomplete: string | undefined = 'off';
	export let visible: boolean = true;
	export let changeTrigger: 'change' | 'enter' = 'enter';
	export let showClearTextButton = true;

	const dispatch = createEventDispatcher();

	function handleChange(event: Event) {
		if (changeTrigger === 'change') {
			dispatch('change', {
				value
			});
		}
	}
	function handleKeyDown(event: KeyboardEvent) {
		if (changeTrigger === 'enter') {
			if (event.key === 'Enter') {
				event.stopImmediatePropagation();
				event.stopPropagation();
				event.preventDefault();
				dispatch('change', {
					value
				});
			}
		}
	}

	function resetValue() {
		value = '';
		dispatch('change', { value });
	}
</script>

<div class="my-1 {visible ? '' : 'hidden'}">
	<div class="relative flex">
		<input
			type="text"
			{disabled}
			{id}
			{autocomplete}
			class="border peer block w-full py-1 pl-8 pr-8 rounded-md shadow-sm bg-white text-neutral-900
						focus:outline-none focus:ring read-only:bg-neutral-100
						placeholder:text-sm placeholder:font-thin
						dark:bg-slate-900 dark:text-neutral-100 hide-browser-appearance
                        dark:border-slate-600 border-slate-300 focus:ring-sky-500/20 dark:focus:ring-sky-500/30
                        "
			bind:value
			{placeholder}
			{name}
			on:change={handleChange}
			on:keydown={handleKeyDown}
			{readonly}
		/>
		<div class="absolute inset-y-0 w-8 left-0 flex">
			<i class="bi bi-search text-slate-300 m-auto" />
		</div>
		{#if showClearTextButton}
			<button
				on:click={resetValue}
				type="button"
				class="absolute right-0 w-8 text-slate-400 hover:text-red-500 px-2 inset-y-0 transition-colors ease-in-out"
			>
				<i class="bi bi-x-circle-fill" />
			</button>
		{/if}
	</div>
</div>

<style>
	.hide-browser-appearance {
		/* -moz-appearance: textfield; */
		appearance: none;
	}

	.hide-browser-appearance::-webkit-outer-spin-button,
	.hide-browser-appearance::-webkit-inner-spin-button {
		/* -webkit-appearance: none; */
		appearance: none;
	}
</style>
