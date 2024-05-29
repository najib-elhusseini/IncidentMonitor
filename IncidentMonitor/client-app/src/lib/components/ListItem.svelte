<script lang="ts">
</script>

<div class="grid">
	<button
		type="button"
		class="flex text-left py-1.5 px-2 hover:bg-slate-100
        active:bg-slate-200 outline-none
        focus:outline-none
        transition-all
        ease-in-out duration-150"
		on:click
	>
		<div class="my-auto">
			<slot name="leading" />
		</div>
		<div class="flex-grow my-auto">
			<slot />
		</div>
		<div class="my-auto">
			<slot name="trailing" />
		</div>
	</button>
</div>
