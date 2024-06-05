<script lang="ts">
	import GridButton from '$lib/components/GridButton.svelte';
</script>

<div class="grid grid-cols1 md:grid-cols-2 lg:grid-cols-4 gap-2 md:gap-4 px-2 py-4">
	<GridButton href="/reports/follow-ups">
		<span class=""> Follow-ups Report </span>
	</GridButton>
	<GridButton href="/reports/time-registration">
		<span> Time Registration Report </span>
	</GridButton>
	<!-- <a
		href="/reports/follow-ups"
		class="border border-slate-300 rounded h-32
               flex p-2 items-center justify-center"
	>
		<span class=""> Follow Ups Report </span>
	</a> -->
</div>
