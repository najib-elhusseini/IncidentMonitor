<script lang="ts">
	export let type: 'submit' | 'reset' | 'button' = 'button';
	export let buttonStyle: 'primary' | 'secondary' | 'link' | 'danger' | 'success' = 'primary';
	export let disabled = false;
	export let customCss = '';
	export let href: string | undefined = undefined;	
</script>

{#if buttonStyle === 'link'}
	{#if href}
		<a
			{href}
			class="px-2 py-1 {customCss}
		text-slate-600 hover:text-indigo-500 active:text-indigo-600 hover:underline underline-offset-4
		 disabled:text-slate-300 space-x-1
	"
		>
			<slot />
		</a>
	{:else}
		<button
			{disabled}
			{type}
			class="px-2 py-1 {customCss}
		text-slate-600 hover:text-indigo-500 active:text-indigo-600 hover:underline underline-offset-4
		 disabled:text-slate-300 space-x-1
	"
			on:click
		>		
			<slot />
		</button>
	{/if}
{:else if href}
	<a
		href={disabled ? undefined : href}
		class="px-2 py-1.5 rounded-lg hover:brightness-95 focus:outline-none focus:ring active:ring
				{buttonStyle === 'primary' ? 'bg-indigo-500 text-indigo-50 ring-indigo-500/20' : ''} 
				{buttonStyle === 'secondary' ? 'bg-slate-400 text-slate-50 ring-slate-500/20' : ''}
				{buttonStyle === 'danger' ? 'bg-red-500 text-red-50 ring-red-500/20' : ''}
				{buttonStyle === 'success' ? 'bg-emerald-500 text-emerald-50 ring-emerald-500/20' : ''}
				disabled:bg-slate-100 disabled:text-slate-300 disabled:ring-0 disabled:brightness-100 space-x-1
				{customCss}
	"
	>
		<slot />
	</a>
{:else}
	<button
		{disabled}
		{type}
		class="px-2 py-1.5 rounded-lg hover:brightness-95 focus:outline-none focus:ring active:ring
		{buttonStyle === 'primary' ? 'bg-indigo-500 text-indigo-50 ring-indigo-500/20' : ''} 
		{buttonStyle === 'secondary' ? 'bg-slate-400 text-slate-50 ring-slate-500/20' : ''}
		{buttonStyle === 'danger' ? 'bg-red-500 text-red-50 ring-red-500/20' : ''}
		{buttonStyle === 'success' ? 'bg-emerald-500 text-emerald-50 ring-emerald-500/20' : ''}
		disabled:bg-slate-100 disabled:text-slate-300 disabled:ring-0 disabled:brightness-100 space-x-1 {customCss}"
		on:click
	>
		<slot />
	</button>
{/if}
