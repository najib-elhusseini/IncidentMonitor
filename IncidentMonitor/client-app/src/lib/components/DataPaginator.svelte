<script lang="ts">
	import { createEventDispatcher } from 'svelte';

	export let currentIndex: number;
	export let totalCount: number;
	export let resultsPerSearch: number;
	const dispatch = createEventDispatcher();
	let totalPages: number = 0;
	$: {
		totalPages = Math.floor(totalCount / resultsPerSearch);
	}

	function setIndex(index: number) {
		dispatch('indexchanged', { index });
	}
</script>

<div class="border-t border-t-slate-300 py-1.5 flex px-2">
	<div class="flex-grow text-sm">
		Count : {totalCount}
	</div>
	<div>
		<button type="button" class="px-1 py-1.5 text-slate-600 hover:text-blue-500" on:click={() => setIndex(0)}>
			<i class="bi bi-chevron-double-left"></i>
		</button>
		<button
			type="button"
			class="px-1 py-1.5 text-slate-600 hover:text-blue-500"
			on:click={() => setIndex(currentIndex - 1)}
		>
			<i class="bi bi-chevron-left"></i>
		</button>
		<span>
			{currentIndex + 1}
		</span>
		<button
			type="button"
			class="px-1 py-1.5 text-slate-600 hover:text-blue-500"
			on:click={() => setIndex(currentIndex + 1)}
		>
			<i class="bi bi-chevron-right"></i>
		</button>
		<button type="button" class="px-1 py-1.5 text-slate-600 hover:text-blue-500" on:click={() => setIndex(totalPages)}>
			<i class="bi bi-chevron-double-right"></i>
		</button>
	</div>
</div>
