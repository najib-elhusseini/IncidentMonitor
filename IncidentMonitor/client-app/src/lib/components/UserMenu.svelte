<script lang="ts">
	import { goto } from '$app/navigation';
	import { anon, localUserKey, loggedInUser, type User } from '$lib/stores/user_store';

	export let user: User;
	export let disabled = false;
	let isOpen = false;
	let menu: HTMLDivElement;

	function openMenu() {
		isOpen = true;
		setTimeout(() => {
			menu.style.gridTemplateRows = '1fr';
		}, 1);
	}
	function closeMenu() {
		menu.style.gridTemplateRows = '0fr';
		setTimeout(() => {
			isOpen = false;
		}, 300);
	}

	function logout(event: Event) {
		localStorage.removeItem(localUserKey);
		loggedInUser.set(anon);
		goto('/login');
	}
</script>

<div class="relative">
	<button
		type="button"
		data-checked={isOpen}
		on:click={openMenu}
		{disabled}
		class="px-2 py-1 text-slate-500 transition-all ease-in-out duration-300
             hover:text-indigo-500 data-[checked='true']:text-indigo-500 disabled:text-slate-300"
	>
		<i class="bi bi-person-fill" />
		<span>
			{user.userName}
		</span>
	</button>
	{#if isOpen}
		<!-- svelte-ignore a11y-click-events-have-key-events -->
		<!-- svelte-ignore a11y-no-static-element-interactions -->
		<div class="fixed inset-0 bg-transparent z-[1000]" on:click={closeMenu} />
		<div
			bind:this={menu}
			class="absolute z-[1001] right-0 bg-white border border-slate-300 min-w-[200px] rounded-md shadow-md
                    transition-all duration-300 ease-in-out grid"
			style="grid-template-rows: 0fr;"
		>
			<div class="overflow-hidden">
				<ul class="py-2 divide-y divide-slate-300">
					{#if user.isAdmin}
						<li>
							<a
								href="/settings"
								class="px-2 py-1 text-slate-500
                                hover:bg-slate-500/20 flex space-x-2 w-full
                                transition-all ease-in-out active:bg-slate-500 active:text-slate-50
                                focus:outline-none
                            "
								on:click={closeMenu}
							>
								<i class="bi bi-gear"></i>
								<span> Settings </span>
							</a>
						</li>
						<li>
							<a
								href="/assyst"
								class="px-2 py-1 text-slate-500
                                hover:bg-slate-500/20 flex space-x-2 w-full
                                transition-all ease-in-out active:bg-slate-500 active:text-slate-50
                                focus:outline-none
                            "
							>
								<img
									src="/resources/images/IFS_Logo.png"
									width="20"
									height="20"
									class="object-scale-down"
									alt="IFS Logo"
								/>
								<span>
									IFS Assyst
								</span>
							</a>
						</li>
					{/if}

					<li>
						<button
							type="button"
							class="px-2 py-1 text-slate-500
                            hover:bg-slate-500/20 flex space-x-2 w-full
                            transition-all ease-in-out active:bg-slate-500 active:text-slate-50
                            focus:outline-none"
						>
							<i class="bi bi-key"></i>
							<span> Change Password </span>
						</button>
					</li>
					<li>
						<button
							type="button"
							class="px-2 py-1 text-slate-500
                            hover:bg-slate-500/20 flex space-x-2 w-full
                            transition-all ease-in-out active:bg-slate-500 active:text-slate-50
                            focus:outline-none
                        "
							on:click={logout}
						>
							<i class="bi bi-box-arrow-in-right"></i>
							<span> Logout </span>
						</button>
					</li>
				</ul>
			</div>
		</div>
	{/if}
</div>
