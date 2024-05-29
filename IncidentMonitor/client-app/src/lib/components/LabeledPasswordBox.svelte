<script lang="ts">
	import { onMount, createEventDispatcher } from 'svelte';

	const dispatch = createEventDispatcher();

	export let value: string | number | undefined = undefined;
	export let id: string;
	export let name: string | undefined = undefined;
	export let required = false;
	export let label: string | undefined = undefined;
	export let placeholder: string | undefined = undefined;

	export let min: number | undefined = undefined;
	export let max: number | undefined = undefined;
	export let validationText: string | undefined = 'Please enter a valid password';

	export let passwordVisible = false;
	let isValid: boolean = true;

	function handleValueChanged(event: Event) {
		validate();
		dispatch('change', { originalEvent: event });
	}

	function validate() {
		if (required && !value) {
			isValid = false;
		} else {
			isValid = true;
		}
	}

	let element: HTMLInputElement;

	function switchView() {
		if (passwordVisible) {
			element.type = 'password';
			passwordVisible = false;
		} else {
			passwordVisible = true;
			element.type = 'text';
		}
	}

	onMount(() => {
		validate();
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
		<input
			bind:this={element}
			{id}
			{name}
			{required}
			{placeholder}
			{min}
			{max}
			type="password"
            data-required={required}
			bind:value
			class="border border-slate-300 pl-2 pr-10 py-1.5 w-full rounded-md
           focus:outline-none focus:ring ring-indigo-500/20
           invalid:border-red-500 invalid:ring-red-500/20
           disabled:bg-slate-100 disabled:text-slate-300 peer"
			on:change={handleValueChanged}
		/>
		<div class="absolute right-0 inset-y-0 flex w-10">
			<button
				type="button"
				class="flex-grow text-slate-400 hover:text-slate-600 focus:outline-none"
				on:click={switchView}
			>
				<i class="bi bi-{passwordVisible ? 'eye-fill' : 'eye-slash-fill'}" />
			</button>
		</div>
	</div>
	<div class="{isValid ? 'hidden' : 'block'} text-sm text-red-500">
		{validationText}
	</div>
</div>
