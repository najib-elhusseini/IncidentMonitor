<script lang="ts">
	export let number: number | undefined;
	export let currencyCode: string = '';
	let numberFormatted: string = '';
	$: {
		if (number) {
			const formatter = new Intl.NumberFormat(undefined, {
				minimumFractionDigits: 2,
				maximumFractionDigits: 3,
				style: 'decimal'
			});
			numberFormatted = formatter.format(number);
		} else {
			numberFormatted = 'N/A';
		}
	}
</script>

<span>
	{currencyCode}
	{numberFormatted}
</span>
