<script lang="ts">
	import Form from '$lib/components/Form.svelte';
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
	import Button from '$lib/components/Button.svelte';

	export let data;
	let isLoading = false;
	let config: SmtpConfiguration = data.config;
	

	async function handleFormSubmitted(event: CustomEvent) {
	
		const body = event.detail as FormData;
		isLoading = true;

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

<div class="flex">
	<div class="w-full md:w-2/3 xl:w-1/2 mx-auto mt-0 lg:mt-8 xl:mt-10">
		<Form id="smtpForm" isCard={true} on:submit={handleFormSubmitted}>
			<span slot="title" class="space-x-2">
				<i class="bi bi-envelope-at"></i>
				<span>SMTP Configuration</span>
			</span>
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
				<Button buttonStyle="primary" type="submit" disabled={isLoading}>
					<span> Save Changes </span>
				</Button>
				<Button buttonStyle="secondary" disabled={isLoading} on:click={testSmtpSettings}>
					<span> Test Settings </span>
				</Button>
			</div>
		</Form>
	</div>
</div>
