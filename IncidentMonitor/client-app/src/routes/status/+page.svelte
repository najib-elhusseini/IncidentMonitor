<script lang="ts">
	let statusCode: string | null | undefined | '401' | '403';

	export let data;

	$: {
		statusCode = data.statusCode;
		console.log(statusCode);
	}
</script>

{#if statusCode==="403"}
    <div>
        Unaothroized
    </div>
{/if}
