<script lang="ts">
	export let checked = false;
	export let label = '';
	export let id: string | undefined = undefined;
	export let name: string | undefined = undefined;
</script>

<label class="flex cursor-pointer">
	<input type="checkbox" bind:checked class="hidden peer" {id} {name} />
	<div
		class=" rounded-full h-5 w-10 flex my-auto bg-slate-300
         peer-checked:bg-indigo-500 transition-all duration-300"
	>
		<div
			class="w-5 h-5 rounded-full my-auto border border-slate-400 {!checked
				? 'bg-slate-400  translate-x-0'
				: ' translate-x-5 bg-slate-100  '} transition-all ease-in-out duration-300
        "
		/>
	</div>

	<span class="text-slate-500 my-auto mx-2">
		{label}
	</span>
</label>
