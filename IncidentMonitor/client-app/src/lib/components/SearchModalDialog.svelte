<script lang="ts">
	import type { KeyValuePair } from '$lib/models/keyvaluepair';
	import { createEventDispatcher, onDestroy, onMount } from 'svelte';
	import ModalDialog from './ModalDialog.svelte';
	import SearchBar from './SearchBar.svelte';
	import EventRow from './EventRow.svelte';
	const dispatch = createEventDispatcher();

	export let buttonLabel: string = 'Search';
	export let buttonVisible: boolean = true;
	export let busy: boolean = false;

	let dialog: ModalDialog;
	// let isDiaogOpen = false;
	let query: string = '';

	export function openDialog() {
		dialog.openDialog();
	}
	export function dismissDialog() {
		dialog.dismissDialog();
	}

	function queryTextChanged() {
		dispatch('queryChanged', {
			query
		});
	}

	function handleSearchTextBoxKeyDown(event:KeyboardEvent){
		if(event.key==="Enter"){
			event.stopImmediatePropagation();
			event.stopPropagation();
			event.preventDefault();
			queryTextChanged();
		}
		
	}

	function handleKeyUp() {
		if (query === '') {
			queryTextChanged();
		}
	}

	function handleDocumentKeyUp(event: KeyboardEvent) {
		if (event.key.toLowerCase() === 'escape') {
			dismissDialog();
		}
	}

	onMount(() => {
		document.addEventListener('keyup', handleDocumentKeyUp);
	});

	onDestroy(() => {
		document.removeEventListener('keyup', handleDocumentKeyUp);
	});
</script>

{#if buttonVisible}
	<button
		type="button"
		class="bg-white h-12 rounded-lg border border-slate-300 text-slate-500
    focus:outline-none active:border-2 active:border-blue-500 focus:border-2 focus:border-blue-500
    flex px-2"
		on:click={openDialog}
	>
		<div class="my-auto space-x-2">
			<i class="bi bi-search"></i>
			<span>
				{buttonLabel}
			</span>
		</div>
	</button>
{/if}

<ModalDialog
	{busy}
	bind:this={dialog}
	on:cancel={dismissDialog}
	on:submit
	allowSubmit={true}
	showCloseButton={false}
>
	<div slot="title" class="flex-grow flex text-base space-x-1">
		<div class="my-auto">
			<i class="bi bi-search"></i>
		</div>
		<div class="grid flex-grow">
			<input
				disabled={busy}
				type="text"
				bind:value={query}
				placeholder={buttonLabel}
				class="p-1 text-base focus:outline-none disabled:text-slate-400"
				on:change={queryTextChanged}
				on:keyup={handleKeyUp}
				on:keydown={handleSearchTextBoxKeyDown}
			/>
		</div>
		<div class="my-auto">
			<button
				on:click={dismissDialog}
				type="button"
				class="text-xs font-bold border border-slate-300 rounded px-1.5 py-1
				shadow hover:bg-slate-50 bg-white active:shadow-none"
			>
				ESC
			</button>
		</div>
	</div>
	<div class="h-[300px] overflow-y-scroll mt-1.5 pr-2">
		<slot />
	</div>
</ModalDialog>
