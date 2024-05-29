<script lang="ts">
	export let date: Date | string;
	export let showTimeStamp = true;
	let dateFormatted: string = '';
	$: {
		if (typeof date === 'string') {
			date = new Date(date);
		}
		if (date) {
			const formatter = new Intl.DateTimeFormat(undefined, {
				dateStyle: 'short',
				timeStyle: showTimeStamp ? 'short' : undefined
			});
			dateFormatted = formatter.format(date);
		} else {
			dateFormatted = 'N/A';
		}
	}
</script>

<span>
	{dateFormatted}
</span>
