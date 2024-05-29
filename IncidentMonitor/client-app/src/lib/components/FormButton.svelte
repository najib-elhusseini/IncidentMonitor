<script lang="ts">
	export let type: 'submit' | 'reset' | 'button' = 'button';
	export let role: 'primary' | 'secondary' = 'primary';
	export let disabled = true;
</script>

<button
	{disabled}
	{type}
	class="px-2 py-1.5 rounded-lg hover:brightness-95 focus:outline-none focus:ring active:ring
	{role === 'primary' ? 'bg-indigo-500 text-indigo-50 ring-indigo-500/20' : ''} 
	{role === 'secondary' ? 'bg-slate-400 text-slate-50 ring-slate-500/20' : ''}
	disabled:bg-slate-100 disabled:text-slate-300 disabled:ring-0 disabled:brightness-100
	"
	on:click
>
	<slot />
</button>
