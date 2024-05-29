<script lang="ts">
	import { createEventDispatcher } from 'svelte';

	import Form from './Form.svelte';
	import Button from './Button.svelte';
	import CardHeader from './CardHeader.svelte';
	import LoadingSpinner from './LoadingSpinner.svelte';

	let _isOpen: boolean = false;
	let dialog: HTMLDivElement;
	export let allowSubmit: boolean = true;
	export let submitButtonText: string = 'Save Changes';
	export let showCancelButton: boolean = true;
	export let showCloseButton: boolean = true;
	export let busy = false;
	export let dialogSize: 'md' | 'lg' = 'md';

	let isClickCatcherOriginated = false;
	let clickCatcher: HTMLDivElement;

	function handleMouseDown(event: MouseEvent) {
		if (event.button !== 0) {
			return;
		}
		isClickCatcherOriginated = true;
	}

	function handleMouseUp(event: MouseEvent) {
		// console.log('Mouse Up');
		// console.log(event);
	}

	function catchClick(event: MouseEvent) {
		// return;
		if (!isClickCatcherOriginated) {
			return;
		}
		// if (isStatic) return;

		const isClickCatcher = event.target === clickCatcher;

		if (isClickCatcher) {
			dispatch('cancel');
		}
		isClickCatcherOriginated = false;
	}

	function stopBubbling(event: Event) {
		event.stopImmediatePropagation();
		event.stopPropagation();
		isClickCatcherOriginated = false;
	}

	export function openDialog() {
		_isOpen = true;
		setTimeout(() => {
			dialog.classList.remove('scale-0');
		}, 50);
	}

	export function dismissDialog() {
		if (!dialog) return;
		dialog.classList.add('scale-0');
		// dialog.classList.remove('scale-100');
		// dialog.classList.add('scale-0');
		setTimeout(() => {
			_isOpen = false;
		}, 301);
	}

	function fireCancelDialog(event: Event) {
		const target = event.target as HTMLElement;
		if (target.dataset.closeDialog === 'true') {
			dispatch('cancel');
		}
	}

	const dispatch = createEventDispatcher();
</script>

{#if _isOpen}
	<!-- svelte-ignore a11y-click-events-have-key-events -->
	<!-- svelte-ignore a11y-no-static-element-interactions -->
	<div
		bind:this={clickCatcher}
		class="fixed inset-0 bg-black/20 flex p-2"
		data-close-dialog="true"
		on:click={catchClick}
		on:mouseup={handleMouseUp}
		on:mousedown={handleMouseDown}
		
	>
		<div
			bind:this={dialog}
			class="border p-2 border-slate-300 rounded-md shadow-md bg-white m-auto
			w-full
			{dialogSize === 'md' ? 'lg:w-1/2' : ''}
			{dialogSize === 'lg' ? 'lg:w-10/12' : ''}


			scale-0 transition-all ease-in-out duration-300"
		>
			<Form
				on:submit
				isCard={false}
				{allowSubmit}
				on:click={stopBubbling}
				on:mousedown={stopBubbling}
				on:mouseup={stopBubbling}
				showHeader={false}
			>
				<CardHeader>
					<div class="flex">
						<slot name="title">Title goes here</slot>
						{#if showCloseButton}
							<div class="ml-auto my-auto">
								<button
									type="button"
									data-close-dialog="true"
									on:click={fireCancelDialog}
									class="text-slate-400 hover:text-red-500 px-2 inset-y-0 transition-colors ease-in-out"
								>
									<i class="bi bi-x pointer-events-none" />
								</button>
							</div>
						{/if}
					</div>
				</CardHeader>

				<slot />

				<div class="grid {allowSubmit ? 'grid-cols-2' : 'grid-cols-1'}  gap-2 mt-2">
					{#if allowSubmit}
						{#if busy}
							<div
								class="flex px-2 py-1.5 rounded-lg
							bg-indigo-500 text-indigo-50
							"
							>
								<div class="my-auto ml-auto">
									<LoadingSpinner isLight={true} />
								</div>
								<span class="mr-auto my-auto">Saving...</span>
							</div>
						{:else}
							<Button type="submit" buttonStyle="primary" disabled={busy}>
								<span> {submitButtonText} </span>
							</Button>
						{/if}
					{/if}
					{#if showCancelButton}
						<Button
							type="button"
							buttonStyle="secondary"
							disabled={busy}
							on:click={() => dispatch('cancel')}>Cancel</Button
						>
					{/if}
				</div>
			</Form>
		</div>
	</div>
{/if}
