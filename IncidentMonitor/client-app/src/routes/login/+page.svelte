<script lang="ts">
	import { goto, invalidateAll } from '$app/navigation';
	import Button from '$lib/components/Button.svelte';
	import Form from '$lib/components/Form.svelte';
	import LabeledInput from '$lib/components/LabeledInput.svelte';
	import LabeledPasswordBox from '$lib/components/LabeledPasswordBox.svelte';
	import { localUserKey, loggedInUser, type User } from '$lib/stores/user_store';
	let isLoading = false;

	async function login(event: SubmitEvent) {
		event.preventDefault();

		const form = event.target as HTMLFormElement;
		const toCheck: NodeListOf<HTMLInputElement> = form.querySelectorAll('[data-check="true"]');
		let valid = true;
		for (const input of toCheck) {
			if (!input.checkValidity()) {
				valid = false;
				input.setAttribute('data-invalid', 'true');
			} else {
				input.removeAttribute('data-invalid');
			}
		}
		if (!valid) {
			return;
		}
		isLoading = true;
		const data = new FormData(form);
		const url = '/api/users/Login';
		const response = await fetch(url, {
			method: 'POST',
			body: data
		});
		isLoading = false;
		if (response.ok) {
			const data: User = await response.json();

			const userData = JSON.stringify(data);

			localStorage.setItem(localUserKey, userData);
			if (data) {
				await invalidateAll();
				loggedInUser.set(data);
				goto('/');
			}
		}
	}

	async function handleSubmit(event: CustomEvent) {
		const data = event.detail as FormData;
		isLoading = true;
		const url = '/api/users/Login';
		const response = await fetch(url, {
			method: 'POST',
			body: data
		});
		isLoading = false;
		if (response.ok) {
			const data: User = await response.json();

			const userData = JSON.stringify(data);

			localStorage.setItem(localUserKey, userData);
			if (data) {
				await invalidateAll();
				loggedInUser.set(data);
				goto('/');
			}
		}
	}
</script>

<div class="flex w-full min-h-screen bg-gradient-to-br from-slate-50 to-slate-300">
	<div class="mx-auto mt-4 md:mt-20 mb-auto w-full md:w-1/2 lg:w-1/3">
		<Form isCard={true} allowSubmit={true} on:submit={handleSubmit} {isLoading}>
			<div slot="title" class="flex-grow">
				<img
					src="/resources/images/hoist_gear.png"
					alt="HOIST gear"
					width="48"
					height="48"
					class="mx-auto"
				/>
				<h2 class="text-2xl font-bold py-4 text-center text-slate-600">Login - Incident Monitor</h2>
			</div>
			<div>
				<LabeledInput
					id="userNameInput"
					name="username"
					placeholder="Your user name"
					required={true}
					label="User Name"
				/>
			</div>
			<div>
				<LabeledPasswordBox
					id="passwordInput"
					label="Password"
					name="password"
					required={true}
					validationText="Please enter a valid password"
					placeholder="Your password"
				/>
			</div>

			<div class="grid my-2">
				<Button type="submit">
					<span> Login </span>
				</Button>
			</div>
		</Form>
	</div>
</div>
<!-- 
	<div
		class="mx-auto mt-4 md:mt-20 mb-auto min-w-[400px] lg:min-w-[500px] border border-slate-300
			rounded-md p-2 md:px-4 lg:px-8 lg:py-4 bg-white shadow-lg"
	>
		<form method="post" on:submit={login} novalidate>
			<div>
				<div>
					<div class="flex">
						<img
							src="/resources/images/hoist_gear.png"
							alt="HOIST gear"
							width="48"
							height="48"
							class="mx-auto"
						/>
					</div>
					<h2
						class="text-2xl font-bold py-4 border-b border-b-slate-400 text-center text-slate-600"
					>
						Login - Incident Monitor
					</h2>
				</div>
				<label for="userNameInput" class="text-slate-500 my-1 block"> User name *</label>
				<input
					placeholder="Your username"
					data-check="true"
					type="text"
					name="username"
					id="userNameInput"
					required={true}
					class="border peer border-slate-300 block w-full py-1 px-2 rounded-md shadow-sm
					 bg-white text-neutral-900
						focus:outline-none focus:ring focus:ring-sky-500/20
						dark:focus:ring-sky-500/30 read-only:bg-neutral-100
						placeholder:text-sm placeholder:font-thin
						dark:bg-slate-900 dark:text-neutral-100 dark:border-slate-600
						data-[invalid]:border-pink-600 data-[invalid]:focus:ring-pink-600/20
						"
				/>
				<span class="hidden peer-data-[invalid]:block text-sm text-rose-500">
					Please enter a valid username
				</span>
			</div>
			

			<div class="grid my-4">
				<button
					type="submit"
					class="rounded-md bg-indigo-500 text-indigo-50 px-2 py-1.5
					 hover:bg-indigo-600 focus:outline-none focus:ring active:ring
					 ring-indigo-500/20"
				>
					Login
				</button>
			</div>
		</form>
	</div>
</div> -->
