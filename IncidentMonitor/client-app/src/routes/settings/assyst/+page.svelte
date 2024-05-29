<script lang="ts">
	import { invalidateAll } from '$app/navigation';
	import Button from '$lib/components/Button.svelte';
	import FormButton from '$lib/components/FormButton.svelte';
	import LabeledInput from '$lib/components/LabeledInput.svelte';
	import LabeledPasswordBox from '$lib/components/LabeledPasswordBox.svelte';
	import type { RemedyForceSettings } from '$lib/models/remedy_force.js';
	import {
		fireErrorToast,
		fireSaveErrorToast,
		fireSaveSuccessToast,
		fireSuccessToast
	} from '$lib/swal_helper.js';
	export let data;
	let isLoading = false;
	let settings = data.settings;

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
		data.append('baseUrl', `${settings.baseUrl}`);
		data.append('userName', `${settings.userName}`);
		data.append('password', `${settings.password}`);
		return data;
	}

	async function saveChanges(event: Event) {
		if (!checkFormValidity()) {
			return;
		}
		const body = constructFormData();
		const url = '/api/assyst/savesettings';
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
			await invalidateAll();
			fireSaveSuccessToast();
		} else {
			fireSaveErrorToast();
		}
	}

	async function testSettings() {
		isLoading = true;
		const url = `/api/assyst/getlastevent`;
		const response = await fetch(url, {
			method: 'GET',
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		isLoading = false;
		if (response.ok) {
			fireSuccessToast('Test successful');
		} else {
			fireErrorToast(`Test failed - Error code ${response.status}`);
		}
	}
</script>

<div class="flex">
	<div
		class="w-full md:w-1/2 mx-auto mt-2 md:mt-4 lg:mt-8 border border-slate-300 rounded-md bg-white shadow-lg"
	>
		<div class="p-2">
			<h3 class="py-4 text-xl border-b border-b-slate-300 space-x-2">
				<i class="bi bi-sliders" />
				<span>IFS Assyst Settings</span>
			</h3>
			<div class="grid grid-cols-1 md:grid-cols-2 gap-2 mt-2">
				<div class="col-span-2">
					<LabeledInput
						id="instanceBaseUrlInput"
						label="Instance Base URL"
						bind:value={settings.baseUrl}
						required={true}
					/>
				</div>
				<LabeledInput
					id="userNameInput"
					label="User Name"
					bind:value={settings.userName}
					required={true}
				/>

				<LabeledPasswordBox
					id="passwordInput"
					bind:value={settings.password}
					label="Password"
					required={true}
				/>

				<FormButton role="primary" disabled={isLoading} on:click={saveChanges}>
					<span> Save Changes </span>
				</FormButton>
				<FormButton role="secondary" disabled={isLoading} on:click={testSettings}>
					<span> Test Settings </span>
				</FormButton>
			</div>
			<div class="text-center my-2">
				<Button type="button" buttonStyle="link" href="/settings/assyst/xml-reader">
					<i class="bi bi-filetype-xml"></i>
					XML Documentation
				</Button>
			</div>
		</div>
	</div>
</div>
