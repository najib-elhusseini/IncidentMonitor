<script lang="ts">
	import { fireDeleteConfirmationDialog } from '$lib/swal_helper';
	import { createEventDispatcher, onMount } from 'svelte';

	export let allowDelete = true;
	export let showEdit = true;
	export let showDelete = true;
	let menuOpen = false;
	let menuItemContainer: HTMLUListElement;
	const dispatch = createEventDispatcher();
	const menuButtonStyle = `space-x-1 px-2 text-slate-600 hover:bg-slate-500/20
                                block w-full py-1 text-left active:text-slate-50 active:bg-slate-500 
                                transition-all ease-in-out duration-300 focus:outline-none outline-none 
								disabled:text-slate-300 disabled:hover:bg-transparent
                                `;
	export let menuWidth = 200;

	function openMenu() {
		menuOpen = true;
	}
	function closeMenu() {
		menuOpen = false;
	}
	function editMenuItemClicked(_: Event) {
		dispatch('edit');
	}
	async function deleteMenuItemClicked() {
		const result = await fireDeleteConfirmationDialog();
		if (result.isConfirmed) {
			dispatch('delete');
		}
	}
	onMount(() => {
		const buttons = menuItemContainer.querySelectorAll('[data-menu-item="true"]');

		for (const button of buttons) {
			button.addEventListener('click', () => closeMenu());
			if (button.className === '') {
				button.className = menuButtonStyle;
			}
		}
	});
</script>

<div class="relative">
	<button
		type="button"
		class="px-3 py-1 rounded bg-emerald-500 text-emerald-50"
		on:click={openMenu}
	>
		<i class="bi bi-three-dots-vertical"></i>
	</button>
	{#if true}
		<!-- svelte-ignore a11y-click-events-have-key-events -->
		<!-- svelte-ignore a11y-no-static-element-interactions -->
		<div
			class="fixed {menuOpen ? 'block' : 'hidden'} inset-0 bg-black/20 z-[1000]"
			on:click={closeMenu}
		/>
		<div
			class="absolute right-0
                    bg-white border border-slate-300 shadow-md rounded z-[1001]
                     transition-all ease-in-out duration-300
                     grid
                     "
			style="visibility: {menuOpen ? 'visible' : 'hidden'};grid-template-rows:{menuOpen
				? '1fr'
				: '0fr'}; width:{menuWidth}px;"
		>
			<div class="overflow-hidden">
				<ul class="py-2" bind:this={menuItemContainer}>
					{#if showEdit}
						<li>
							<button
								on:click={editMenuItemClicked}
								data-menu-item="true"
								type="button"
								class={menuButtonStyle}
							>
								<i class="bi bi-pencil-square"></i>
								<span>Edit</span>
							</button>
						</li>
					{/if}
					<slot />
					{#if showDelete}
						<li class="border-t border-t-slate-300">
							<button
								disabled={!allowDelete}
								on:click={deleteMenuItemClicked}
								data-menu-item="true"
								type="button"
								class="space-x-1 px-2 text-red-600 hover:bg-red-500/20
                                block w-full py-1 text-left active:text-red-50 active:bg-red-500
                                transition-all ease-in-out duration-300 focus:outline-none outline-none
								disabled:text-slate-300 disabled:hover:bg-transparent
                                "
							>
								<i class="bi bi-trash"></i>
								<span>Delete</span>
							</button>
						</li>
					{/if}
				</ul>
			</div>
		</div>
	{/if}
</div>
