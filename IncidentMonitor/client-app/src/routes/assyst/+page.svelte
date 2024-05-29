<script lang="ts">
	
	import Breadcrumb from '$lib/components/Breadcrumb.svelte';
	import Header from '$lib/components/Header.svelte';
	export let data;
	let links = [
		{
			index: 3,
			title: 'Integrations',
			path:'/integration',
			absolute:true,
		},
		{
			index: 2,
			title: 'Contact Users',
			path: 'contact-users',
			absolute:false,
						
		},
		{
			index: 10,
			title: 'Event Search',
			path: 'event-search',
			absolute:false,
		},
		{
			index:1,
			title: 'Assyst Users',
			path:'assyst-users',
			absolute:false,
		}
	];
</script>

<div>
	<Header user={data.user} isLoading={false} />
	<div class="p-2">
		<Breadcrumb currentLocation="assyst"></Breadcrumb>

		<div class="grid grid-cols-1 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-6 gap-4">
			{#each links as link (link.index)}
				<a
					href={link.absolute ? link.path : `/assyst/${link.path}`}
					class="px-2 py-6 text-center border border-slate-400 text-lg rounded-lg shadow
                    hover:border-purple-500 hover:text-purple-500 active:bg-purple-500 active:text-purple-50
                    transition-all ease-in-out duration-150
                    "
				>
					{link.title}
				</a>
			{/each}
		</div>
	</div>
</div>
