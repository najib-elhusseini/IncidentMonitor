<script lang="ts">
	import { createEventDispatcher } from 'svelte';

	
	import ListItem from './ListItem.svelte';

	export let isChecked:boolean = false;
    export let value: string | number | undefined = undefined;
    const dispatch = createEventDispatcher();


	function handleClick() {
		isChecked = !isChecked;
        dispatch('checkchanged', { isChecked, value });

	}
</script>

<ListItem on:click={handleClick}>
	<div slot="leading" class="pr-2">
		<i class="bi bi-check-lg text-blue-500 {isChecked ? '' : 'invisible'}"></i>
	</div>
	<slot />
</ListItem>
