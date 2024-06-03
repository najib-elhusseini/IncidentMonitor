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
	let element: HTMLInputElement;

	function handleValueChanged(event: Event) {		
		dispatch('change', { originalEvent: event });
		validateElement(event);
	}

	// function validate() {
	// 	if (required && !value) {
	// 		isValid = false;
	// 	} else {
	// 		isValid = true;
	// 	}
	// }

	function validateElement(event: Event) {
		if (element.dataset.validated !== 'true') {
			return;
		}
		isValid = element.checkValidity();

		dispatch('validated', isValid);
	}

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
		if (id === undefined) {
			let r = (Math.random() + 1).toString(36).substring(2);
			id = `passwordInput${r}`;
		}
		element.addEventListener('change', validateElement);
		element.addEventListener('validate--custom', validateElement);

		// validate();
	});
</script>

<div class="my-1">
	{#if label}
		<label for={id} class="block text-slate-500 mb-2">
			{label}
			{#if required}
				*
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
			data-requires-validation='true'
			bind:value
			class="border peer block w-full py-1 px-2 rounded-md shadow-sm bg-white text-neutral-900
						focus:outline-none focus:ring read-only:bg-neutral-100
						placeholder:text-sm placeholder:font-thin
						dark:bg-slate-900 dark:text-neutral-100
                        {!isValid
				? 'border-pink-600 dark:border-pink-500 focus:ring-pink-600/20 dark:focus:ring-pink-600/40'
				: 'dark:border-slate-600 border-slate-300 focus:ring-sky-500/20 dark:focus:ring-sky-500/30'}"
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
	<div class="{isValid ? 'hidden' : 'block'} text-xs text-pink-500 my-1">
		{validationText}
	</div>
</div>
