<script lang="ts">
	import { createEventDispatcher, onDestroy, onMount } from 'svelte';

	const dispatch = createEventDispatcher();

	export let data: any[] = [];
	export let dataKey: string = 'id';
	export let labelKey: string;
	let dataFiltered: any[] = [];

	$: {
		if (data.length > 0) {
			filterData();
		}
	}

	export let labelText: string | undefined = undefined;
	export let id: string | undefined = undefined;
	export let readonly: boolean = false;
	export let required: boolean = false;
	export let value: string | number | undefined = undefined;
	export let name: string | undefined = undefined;
	export let placeholder: string | undefined = undefined;
	export let validationText: string | undefined = undefined;

	export let visible: boolean = true;
	export let menuHeight = 200;

	export let disabled = false;
	let isValid = true;
	let input: HTMLInputElement;
	let menu: HTMLDivElement;

	let isOpen = false;

	function selectItem(item: any) {
		if (value !== item[labelKey]) {
			value = item[labelKey];
			dispatch('selectionchanged', { item: item });
		}
	}

	function handleItemClicked(item: any) {
		isOpen = false;
		selectItem(item);
		filterData();
	}

	function handleFocusIn(event: FocusEvent) {
		isOpen = true;
	}

	function handleFocusOut(event: FocusEvent) {
		if (event.relatedTarget) {
			const element = event.relatedTarget as HTMLElement;
			if (element) {
				if (element.dataset.ddItem === 'true') {
					return;
				}
			}
		}
		isOpen = false;
	}

	function handleTextChanged(event: Event) {}

	function filterData() {
		if (!value) {
			dataFiltered = data;
			return;
		}
		const valueLowered = `${value}`.toLowerCase();
		dataFiltered = [];
		for (const dataItem of data) {
			const label = `${dataItem[labelKey]}`.toLowerCase();
			if (label.includes(valueLowered)) {
				dataFiltered.push(dataItem);
			}
			if (label === valueLowered) {
				selectItem(dataItem);
			}
		}

		dataFiltered = [...dataFiltered];
	}

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
			id = `input${r}`;
		}
		input.dataset.requiresValidation = 'true';

		input.addEventListener('change', validateElement);
		input.addEventListener('validate--custom', validateElement);

		filterData();
	});
</script>

<div class={visible ? '' : 'hidden'}>
	{#if labelText}
		<span class="inline-block mb-1 text-slate-600 dark:text-neutral-200 focus:outline-none">
			{labelText}
			{#if required}
				*
			{/if}
		</span>
	{/if}
	<div class="relative group">
		<input
			autocomplete="off"
			bind:this={input}
			type="text"
			{id}
			{name}
			{readonly}
			{placeholder}
			bind:value
			{required}
			{disabled}
			class="border peer block w-full py-1 pl-2 pr-8 rounded-md shadow-sm bg-white text-neutral-900
        focus:outline-none focus:ring read-only:bg-neutral-100
        placeholder:text-sm placeholder:font-thin
        dark:bg-slate-900 dark:text-neutral-100
        {!isValid
				? 'border-pink-600 dark:border-pink-500 focus:ring-pink-600/20 dark:focus:ring-pink-600/40'
				: 'dark:border-slate-600 border-slate-300 focus:ring-sky-500/20 dark:focus:ring-sky-500/30'}
        "
			on:focusin={handleFocusIn}
			on:focusout={handleFocusOut}
			on:change={handleTextChanged}
			on:keyup={filterData}
		/>
		{#if data && data.length}
			<button
				type="button"
				data-dd-item="true"
				on:click={() => (isOpen = !isOpen)}
				on:focusout={handleFocusOut}
				class="absolute right-0 w-8 inset-y-0 text-slate-500 hover:text-blue-500
				rotate-0 {isOpen ? 'rotate-180' : ''} 
				transition-all ease-in-out duration-300 flex cursor-pointer outline-none
				focus:outline-none
				"
			>
				<i class="bi bi-chevron-down m-auto block" />
			</button>

			<div
				class="absolute left-0 right-0 min-h-[150px]
				bg-white border rounded-md mt-1 py-1
				border-slate-400 overflow-y-scroll
				shadow-md z-[1001] {isOpen ? 'grid' : 'hidden'} transition-all ease-in-out"
				bind:this={menu}
			>
				<ul style="height: {menuHeight}px;">
					{#each dataFiltered as dataItem (dataItem[dataKey])}
						<li>
							<button
								data-dd-item="true"
								type="button"
								data-checked={value === dataItem[labelKey] ? 'true' : 'false'}
								class="group px-2 py-1 text-slate-700 text-sm flex w-full outline-none
								hover:text-blue-500 transition-all ease-in-out focus:outline-none"
								on:click={() => handleItemClicked(dataItem)}
							>
								<span class="pointer-events-none">
									{dataItem[labelKey]}
								</span>
								<i
									class="bi bi-check2 hidden group-data-[checked='true']:block ml-auto pointer-events-none"
								/>
							</button>
						</li>
					{/each}
				</ul>
			</div>
		{/if}
	</div>
	{#if validationText && !isValid}
		<div class="text-xs text-pink-600 dark:text-pink-500 my-1">
			{validationText}
		</div>
	{/if}
</div>
