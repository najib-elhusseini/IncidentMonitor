<script lang="ts">
	import { createEventDispatcher } from 'svelte';
	import Button from './Button.svelte';
	import { fireDeleteConfirmationDialog } from '$lib/swal_helper';

	export let iconOnly = true;
	export let disabled=false
	const dispatch = createEventDispatcher();
	async function handleDeletePressed() {
		const result = await fireDeleteConfirmationDialog();
		if (result.isConfirmed) {
			dispatch('deleteconfirmed');
		}
	}
</script>

<Button buttonStyle="danger" type="button" on:click={handleDeletePressed} {disabled}>
	<i class="bi bi-trash"> </i>
	{#if !iconOnly}
		<span> Delete </span>
	{/if}
</Button>
