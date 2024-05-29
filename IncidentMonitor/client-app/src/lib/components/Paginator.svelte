<script lang="ts">
	

	export let currentPageIndex: number;
	export let totalRowsCount: number;
	export let rowsPerPage: number;
	let pagesCount: number = 0;
	let currentIndex: number = 0;
	$: {
		currentIndex = currentPageIndex + 1;
	}
	type pageButton = {
		index: number;
		label: number;
		visible: boolean;
		enabled: boolean;
		checked: boolean;
	};
	let pages: pageButton[] = [];
	$: {
		pagesCount = Math.ceil(totalRowsCount / rowsPerPage);
		pages = [];
		for (let index = 0; index < pagesCount; index++) {
			let visible = Math.abs(currentPageIndex - index) < 3;
			pages.push({
				index,
				label: index + 1,
				visible: visible,
				enabled: currentPageIndex !== index,
				checked: currentPageIndex === index
			});
		}
		pages = pages;
	}
</script>

<div class="p-2  bg-white  flex">
	<div class="w-1/2 text-sm">
		<span> Page </span>
		<span>
			{currentIndex}
		</span>
		<span> Of </span>
		<span>
			{pagesCount}
		</span>
	</div>
	<div class="flex">
		<button
			type="button"
			class="border border-blue-500 text-sm
        hover:bg-blue-500/20 border-r-0 last-of-type:border-r
        bg-white px-2 last:rounded-r first-of-type:rounded-l text-blue-500 active:text-blue-50
        active:bg-blue-500
        "
		>
			<i class="bi bi-chevron-bar-left"></i>
		</button>
		<button
			type="button"
			class="border border-blue-500 text-sm
        hover:bg-blue-500/20 border-r-0 last-of-type:border-r
        bg-white px-2 last:rounded-r first-of-type:rounded-l text-blue-500 active:text-blue-50
        active:bg-blue-500
        "
		>
			<i class="bi bi-chevron-left"></i>
		</button>
		<span class="px-4 inline-block border border-blue-500 border-r-0">
			{currentIndex}
		</span>
		<button
			type="button"
			class="border border-blue-500 text-sm
        hover:bg-blue-500/20 border-r-0 last-of-type:border-r
        bg-white px-2 last:rounded-r first-of-type:rounded-l text-blue-500 active:text-blue-50
        active:bg-blue-500
        "
		>
			<i class="bi bi-chevron-right"></i>
		</button>
		<button
			type="button"
			class="border border-blue-500 text-sm
        hover:bg-blue-500/20 border-r-0 last-of-type:border-r
         bg-white px-2 last:rounded-r first-of-type:rounded-l text-blue-500 active:text-blue-50
         active:bg-blue-500
         "
		>
			<i class="bi bi-chevron-bar-right"></i>
		</button>
	</div>
</div>
