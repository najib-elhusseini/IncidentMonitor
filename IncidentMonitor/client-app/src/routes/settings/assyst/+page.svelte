<script lang="ts">
	import { invalidateAll } from '$app/navigation';
	import Button from '$lib/components/Button.svelte';
	import Form from '$lib/components/Form.svelte';
	import LabeledInput from '$lib/components/LabeledInput.svelte';
	import LabeledPasswordBox from '$lib/components/LabeledPasswordBox.svelte';

	import {
		fireErrorToast,
		fireSaveErrorToast,
		fireSaveSuccessToast,
		fireSuccessToast
	} from '$lib/swal_helper.js';
	export let data;
	let isLoading = false;
	let settings = data.settings;

	// function checkFormValidity(): boolean {
	// 	const elems: NodeListOf<HTMLInputElement | HTMLSelectElement> =
	// 		document.querySelectorAll('[data-required=true]');
	// 	for (const elem of elems) {
	// 		if (!elem.checkValidity()) {
	// 			return false;
	// 		}
	// 	}
	// 	return true;
	// }

	function constructFormData() {
		const data = new FormData();
		data.append('id', `${settings.id}`);
		data.append('baseUrl', `${settings.baseUrl}`);
		data.append('userName', `${settings.userName}`);
		data.append('password', `${settings.password}`);
		return data;
	}

	async function saveChanges(event: CustomEvent) {
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
		const searchQuery = '$top=1%26$orderby=id:desc';
		const url = `/api/assyst/searchevents?searchQuery=${searchQuery}`;
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
	<div class="w-full md:w-2/3 xl:w-1/2 mx-auto mt-0 lg:mt-8 xl:mt-10">
		<Form isCard={true} on:submit={saveChanges}>
			<span slot="title" class="space-x-2">
				<i class="bi bi-sliders" />
				<span>IFS Assyst Settings</span>
			</span>
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

				<Button buttonStyle="primary" type="submit" disabled={isLoading}>
					<span> Save Changes </span>
				</Button>
				<Button buttonStyle="secondary" type="button" disabled={isLoading} on:click={testSettings}>
					<span> Test Settings </span>
				</Button>
			</div>
			<div class="text-center my-2">
				<Button type="button" buttonStyle="link" href="/settings/assyst/xml-reader">
					<i class="bi bi-filetype-xml"></i>
					XML Documentation
				</Button>
			</div>
		</Form>
	</div>
</div>
