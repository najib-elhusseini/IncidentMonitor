<script lang="ts" context="module">
	export type PopupMenuItem = {
		id: number;
		content: string;
		action: (param?: any | undefined) => {} | any | void;
		disabled?: boolean;
	};
</script>

<script lang="ts">
	import { createEventDispatcher } from 'svelte';

	export let allowAdd: boolean = true;
	export let allowSearch: boolean = true;
	export let showSearch: boolean = true;
	export let isBusy = false;
	export let popupMenuItems: PopupMenuItem[] | undefined = undefined;
	export let hasAdvancedSearch = false;
	export let searchHint = 'Search';
	let isMenuOpen = false;
	let isAdvancedSearchOpen = false;
	let table: HTMLTableElement;

	const dispatch = createEventDispatcher();

	function handleSearchRequested(event: KeyboardEvent) {
		const target = event.target as HTMLInputElement;
		const value = target?.value;

		if (event.key === 'Enter' || !value || value === '') {
			dispatch('search', {
				value
			});
		}
	}

	export function exportTableHtml() {
		return table.innerHTML;
	}

	function toggleAdvancedSearch() {
		if (isAdvancedSearchOpen === true) {
			closeAdvancedSearch();
		} else {
			openAdvancedSearch();
		}
	}

	function openAdvancedSearch() {
		isAdvancedSearchOpen = true;
	}

	function closeAdvancedSearch() {
		isAdvancedSearchOpen = false;
	}
</script>

<div
	class="border border-slate-300 bg-white p-2 flex rounded mt-2 shadow {hasAdvancedSearch
		? 'mb-0'
		: 'mb-2'}
		{isAdvancedSearchOpen ? 'rounded-b-none shadow-none' : ''}
		"
>
	<h1 class="text-2xl">
		<slot name="title">Header goes here</slot>
	</h1>
	<div class="ml-auto my-auto flex">
		{#if showSearch}
			<div class="relative">
				<input
					disabled={!allowSearch || isBusy}
					type="text"
					class="border border-slate-300 rounded-md pl-2 pr-8 py-1.5
					focus:border-indigo-500 focus:ring ring-indigo-500/30 focus:outline-none
					md:min-w-[250px] lg:min-w-[300px]
					rounded-r-none disabled:bg-slate-200 disabled:text-slate-400
			"
					placeholder={searchHint}
					on:keyup={handleSearchRequested}
				/>
				<div class="absolute right-0 inset-y-0 w-8 flex">
					<i class="bi bi-search m-auto text-slate-400"></i>
				</div>
			</div>
		{/if}
		<button
			disabled={isBusy}
			title="Reload data"
			type="button"
			class="px-3 py-1.5 bg-emerald-500 text-emerald-50 first:rounded-l-md
			   focus:outline-none focus:ring ring-emerald-500/20 active:z-[500]
			   hover:bg-emerald-600 disabled:bg-slate-100 disabled:text-slate-300
			   last-of-type:rounded-r-md"
			on:click={() => dispatch('refresh')}
		>
			<i class="bi bi-arrow-clockwise"></i>
		</button>
		{#if allowAdd}
			<button
				disabled={isBusy}
				title="Add New Item"
				type="button"
				class="px-3 py-1.5 bg-blue-500 text-blue-50
			   focus:outline-none focus:ring ring-blue-500/20 active:z-[500]
			   hover:bg-blue-600 disabled:bg-slate-100 disabled:text-slate-300
			   last-of-type:rounded-r-md"
				on:click={() => dispatch('addnew')}
			>
				<i class="bi bi-plus-lg"></i>
			</button>
		{/if}
		{#if hasAdvancedSearch}
			<div class="my-auto">
				<button
					disabled={isBusy}
					on:click={toggleAdvancedSearch}
					type="button"
					class="mx-1 w-9 h-9 bg-white border border-slate-300
					text-slate-500
					hover:bg-slate-100 rounded-full my-auto
					disabled:bg-slate-100 disabled:text-slate-300
					 transition-all ease-in-out duration-150"
				>
					<i
						class="bi bi-chevron-down pointer-events-none block {isAdvancedSearchOpen
							? 'rotate-0'
							: 'rotate-180'}
							transition-transform duration-150 ease-in-out
							"
					/>
				</button>
			</div>
		{/if}
	</div>
	{#if popupMenuItems && popupMenuItems.length > 0}
		<div class=" mx-2 relative my-auto">
			<button
				type="button"
				class="px-3 py-1.5 text-blue-500 border border-blue-500 rounded
			hover:bg-blue-50 active:bg-blue-500 active:text-blue-50 outline-blue-600 h-full
			disabled:text-slate-300"
				on:click={() => (isMenuOpen = true)}
			>
				<i class="bi bi-three-dots"></i>
			</button>
			<!-- svelte-ignore a11y-click-events-have-key-events -->
			<!-- svelte-ignore a11y-no-static-element-interactions -->
			<div
				class="fixed inset-0 {isMenuOpen ? 'block' : 'hidden'} "
				on:click={() => (isMenuOpen = false)}
			/>
			<div
				class="absolute right-0 mt-1
                    bg-white border border-slate-300 shadow-lg rounded z-[1001]
                     transition-all ease-in-out duration-300 min-w-[220px]
                     grid
                     "
				style="visibility: {isMenuOpen ? 'visible' : 'hidden'};grid-template-rows:{isMenuOpen
					? '1fr'
					: '0fr'};"
			>
				<div class="overflow-hidden">
					<ul class="py-2 divide-y min-w-fit">
						{#each popupMenuItems as menuItem (menuItem.id)}
							<li class="flex">
								<button
									disabled={menuItem.disabled}
									class="space-x-1 px-2 text-slate-600 hover:bg-slate-500/20
											block flex-grow py-1 text-left active:text-slate-50 active:bg-slate-500
											transition-all ease-in-out duration-300 focus:outline-none outline-none
											disabled:text-slate-300 disabled:hover:bg-transparent whitespace-nowrap"
									type="button"
									on:click={() => {
										menuItem.action();
										isMenuOpen = false;
									}}
								>
									{@html menuItem.content}
								</button>
							</li>
						{/each}
					</ul>
				</div>
			</div>
		</div>
	{/if}
</div>
<div
	class="{hasAdvancedSearch ? 'grid' : 'hidden'} mb-2
	{isAdvancedSearchOpen ? 'bg-slate-50 border border-slate-300 shadow' : ''}
	transition-all duration-300 ease-linear
	"
	style={isAdvancedSearchOpen ? 'grid-template-rows:1fr;' : 'grid-template-rows:0fr;'}
>
	<div class={isAdvancedSearchOpen ? '' : 'overflow-hidden'}>
		<slot name="advancedsearch" />
	</div>
</div>

<div class="bg-white border border-slate-300 shadow-md my-1">
	<table class="w-full border-collapse" bind:this={table}>
		<thead class="bg-gray-500 text-gray-50 border-b-2 border-b-gray-700">
			<slot name="header" />
		</thead>
		<tbody>
			<slot />
		</tbody>
	</table>
</div>
