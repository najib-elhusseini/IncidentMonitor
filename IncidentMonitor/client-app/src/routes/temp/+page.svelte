<script lang="ts">
	import DatePresenter from '$lib/components/DatePresenter.svelte';
	
	import { casedata } from '$lib/data/cases.js';
	
    function formatDescription(description:string){
        description = description.replace('[code]','').replace('[/code]','');
        return description;
    }
</script>

<div class="p-2">
	<table class="w-full border-collapse border border-black">
		<tr>
			<th class="text-left border border-black"> # </th>
			<th class="text-left border border-black"> Date </th>
			<th class="text-left border border-black" > Comment </th>
		</tr>
		{#each casedata as _case}
			{#each _case.Comments as comment}
				{#if comment.RichTextDescription}
					<tr>
						<td class="p-1.5 w-[10vw] text-sm border border-black">
							{_case.number}
						</td>
						<td class="p-1.5 w-[10vw] text-sm border border-black">
							<DatePresenter date={comment.CreationDate} />
						</td>
						<td class="p-1.5 w-[80vw] border border-black">
							<span class="text-sm break-words block w-[70vw]">
								{@html formatDescription(comment.RichTextDescription)}
							</span>
						</td>
					</tr>
				{/if}
			{/each}
		{/each}
	</table>
</div>
