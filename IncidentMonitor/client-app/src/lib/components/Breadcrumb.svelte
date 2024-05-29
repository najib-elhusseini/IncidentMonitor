<script lang="ts">
	type pathPresenter = {
		label: string;
		path: string;
	};

	export let paths: string[] = [];
	let pathPresenters: pathPresenter[] = [];
	export let currentLocation: string = '';

	$: {
		let _paths: pathPresenter[] = [];
		let currentPath = '/';
		for (const path of paths) {
			currentPath = currentPath + path + '/';
			_paths.push({
				label: path,
				path: currentPath
			});
		}
		pathPresenters = [..._paths];
	}
</script>

<div class="py-2 text-slate-700 space-x-1 text-sm">
	<a href="/" class=" hover:text-blue-500 active:text-blue-600">
		<i class="bi bi-house-fill"></i>
	</a>
	<span class="">/</span>
	{#each pathPresenters as path}
		<a href={path.path} class=" hover:text-blue-500 active:text-blue-600 capitalize">
			{path.label}
		</a>
		<span class="">/</span>
	{/each}
	<span class="text-slate-400 capitalize">
		{currentLocation}
	</span>
	
</div>
