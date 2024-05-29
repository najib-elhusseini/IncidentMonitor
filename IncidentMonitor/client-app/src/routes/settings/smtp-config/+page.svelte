<script lang="ts">
	import FormButton from '$lib/components/FormButton.svelte';
	import LabeledInput from '$lib/components/LabeledInput.svelte';
	import LabeldPasswordInput from '$lib/components/LabeledPasswordBox.svelte';
	import ToggleButton from '$lib/components/ToggleButton.svelte';
	import type { SmtpConfiguration } from '$lib/models/smtp_configuration.js';
	import {
		fireErrorToast,
		fireSaveErrorToast,
		fireSaveSuccessToast,
		fireSuccessToast
	} from '$lib/swal_helper.js';

	export let data;
	let isLoading = false;
	let config: SmtpConfiguration = data.config;

	async function handleFormSubmitted(event: Event) {
		event.preventDefault();
		const form: HTMLFormElement = event.target as HTMLFormElement;
		if (!form.checkValidity()) {
			return;
		}
		isLoading = true;
		const body = new FormData(form);
		const url = '/api/smtpconfig/save';
		const response = await fetch(url, {
			method: 'POST',
			body,
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		isLoading = false;
		if (response.ok) {
			const _config: SmtpConfiguration = await response.json();
			config = _config;
			fireSaveSuccessToast();
		} else {
			fireSaveErrorToast();
		}
	}

	async function testSmtpSettings(event: Event) {
		const form: HTMLFormElement = document.getElementById('smtpForm') as HTMLFormElement;
		if (!form) return;
		if (!form.checkValidity()) {
			return;
		}
		isLoading = true;
		const body = new FormData(form);
		const url = '/api/smtpconfig/test';
		const response = await fetch(url, {
			method: 'POST',
			body,
			headers: {
				Authorization: `Bearer ${data.user.token}`
			}
		});
		isLoading = false;
		if (response.ok) {
			fireSuccessToast('SMTP settings test performed successfuly');
		} else {
			fireErrorToast('SMTP settings test failed');
		}
	}
</script>

<form novalidate on:submit={handleFormSubmitted} id="smtpForm">
	<div class="p-2">
		<div class="grid grid-cols-1 md:grid-cols-2 gap-2">
			<div class="col-span-2">
				<LabeledInput
					id="smtpServerInput"
					name="smtpServer"
					bind:value={config.smtpClientName}
					required={true}
					label="SMTP Server"
					placeholder="SMTP Server"
				/>
			</div>
			<LabeledInput
				id="usernameInput"
				name="username"
				required={true}
				placeholder="User Name"
				label="User Name"
				bind:value={config.userName}
			/>
			<LabeldPasswordInput
				id="passwordInput"
				name="password"
				required={true}
				placeholder="Password"
				bind:value={config.password}
				label="Password"
			/>
			<LabeledInput
				label="Port"
				id="portInput"
				name="port"
				required={true}
				bind:value={config.smtpPort}
			/>
			<div class="flex">
				<div class="mt-auto mb-3">
					<ToggleButton bind:checked={config.enableSsl} name="enableSSL" label="Enable SSL" />
				</div>
			</div>
			<FormButton role="primary" type="submit" disabled={isLoading}>
				<span> Save Changes </span>
			</FormButton>
			<FormButton role="secondary" disabled={isLoading} on:click={testSmtpSettings}>
				<span> Test Settings </span>
			</FormButton>
		</div>
	</div>
</form>
