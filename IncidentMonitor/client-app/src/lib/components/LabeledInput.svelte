<script lang="ts">
	import { onMount } from 'svelte';

	export let value: string | number | undefined = undefined;
	export let id: string;
	export let name: string | undefined = undefined;
	export let required = false;
	export let label: string | undefined = undefined;
	export let placeholder: string | undefined = undefined;
	export let isNumeric = false;
	export let min: number | undefined = undefined;
	export let max: number | undefined = undefined;
	export let validationText: string | undefined = 'This field is required';

	let element: HTMLInputElement;

	onMount(() => {
		if (isNumeric) {
			element.type = 'number';
		}
		if (label && !placeholder) {
			placeholder = label;
		}
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
	<input
		bind:this={element}
		{id}
		{name}
		{required}
		{placeholder}
		{min}
		{max}
		type="text"
		bind:value
		data-required={required}
		class="border border-slate-300 px-2 py-1.5 w-full rounded-md
           focus:outline-none focus:ring ring-indigo-500/20
           invalid:border-red-500 invalid:ring-red-500/20
           disabled:bg-slate-100 disabled:text-slate-300 peer"
	/>
	<div class="hidden peer-invalid:block text-sm text-red-500">
		{validationText}
	</div>
</div>
