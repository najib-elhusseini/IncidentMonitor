<script lang="ts">
	import Header from '$lib/components/Header.svelte';
	export let data;
</script>

<Header user={data.user} />
<div class="p-2">
    <slot/>
</div>