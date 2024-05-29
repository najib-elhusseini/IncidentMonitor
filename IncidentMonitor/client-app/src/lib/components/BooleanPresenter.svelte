<script lang="ts">
	export let value: boolean | undefined;
</script>

{#if value}
	<i class="bi bi-check-circle text-emerald-500"></i>
{:else}
	<i class="bi bi-x-circle text-red-500"></i>
{/if}
