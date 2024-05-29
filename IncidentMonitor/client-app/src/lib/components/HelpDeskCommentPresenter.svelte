<script lang="ts">
	import { formatDate } from '$lib/helpers/date-helper';
	import type { IHelpDeskComment } from '$lib/models/help-desk-object';
	import { comment } from 'postcss';

	export let comments: IHelpDeskComment[];
	function changeSelectionStatus(comment: IHelpDeskComment) {
		comment.selected = !comment.selected;
		comments = comments;
	}
</script>

<div class="p-2 border border-slate-300 bg-white rounded">
	{#each comments as comment (comment.commentId)}
		<div class="my-2 grid">
			<button
				type="button"
				class="flex flex-row text-left border-b border-b-slate-500 hover:bg-slate-100"
				on:click={() => changeSelectionStatus(comment)}
			>
				<div class="my-auto mx-2">
					<i class="bi bi-check-circle-fill text-blue-600 {comment.selected ? '' : 'invisible'}" />
				</div>
				<div class="flex-grow">
					<div class="">
						<span class="font-bold">{comment.title}</span>
						<div class="text-sm">
							{formatDate(comment.creationDate ?? '')}
						</div>
					</div>
					<div class="text-xs break-all my-2">
						{#if comment.richTextDescription}
							{@html comment.richTextDescription}
						{/if}
					</div>
				</div>
			</button>
		</div>
	{/each}
</div>
