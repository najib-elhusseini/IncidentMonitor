<script lang="ts">
	import { createEventDispatcher, onMount } from 'svelte';

	export let value: string | number | null | undefined = undefined;
	export let id: string;
	export let name: string | undefined = undefined;
	export let required = false;
	export let label: string | undefined = undefined;
	export let placeholder: string | undefined = undefined;
	export let validationText: string | undefined = '';

	const dispatch = createEventDispatcher();
	let isValid = true;

	function handleValueChanged(event?: Event) {
		if (event) {
			dispatch('change', {
				originalEvent: event
			});
		}

		if (required === false) {
			isValid = true;

			return;
		}
		isValid = element.value !== null && element.value !== undefined && element.value !== '';
	}

	let element: HTMLSelectElement;

	onMount(() => {
		handleValueChanged(undefined);
	});
</script>

<div class="my-1">
	{#if label}
		<label for={id} class="block text-slate-500 mb-2">
			{label}
			{#if required}
				<i class="bi bi-asterisk text-sm ml-1"></i>
			{/if}
		</label>
	{/if}
	<div class="relative">
		<select
			bind:this={element}
			{id}
			{name}
			{required}
			{placeholder}
			bind:value
			on:change={handleValueChanged}
			class="border border-slate-300 px-2 py-1.5 w-full rounded-md
           focus:outline-none focus:ring ring-indigo-500/20
           invalid:border-red-500 invalid:ring-red-500/20
           disabled:bg-slate-100 disabled:text-slate-300 peer appearance-none"
		>
			<slot />
		</select>
		<span
			class="absolute right-0 inset-y-0 text-slate-500
				peer-hover:peer-valid:text-indigo-500
				peer-active:peer-valid:text-indigo-500 pointer-events-none
				peer-invalid:text-red-500
					w-10 flex"
		>
			<i class="bi bi-chevron-compact-down block m-auto"></i>
		</span>
	</div>
	<div class="{isValid ? 'invisible' : 'block'} text-sm text-red-500">
		{validationText}
	</div>
</div>
