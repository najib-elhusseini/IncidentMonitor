<script lang="ts">
	import { goto } from '$app/navigation';

	export let destination: string;
	let button: HTMLButtonElement;

	function menuButtonClicked(event: Event) {
		// const target = event.target as HTMLButtonElement;
		button.disabled = true;
		// const destination = target.dataset.destination as string;

		goto(`/settings/${destination}`).then(() => {
			button.disabled = false;
			selectDestinationButton(destination);
		});
	}

	function selectDestinationButton(destination: string) {
		const elems: NodeListOf<HTMLButtonElement> = document.querySelectorAll('[data-destination]');
		for (const elem of elems) {
			if (elem.dataset.destination === destination) {
				elem.ariaChecked = 'true';
			} else {
				elem.ariaChecked = 'false';
			}
		}
	}
</script>

<button
	type="button"
	bind:this={button}
	data-destination={destination}
	class="w-full my-1 text-indigo-500 py-1.5 px-2 flex aria-checked:bg-indigo-600 aria-checked:text-indigo-50
                hover:bg-indigo-500 hover:text-indigo-50 transition-all ease-in-out duration-150 active:bg-indigo-600
                rounded-md
				focus:outline-none active:ring ring-indigo-500/20 focus:ring
				disabled:bg-slate-300 disabled:text-slate-50
				aria-checked:disabled:bg-slate-300 aria-checked:disabled:text-slate-50 space-x-2

                "
	on:click={menuButtonClicked}
>
	<slot>
		<i class="bi bi-boxes mr-2 pointer-events-none"></i>
		<span class="pointer-events-none"> button text </span>
	</slot>
</button>
