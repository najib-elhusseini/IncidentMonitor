<script context="module" lang="ts">
	export type TreeItem = {
		index: number;
		labelKey: string;
		data: any;
		selected: boolean;
		expanded: boolean;
		items?: TreeItem[];
		indent: number;
	};
</script>

<script lang="ts">
	import { createEventDispatcher } from 'svelte';

	const dispatch = createEventDispatcher();
	export let treeItem: TreeItem;

	function toggleExpanded(event: Event) {
		event.stopImmediatePropagation();
		event.stopPropagation();
		event.preventDefault();
		if (treeItem.items) {
			treeItem.expanded = !treeItem.expanded;
		}else{
			selectItem();
		}
	}

	function selectItem() {
		
		dispatch('selectionchanged', { treeItem: treeItem.selected ? undefined : treeItem });
	}
</script>

<!-- svelte-ignore a11y-click-events-have-key-events -->
<!-- svelte-ignore a11y-no-static-element-interactions -->
<div
	data-selected={treeItem.selected}
	class="hover:bg-blue-500/10 text-sm cursor-pointer hover:text-blue-600 data-[selected='true']:bg-blue-500 data-[selected='true']:text-blue-50"
	on:click={selectItem}
>
	<button
		type="button"
		on:click={toggleExpanded}
		class="py-1.5 flex space-x-1 hover:underline underline-offset-4"
		style="margin-left: calc(0.5rem * {treeItem.indent} );"
	>
		<i
			class="bi bi-chevron-right m-auto block rotate-0  {treeItem.expanded
				? 'rotate-90'
				: ''} transition-all ease-in-out duration-200
				{treeItem.items ? 'visible' : 'invisible'}
				"
		/>
		<span>
			{treeItem.data[treeItem.labelKey]}
		</span>
	</button>
</div>
<div class="grid transition-all ease-out duration-300" style="grid-template-rows: {treeItem.expanded ? '1fr' : '0fr'};">
	<div class="overflow-hidden">
		{#if treeItem.items}
			{#each treeItem.items as childItem (childItem.index)}
				<svelte:self treeItem={childItem} on:selectionchanged />
			{/each}
		{/if}
	</div>
</div>
