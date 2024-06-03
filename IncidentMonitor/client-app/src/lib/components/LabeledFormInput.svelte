<script lang="ts">
	import { onMount, createEventDispatcher } from 'svelte';

	export let labelText: string | undefined = undefined;
	export let id: string | undefined = undefined;
	export let readonly: boolean = false;
	export let required: boolean = false;
	export let value: string | number | undefined = undefined;
	export let name: string | undefined = undefined;
	export let placeholder: string | undefined = undefined;
	export let validationText: string | undefined = 'This field is required'; 
	export let autocomplete: string | undefined = 'off';
	export let input: HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement | any | undefined =
		undefined;
	export let autoApplyCss: boolean = false;
	export let customCss: string = '';
	export let visible: boolean = true;
	export let numeric: boolean = false;
	export let allowZero: boolean = false;
	export let disabled = false;

	const dispatch = createEventDispatcher();

	export let isValid = true;

	let inputContainer: HTMLDivElement;

	function validateElement(event: Event) {
		if (input.dataset.validated !== 'true') {
			return;
		}
		isValid = input.checkValidity();
		if (input.type === 'number') {
			if (!allowZero && value === 0 && required) {
				isValid = false;
			}
		}
		dispatch('validated', isValid);
	}

	onMount(() => {
		if (id === undefined) {
			let r = (Math.random() + 1).toString(36).substring(2);
			id = `input${r}`;
		}

		let elem = inputContainer.querySelector('input') as HTMLElement;

		if (elem) {
			elem!.dataset.requiresValidation = 'true';
			input = elem;
			elem.addEventListener('change', validateElement);
			elem.addEventListener('validate--custom', validateElement);
			if (id) {
				elem.id = id;
			}

			let _input = elem as HTMLInputElement;
			if (_input) {
				_input.name = name ?? '';
				_input.placeholder = placeholder ?? '';
			}

			if (autoApplyCss) {
				elem.className = `border peer  block w-full py-1 px-2 rounded-md shadow-sm bg-white text-neutral-900
						focus:outline-none focus:ring  read-only:bg-neutral-100
						placeholder:text-sm placeholder:font-thin
						dark:bg-slate-900 dark:text-neutral-100
			            ${
										!isValid
											? 'border-pink-600 dark:border-pink-500 focus:ring-pink-600/20 dark:focus:ring-pink-600/40'
											: 'dark:border-slate-600 border-slate-300 focus:ring-sky-500/20 dark:focus:ring-sky-500/30'
									} ${customCss}`;
			}
		}
		if (numeric && input) {
			input.type = 'number';
		}
	});
</script>

<div class={visible ? '' : 'hidden'}>
	{#if labelText}
		<label for={id} class="inline-block mb-1 text-slate-600 dark:text-neutral-200">
			{labelText}
			{#if required}
				*
			{/if}
		</label>
	{/if}
	<div bind:this={inputContainer}>
		<slot>
			<input
				bind:this={input}
				{disabled}
				{id}
				type="text"
				{required}
				{autocomplete}
				class="border peer block w-full py-1 px-2 rounded-md shadow-sm bg-white text-neutral-900
						focus:outline-none focus:ring read-only:bg-neutral-100
						placeholder:text-sm placeholder:font-thin
						dark:bg-slate-900 dark:text-neutral-100 {numeric ? 'hide-browser-appearance' : ''}
                        {!isValid
					? 'border-pink-600 dark:border-pink-500 focus:ring-pink-600/20 dark:focus:ring-pink-600/40'
					: 'dark:border-slate-600 border-slate-300 focus:ring-sky-500/20 dark:focus:ring-sky-500/30'}
                        {customCss}"
				bind:value
				{placeholder}
				{name}
				on:change
				on:keydown
				on:keyup
				{readonly}
				step={numeric ? 'any' : undefined}
			/>
		</slot>
	</div>

	{#if validationText && !isValid}
		<div class="text-xs text-pink-600 dark:text-pink-500 my-1">
			{validationText}
		</div>
	{/if}
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
