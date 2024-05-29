<script lang="ts">
	import { createEventDispatcher } from 'svelte';
	import Card from '$lib/components/Card.svelte';
	import CardHeader from './CardHeader.svelte';

	export let isCard = false;

	let form: HTMLFormElement;
	let dispatch = createEventDispatcher();

	export let id: string | undefined = undefined;
	export let isLoading = false;
	export let allowSubmit: boolean = true;
	export let showBackButton: boolean = false;
	export let showHeader = true;

	export function submit() {
		form.submit();
	}

	function handleSubmit(event: Event) {
		event.preventDefault();
		if (!allowSubmit) return;
		const inputs = document.querySelectorAll('[data-requires-validation="true"]');
		for (const input of inputs) {
			let i = input as HTMLElement;

			i.dataset.validated = 'true';
			i.dispatchEvent(new Event('validate--custom'));
		}
		if (!form.checkValidity()) {
			return;
		}
		const formData = new FormData(form);
		dispatch('submit', formData);
	}
</script>

{#if !isLoading}
	<!-- svelte-ignore a11y-click-events-have-key-events -->
	<!-- svelte-ignore a11y-no-noninteractive-element-interactions -->
	<Card {isCard} showHeader={false}>
		{#if showHeader}
			<CardHeader>
				<div class="flex">
					{#if showBackButton}
						<button
							type="button"
							on:click={() => dispatch('navigateback')}
							class="text-slate-600 mr-2 my-auto hover:text-indigo-500 active:text-indigo-600 focus:outline-none"
						>
							<i class="bi bi-arrow-left-circle-fill text-xl"></i>
						</button>
					{/if}
					<slot name="title" />
				</div>
			</CardHeader>
		{/if}

		<form
			{id}
			on:click
			on:mousedown
			on:mouseup
			bind:this={form}
			novalidate
			on:submit={handleSubmit}
			class=""
		>
			<slot />
		</form>
	</Card>
{/if}
