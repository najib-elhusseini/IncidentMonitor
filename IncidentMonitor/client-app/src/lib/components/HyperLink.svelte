<script lang="ts">
	export let href: string;
	export let linkStyle: 'primary' | 'danger' | 'success' = 'primary';
	export let disabled = false;
	export let customCss = '';
	export let target: '_self' | '_blank' | '_parent' | '_top' = '_self';
	let hrefInternal: string | undefined = href;
	$: {
		hrefInternal = disabled ? undefined : href;
	}
</script>

<a
	{target}
	href={hrefInternal}
	aria-disabled={disabled}
	class="px-1 py-1 {customCss}
		text-slate-500
        {linkStyle === 'primary' ? 'hover:text-indigo-500 active:text-indigo-600' : ''}
        {linkStyle === 'danger' ? 'hover:text-red-500 active:text-red-600' : ''}
        {linkStyle === 'success' ? 'hover:text-emerald-500 active:text-emerald-600' : ''}
        
        aria-disabled:text-slate-300 aria-disabled:cursor-default
	 	 space-x-1 transition-colors ease-in-out duration-150
	"
>
	<slot />
</a>
