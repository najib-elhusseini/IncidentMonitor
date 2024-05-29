<script lang="ts">
	import { onMount, createEventDispatcher } from 'svelte';

	export let labelText: string | undefined = undefined;
	export let id: string | undefined = undefined;
	export let readonly: boolean = false;
	export let required: boolean = false;
	export let value: Date | undefined = undefined;
	export let name: string | undefined = undefined;
	export let placeholder: string | undefined = undefined;
	export let validationText: string | undefined = undefined;
	export let autocomplete: string | undefined = 'off';
	export let input: HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement | any | undefined =
		undefined;
	// export let autoApplyCss: boolean = false;
	export let customCss: string = '';
	export let visible: boolean = true;
	export let inputType: 'date' | 'datetime' = 'datetime';
	export let disabled = false;
	let _value: string = '';
	function padZero(num: number) {
		return num > 9 ? `${num}` : `0${num}`;
	}
	$: {
		if (value) {
			if(typeof value==="string"){
				value = new Date(value);
				
			}
			const year = value.getFullYear();
			const month = value.getMonth() + 1; // zero based index
			const day = value.getDate();
			_value = `${year}-${padZero(month)}-${padZero(day)}`;
		}
	}

	const dispatch = createEventDispatcher();

	export let isValid = true;

	let inputContainer: HTMLDivElement;

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

	function handleChange(event: Event) {
		const target = event.target as HTMLInputElement;
		_value = target.value;
		if (_value === '' || _value === undefined) {
			value = undefined;
			dispatch('dateChanged', {
				date: undefined
			});
			return;
		}
		const parts = _value.split('-');
		const year = Number(parts[0]);
		const month = Number(parts[1]);
		const dayOfMonth = Number(parts[2]);
		const _date = new Date(year, month - 1, dayOfMonth);

		value = _date;
		dispatch('dateChanged', {
			date: _date
		});
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
		}
		if (inputType === 'date' && input) {
			input.type = 'date';
		}
	});
</script>

<div class="{visible ? '' : 'hidden'}">
	{#if labelText}
		<label for={id} class="inline-block mb-1 text-slate-600 dark:text-neutral-200">
			{labelText}
			{#if required}
				*
			{/if}
		</label>
	{/if}
	<div bind:this={inputContainer}>
		<input
			bind:this={input}
			{disabled}
			{id}
			type="datetime"			
			{required}
			{autocomplete}
			class="border peer block w-full py-1 px-2 rounded-md shadow-sm bg-white text-neutral-900
						focus:outline-none focus:ring read-only:bg-neutral-100
						placeholder:text-sm placeholder:font-thin
						dark:bg-slate-900 dark:text-neutral-100
                        {!isValid
				? 'border-pink-600 dark:border-pink-500 focus:ring-pink-600/20 dark:focus:ring-pink-600/40'
				: 'dark:border-slate-600 border-slate-300 focus:ring-sky-500/20 dark:focus:ring-sky-500/30'}
                        {customCss}"
			value={_value}
			{placeholder}
			{name}
			on:change={handleChange}
			{readonly}
		/>
	</div>

	{#if validationText && !isValid}
		<div class="text-sm text-pink-600 dark:text-pink-500 my-2">
			{validationText}
		</div>
	{/if}
</div>
