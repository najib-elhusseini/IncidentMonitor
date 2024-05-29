<script lang="ts">
	import { AssystEventActionTypes } from '$lib/models/assyst';
	import type { EventDto } from '$lib/models/assyst-event';
	import type { AssystUserDto } from '$lib/models/assyst-user';
	import LabeledSelect from './LabeledSelect.svelte';
	import LabeledTextArea from './LabeledTextArea.svelte';

	export let event: EventDto;
	export let eventActionTypeId: AssystEventActionTypes;
	export let assystUsers: AssystUserDto[];
    export let externalUserId = '-1';
	let externalUserShortCode: string | undefined = undefined;

    function handleAssysUserChanged(event: Event) {
		const target = event.target as HTMLSelectElement;
		let value: number | string | undefined = target.value;
		externalUserShortCode = undefined;
		if (value === undefined) {
			return;
		}
		value = Number(value);
		for (const assystUser of assystUsers) {
			if (assystUser.id === value) {
				externalUserShortCode = assystUser.shortCode;
				break;
			}
		}
	}

</script>

<div class="my-4 grid gap-y-2">
	<input type="hidden" name="eventActionTypeId" value={eventActionTypeId} />
	<input type="hidden" name="eventId" bind:value={event.id} />
    <input type="hidden" name="shortCode" bind:value="{externalUserShortCode}"/>
	<LabeledTextArea labelText="Description" required={true} name="remarks"></LabeledTextArea>
	<LabeledSelect
		labelText="Assyst User"
		value={externalUserId}
		
		on:change={handleAssysUserChanged}
		required={true}
	>
		<option value="-1"> ---Select User--- </option>
		{#each assystUsers as _user (_user.id)}
			<option value={_user.id}>
				{_user.name}
			</option>
		{/each}
	</LabeledSelect>
</div>
