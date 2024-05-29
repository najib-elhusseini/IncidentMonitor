<script lang="ts">
	import { onMount } from 'svelte';

	let toolbar: HTMLDivElement;
	onMount(() => {
		const buttons = toolbar.querySelectorAll('[data-button="true"]');
		for (const button of buttons) {
			button.className =
				`
                text-slate-600 hover:text-indigo-500 active:text-indigo-600 px-2 py-1.5 rounded-sm space-x-1
                disabled:text-slate-300 
                `;
		}
	});
</script>

<div
	bind:this={toolbar}
	class="bg-slate-100 p-2 md:py-3 lg:py-4 border-b border-b-slate-300 shadow "
>
	<slot />
</div>
