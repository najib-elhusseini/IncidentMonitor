<script lang="ts">
	import LabeledInput from './LabeledFormInput.svelte';
	export let labelText: string | undefined = undefined;
	export let id: string;
	export let readonly: boolean = false;
	export let required: boolean = true;
	export let value: string | number | undefined = undefined;
	export let name: string | undefined = undefined;
	export let placeholder: string | undefined = undefined;
	export let validationText: string | undefined = undefined;
	export let classList: string = '';
	export let customValidation: (() => Boolean) | undefined = undefined;
	// export let customValidation:()=>boolean = ()=> true

	let input: HTMLInputElement;
	let isValid: boolean = true;

	let inputType: 'text' | 'password' = 'password';

	function handleValidated(event: CustomEvent) {
		if (customValidation) {
			isValid = event.detail && customValidation();
		} else {
			isValid = event.detail;
		}
	}

	function toggleInputType() {
		inputType = inputType === 'password' ? 'text' : 'password';
		input.type = inputType;
	}
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
	<div class="relative group">
		<input
			type="password"
			bind:this={input}
			class="border peer block w-full py-1 pl-2 pr-7
                        rounded-md shadow-sm bg-white text-neutral-900
						focus:outline-none focus:ring read-only:bg-neutral-100
						placeholder:text-sm placeholder:font-thin
						dark:bg-slate-900 dark:text-neutral-100 appearance-none
                        {!isValid
				? 'border-pink-600 dark:border-pink-500 focus:ring-pink-600/20 dark:focus:ring-pink-600/40'
				: 'dark:border-slate-600 border-slate-300 focus:ring-sky-500/20 dark:focus:ring-sky-500/30'}
                        {classList}
                        "
			{placeholder}
			{id}
			{name}
			{readonly}
			{required}
			bind:value
			on:change
		/>

		<button
			type="button"
			class="absolute top-0 right-0 w-8 px-1 pt-1
		text-slate-500 hover:text-teal-600 active:text-teal-700 focus:outline-none"
			on:click={toggleInputType}
		>
			<i class="bi {inputType === 'password' ? 'bi-eye-fill' : 'bi-eye-slash-fill'}" />
		</button>
	</div>
</LabeledInput>
