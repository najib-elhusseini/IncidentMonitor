<script lang="ts">
	
	export let isHeader = false;
	export let width: number | undefined = undefined;
</script>

{#if isHeader}
	<th
		class="px-2 py-1.5 border-r border-r-slate-300 last-of-type:border-r-0 text-left"
		style={width === undefined ? '' : `width:${width}px`}
	>
		<slot />
	</th>
{:else}
	<td
		class="px-2 py-1.5 border-r border-r-slate-300 last-of-type:border-r-0"
		style={width === undefined ? '' : `width:${width}px`}
	>
		<slot />
	</td>
{/if}
