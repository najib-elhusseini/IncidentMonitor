<script lang="ts" context="module">
	export type ObjectProperty = {
		name: string;
		dataType: 'string' | 'DateTime' | 'bool' | 'int' | 'double' | 'object';
		properties?: ObjectProperty[];
		allowNull?: boolean;
		accessModifier: 'public' | 'private';
		indent: number;
	};
</script>

<script lang="ts">
	import { createEventDispatcher } from 'svelte';

	const dispatch = createEventDispatcher();
	let isExpanded = false;
	let button: HTMLButtonElement;
	export let property: ObjectProperty;
	let canExpand: boolean = false;
	$: {
		canExpand = property.dataType === 'object';
	}

	function handleButtonClicked(event: MouseEvent) {
		if (canExpand) {
			isExpanded = !isExpanded;
		}
		
		
        deselectAll();
		button.dataset.selected = 'true';

		dispatch('selectionchanged', { property });
	}

	function deselectAll() {
		const buttons = document.querySelectorAll('[data-code-gen]') as NodeListOf<HTMLElement>;
		for (const button of buttons) {
			button.dataset.selected = 'false;';
		}
	}
</script>

<div>
	<!-- svelte-ignore a11y-click-events-have-key-events -->
	<!-- svelte-ignore a11y-no-static-element-interactions -->
	<div class="flex">
		<button
			data-code-gen="true"
			bind:this={button}
			type="button"
			class=" flex flex-grow space-x-2 py-2 text-slate-500 hover:bg-slate-500/20
            transition-colors ease-in-out duration-300 active:bg-slate-500 active:text-slate-50
            data-[selected='true']:bg-slate-500 data-[selected='true']:text-slate-50
            "
			on:click={handleButtonClicked}
		>
			<i
				class="bi bi-caret-right-fill block transition-transform ease-in-out duration-300
                {isExpanded ? 'rotate-90' : 'rotate-0'}
                {canExpand ? 'visible' : 'invisible'}
                    "
				style="margin-left: calc({property.indent} * 1rem);"
			></i>
			<span>
				{property.name}
			</span>
			<!-- <i class="bi bi-check ml-auto {isSelected ? 'visible' : 'invisible'}" /> -->
		</button>
	</div>
	<div
		class="grid transition-all ease-in-out duration-300 "
		style="grid-template-rows: {isExpanded ? '1fr' : '0fr'};"
	>
		<div class="overflow-hidden {isExpanded ? "border-b border-b-slate-300" :"border-b-0"}">
			{#if property.properties}
				{#each property.properties as child (child.name)}
					<svelte:self property={child} on:selectionchanged />
				{/each}
			{/if}
		</div>
	</div>
</div>
