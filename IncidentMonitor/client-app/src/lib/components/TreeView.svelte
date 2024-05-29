<script lang="ts">
	import { createEventDispatcher, onMount } from 'svelte';
	import TreeItemView, { type TreeItem } from './TreeItemView.svelte';

	const dispatch = createEventDispatcher();
	export let treeItems: TreeItem[];
	export let allowGrow = false;

	function handleSelectionChanged(event: CustomEvent) {
		const item = event.detail.treeItem as TreeItem;

		for (const item of treeItems) {
			deselectTreeItem(item);
		}
		if (item) {
			item.selected = true;
			dispatch('selectionchanged', { item: item });
		} else {
			dispatch('selectionchanged', { item: undefined });
		}

		treeItems = [...treeItems];
	}

	function deselectTreeItem(item: TreeItem) {
		item.selected = false;
		if (item.items) {
			for (const subItem of item.items) {
				deselectTreeItem(subItem);
			}
		}
	}
	let treeView: HTMLDivElement;
	onMount(() => {
		if(!allowGrow){
			let height = treeView.clientHeight;
			console.log(height)
			treeView.style.height=`${height}px`
			console.log(treeView.style.height)
		}
	});
</script>

<div class="border border-slate-300 bg-white {allowGrow? "" :"overflow-y-scroll"}" bind:this={treeView} >
	<slot name="treeHeader" />
	<div>
		{#each treeItems as treeItem (treeItem.index)}
			<TreeItemView {treeItem} on:selectionchanged={handleSelectionChanged} />
		{/each}
	</div>
	<slot name="treeFooter" />
</div>
