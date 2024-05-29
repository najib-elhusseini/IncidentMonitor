<script lang="ts">
	import { onMount, createEventDispatcher } from 'svelte';

	export let labelText: string | undefined = undefined;
	export let id: string | undefined = undefined;
	export let required: boolean = false;
	export let value: string | number | undefined = undefined;
	export let name: string | undefined = undefined;
	export let placeholder: string | undefined = undefined;
	export let validationText: string | undefined = undefined;

	export let input: HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement | any | undefined =
		undefined;
	// export let autoApplyCss: boolean = false;

	export let visible: boolean = true;

	export let disabled = false;

	const dispatch = createEventDispatcher();

	export let isValid = true;

	let inputContainer: HTMLElement;
	let select: HTMLSelectElement;

	function validateElement(event: Event) {
		if (input.dataset.validated !== 'true') {
			return;
		}
		isValid = input.checkValidity();
		if (input.type === 'number') {
			console.clear();
			console.log(value, isValid);
		}
		dispatch('validated', isValid);
	}

	onMount(() => {
		if (id === undefined) {
			let r = (Math.random() + 1).toString(36).substring(2);
			id = `select${r}`;
		}
		let elem = inputContainer.querySelector('select') as HTMLElement;

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
		}
	});
</script>

<div bind:this={inputContainer} class=" {visible ? '' : 'hidden'}">
	{#if labelText}
		<label for={id} class="mb-1 block text-slate-600 dark:text-neutral-200">
			{labelText}
			{#if required}
				*
			{/if}
		</label>
	{/if}
	<div class="relative">
		<select
			bind:this={select}
			{disabled}
			{id}
			{required}
			bind:value
			{placeholder}
			{name}
			on:change
			class="border peer block w-full py-1 px-2 rounded-md shadow-sm bg-white text-neutral-900
                focus:outline-none focus:ring
                placeholder:text-sm placeholder:font-thin
                dark:bg-slate-900 dark:text-neutral-100 appearance-none
                {!isValid
				? 'border-pink-600 dark:border-pink-500 focus:ring-pink-600/20 dark:focus:ring-pink-600/40'
				: 'dark:border-slate-600 border-slate-300 focus:ring-sky-500/20 dark:focus:ring-sky-500/30'}
				disabled:bg-slate-100 disabled:text-slate-300 disabled:border-slate-300
                "
		>
			<slot />
		</select>
		<label
			for={id}			
			class="absolute right-0 inset-y-0 w-10 flex text-slate-500
            peer-hover:text-blue-500 peer-focus:text-blue-500 {disabled ? "text-slate-300" :""}"
		>
			<i class="bi bi-chevron-down m-auto"></i>
		</label>
	</div>

	{#if validationText && !isValid}
		<div class="text-sm text-pink-600 dark:text-pink-500 my-2">
			{validationText}
		</div>
	{/if}
</div>
