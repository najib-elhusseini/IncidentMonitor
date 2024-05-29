<script lang="ts">
	import { createEventDispatcher, onMount } from 'svelte';
	import LabeledInput from './LabeledFormInput.svelte';
	export let labelText: string | undefined = undefined;
	export let id: string | undefined = undefined;
	export let readonly: boolean = false;
	export let required: boolean = false;
	export let value: string | number | undefined = undefined;
	export let name: string | undefined = undefined;
	export let placeholder: string | undefined = undefined;
	export let validationText: string | undefined = undefined;
	export let classList: string = '';
	export let customValidation: (() => Boolean) | undefined = undefined;
	export let rows: number = 5;
	// export let customValidation:()=>boolean = ()=> true

	const dispatch = createEventDispatcher();
	let input: HTMLTextAreaElement;
	let isValid: boolean = true;

	function handleValidated(event: CustomEvent) {		
		if (customValidation) {
			isValid = event.detail && customValidation();
		} else {
			isValid = event.detail;
		}
	}
	function validateElement() {
		if (input.dataset.validated !== 'true') {
			return;
		}
		
		isValid = input.checkValidity();
		
		dispatch('validated', isValid);
		
	}

	onMount(() => {
		input.addEventListener('change', validateElement);
		input.addEventListener('validate--custom', validateElement);
	});
</script>

<LabeledInput
	{labelText}
	{id}
	{validationText}
	{isValid}
	{name}
	{required}
	{placeholder}
	on:validated={handleValidated}
>
	<textarea
		bind:this={input}
		class="border peer block w-full py-1 pl-2 pr-7
                rounded-md shadow-sm bg-white text-neutral-900
                focus:outline-none focus:ring read-only:bg-neutral-100
                placeholder:text-sm placeholder:font-thin
                dark:bg-slate-900 dark:text-neutral-100 appearance-none
                {!isValid
			? 'border-pink-600 dark:border-pink-500 focus:ring-pink-600/20 dark:focus:ring-pink-600/40'
			: 'dark:border-slate-600 border-slate-300 focus:ring-sky-500/20 dark:focus:ring-sky-500/30'}
                {classList}"
		bind:value
		{id}
		{name}
		{required}
		{placeholder}
		{readonly}
		{rows}
		data-requires-validation={required}
	/>
</LabeledInput>
