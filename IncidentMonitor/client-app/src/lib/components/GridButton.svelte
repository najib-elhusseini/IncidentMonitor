<script lang="ts">
	export let href: string | undefined = undefined;
	export let target: '_blank' | '_self' | '_parent' | '_top' = '_self';
</script>

<a
	{href}
	{target}
	class="rounded h-20 lg:h-24 xl:h-28 font-bold border border-indigo-500
           flex p-2 items-center justify-center
           transition-all ease-in-out duration-150
           bg-white text-indigo-500
           hover:bg-indigo-500/10   outline-none active:outline-none
           active:bg-indigo-600 active:text-indigo-50           
           "
	on:click
>
	<slot />
</a>

