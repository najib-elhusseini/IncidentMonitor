<script lang="ts">
	import { invalidateAll } from '$app/navigation';
	import Breadcrumb from '$lib/components/Breadcrumb.svelte';
	import Button from '$lib/components/Button.svelte';
	import ButtonsToolbar from '$lib/components/ButtonsToolbar.svelte';
	import Header from '$lib/components/Header.svelte';
	import HelpDeskCommentPresenter from '$lib/components/HelpDeskCommentPresenter.svelte';
	import { eventStatus } from '$lib/models/assyst.js';
	import type { ActionDto } from '$lib/models/event-action.js';
	import type { IHelpDeskComment } from '$lib/models/help-desk-object.js';
	import { fireSaveErrorToast, fireSaveSuccessToast } from '$lib/swal_helper.js';

	export let data;
	let isLoading = false;
	let comments: IHelpDeskComment[] = [];
	function updateComments(actions: ActionDto[]) {
		comments = [];
		for (const action of actions) {
			comments.push({
				commentId: `${action.id}`,
				creationDate: action.dateActioned,
				createdBy: action.modifyId,
				title: action.actionType?.name,
				plainTextDescription: action.richRemarks?.plainTextContent,
				richTextDescription: action.richRemarks?.content
			});
		}
	}
	$: {
		if (!data.event.actions) {
			comments = [];
		} else {
			updateComments(data.event.actions);
		}
	}

	async function fixFormatting() {
		const commentsToCopy: IHelpDeskComment[] = [];
		for (const comment of comments) {
			if (comment.selected === true) {
				commentsToCopy.push(comment);
			}
		}
		const url = '/api/integrations/fixformatting';
		const body = new FormData();
		isLoading = true;
		body.append('id', `${data.event.id}`);
		body.append('userReference', `${data.event.userReference}`);
		body.append('comments', JSON.stringify(commentsToCopy));
		const response = await fetch(url, {
			method: 'POST',
			body,
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		if (response.ok) {
			fireSaveSuccessToast();
			await invalidateAll();
		} else {
			fireSaveErrorToast();
		}
		isLoading = false;
	}

	async function copyToThirdParty() {
		const commentsToCopy: IHelpDeskComment[] = [];
		for (const comment of comments) {
			if (comment.selected === true) {
				commentsToCopy.push(comment);
			}
		}
		const url = '/api/integrations/copyassystcommentstothirdparty';
		const body = new FormData();
		isLoading = true;
		body.append('id', `${data.event.id}`);
		body.append('userReference', `${data.event.userReference}`);
		body.append('comments', JSON.stringify(commentsToCopy));
        body.append('departmentId',`${data.event.departmentId}`)
		const response = await fetch(url, {
			method: 'POST',
			body,
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		if (response.ok) {
			fireSaveSuccessToast();
			await invalidateAll();
		} else {
			fireSaveErrorToast();
		}
		isLoading = false;
	}

	async function copyToIfsAssyst() {
		const commentsToCopy: IHelpDeskComment[] = [];
		for (const comment of data.thirdPartyComments) {
			if (comment.selected === true) {
				commentsToCopy.push(comment);
			}
		}
		const url = '/api/integrations/copythirdpartycomments';
		const body = new FormData();
		isLoading = true;
		body.append('id', `${data.event.id}`);
		body.append('userReference', `${data.event.userReference}`);
		body.append('comments', JSON.stringify(commentsToCopy));
		const response = await fetch(url, {
			method: 'POST',
			body,
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		if (response.ok) {
			fireSaveSuccessToast();
			await invalidateAll();
		} else {
			fireSaveErrorToast();
		}
		isLoading = false;
	}
</script>

<Header user={data.user} {isLoading} />
<div class="p-2">
	<Breadcrumb currentLocation="compare" paths={['assyst']} />
</div>

<div class="grid grid-cols-2 gap-2">
	<div class="p-2">
		<div class="flex space-x-2">
			<Button buttonStyle="link" on:click={copyToThirdParty}>Copy to third party</Button>
			<Button type="button" buttonStyle="link" on:click={fixFormatting}>
				Fix Formatting
			</Button>
		</div>
		<HelpDeskCommentPresenter {comments} />
	</div>
	<div class="p-2">
		<div>
			<Button buttonStyle={'link'} on:click={copyToIfsAssyst}>Copy to Assyst</Button>
		</div>
		<HelpDeskCommentPresenter comments={data.thirdPartyComments} />
	</div>
</div>
