<script lang="ts">
	import FormButton from '$lib/components/FormButton.svelte';
	import LabeledInput from '$lib/components/LabeledInput.svelte';
	import LabeledPasswordBox from '$lib/components/LabeledPasswordBox.svelte';
	import type { RemedyForceSettings } from '$lib/models/remedy_force.js';
	import { fireSaveErrorToast, fireSaveSuccessToast, fireSuccessToast } from '$lib/swal_helper.js';

	let isLoading = false;
	export let data;
	let settings: RemedyForceSettings = data.settings;
	// $: {
	// 	settings = data.settings;
	// }

	function checkFormValidity(): boolean {
		const elems: NodeListOf<HTMLInputElement | HTMLSelectElement> =
			document.querySelectorAll('[data-required=true]');		
		for (const elem of elems) {
			if (!elem.checkValidity()) {
				return false;
			}
		}
		return true;
	}

	function constructFormData() {
		const data = new FormData();
		data.append('id', `${settings.id}`);
		data.append('instanceUrl', `${settings.instanceUrl}`);
		data.append('tokenEndpoint', `${settings.tokenEndPoint}`);
		data.append('userName', `${settings.userName}`);
		data.append('password', `${settings.password}`);
		data.append('clientId', `${settings.clientId}`);
		data.append('clientSecret', `${settings.clientSecret}`);
		data.append('token', `${settings.token ?? ''}`);
		return data;
	}

	async function saveChanges(event: Event) {
		if (!checkFormValidity()) {
			return;
		}
		const body = constructFormData();
		const url = '/api/remedyforceincidents/savesettings';
		isLoading = true;
		const response = await fetch(url, {
			method: 'POST',
			body,
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		isLoading = false;
		if (response.ok) {
			const _data: RemedyForceSettings = await response.json();
			settings = _data;
			console.log(_data);
			fireSaveSuccessToast();
		} else {
			fireSaveErrorToast();
		}
	}

	async function updateToken(event: Event) {
		if (!checkFormValidity()) {
			return;
		}
		const body = constructFormData();
		const url = '/api/remedyforceincidents/updatetoken';
		isLoading = true;
		const response = await fetch(url, {
			method: 'POST',
			body,
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		isLoading = false;
		if (response.ok) {
			const _data: RemedyForceSettings = await response.json();
			settings = _data;
			fireSuccessToast('Token has been updated');
		} else {
			fireSaveErrorToast();
		}
	}
</script>

<div class="p-2">
	<div class="grid grid-cols-1 md:grid-cols-2 gap-2">
		<div>
			<LabeledInput
				id="instanceBaseUrlInput"
				label="Instance Base URL"
				bind:value={settings.instanceUrl}
				required={true}
			/>
		</div>
		<LabeledInput
			id="tokenEndpointInput"
			label="Authentication endpoint"
			bind:value={settings.tokenEndPoint}
			required={true}
		/>
		<LabeledInput
			id="userNameInput"
			label="User name"
			bind:value={settings.userName}
			required={true}
		/>
		<LabeledPasswordBox
			id="passwordInput"
			bind:value={settings.password}
			label="Password"
			required={true}
		/>

		<LabeledInput
			id="clientIdInput"
			label="Client ID"
			placeholder="Client Secret"
			bind:value={settings.clientId}
			required={true}
		/>

		<LabeledPasswordBox
			id="clientSecretInput"
			placeholder="Client Secret"
			label="Client Secret"
			required={true}
			bind:value={settings.clientSecret}
		/>
		<div class="col-span-2">
			<LabeledInput
				label="Token"
				placeholder="Remedyforce API Token"
				id="tokenInput"
				bind:value={settings.token}
			/>
		</div>
		<FormButton role="primary" disabled={isLoading} on:click={saveChanges}>
			<span> Save Changes </span>
		</FormButton>
		<FormButton role="secondary" disabled={isLoading} on:click={updateToken}>
			<span> Update Token </span>
		</FormButton>
	</div>
</div>
