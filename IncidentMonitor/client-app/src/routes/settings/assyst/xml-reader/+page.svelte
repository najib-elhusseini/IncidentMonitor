<script lang="ts">
	import { generateCSharpCode, generateTypeScriptCode } from '$lib/code-gen/code-gen-helper';
	import Button from '$lib/components/Button.svelte';
	import LabeledSelect from '$lib/components/LabeledSelect.svelte';
	import SearchBar from '$lib/components/SearchBar.svelte';
	import { onMount } from 'svelte';
	type AxiosTypes = 'xs:element' | 'xs:complexType' | 'xs:simpleType' | string;

	let typesToShow: AxiosTypes = 'xs:complexType';
	let query: string = '';
	let elemntsQuery = '';
	let xmlDoc: Document;
	let complexTypes: Element[] = [];
	let contextComplexType: Element;
	let typesFiltered: Element[] = [];
	let contextTypeMembers: Element[] = [];
	let contextTypeMembersFiltered: Element[] = [];
	let contextMember: Element | undefined;
	let parentTypeName: string = '';
	let xmlToShow: 'events' | 'actions' = 'actions';
	let languages: 'cs' | 'ts' = 'cs';

	$: {
		if (!query) {
			typesFiltered = complexTypes;
		} else {
			typesFiltered = [];
			for (const type of complexTypes) {
				let name = type.getAttribute('name') ?? '';
				name = name.toLowerCase();
				if (name.includes(query.toLowerCase())) {
					typesFiltered.push(type);
				}
			}
			typesFiltered = typesFiltered;
		}
		if (!elemntsQuery) {
			contextTypeMembersFiltered = contextTypeMembers;
		} else {
			contextTypeMembersFiltered = [];
			for (const type of contextTypeMembers) {
				let name = type.getAttribute('name') ?? '';
				name = name.toLowerCase();
				if (name.includes(elemntsQuery.toLowerCase())) {
					contextTypeMembersFiltered.push(type);
				}
			}
			contextTypeMembersFiltered = contextTypeMembersFiltered;
		}
	}

	function selectType(element: Element) {
		contextComplexType = element;
		if (typesToShow === 'xs:complexType') {
			selectComplexTypeElements();
		} else {
			selectSimpleTypeElements();
		}
	}

	function selectComplexTypeElements() {
		let extension = contextComplexType.getElementsByTagName('xs:extension')[0];
		if (extension) {
			parentTypeName = extension.getAttribute('base') ?? '';
		} else {
			parentTypeName = '';
		}
		let sequence = contextComplexType.getElementsByTagName('xs:sequence')[0];
		if (sequence) {
			let sequenceElements = sequence.getElementsByTagName('xs:element');
			contextTypeMembers = [];
			for (const child of sequenceElements) {
				contextTypeMembers.push(child);
			}
			contextTypeMembers = [...contextTypeMembers];
		}
	}

	function selectSimpleTypeElements() {
		const restriction = contextComplexType.getElementsByTagName('xs:restriction');
		const elems = contextComplexType.getElementsByTagName('xs:enumeration');

		contextTypeMembers = [];
		for (const elem of elems) {
			contextTypeMembers.push(elem);
		}
		contextTypeMembers = [...contextTypeMembers];
		elemntsQuery = '';
		contextTypeMembersFiltered = [...contextTypeMembers];
		console.log(contextTypeMembersFiltered, contextTypeMembers);
	}

	function addComplexType(element: Element) {
		complexTypes.push(element);
	}

	function addSimpleType(element: Element) {
		complexTypes.push(element);
	}

	function getName(elem: Element) {
		let name = elem.getAttribute('name') ?? '';
		if (!name) {
			let value = elem.getAttribute('value');
			if (value) {
				name = value;
			}
		}
		return name;
	}

	function switchTypes() {
		let base: Element = xmlDoc.children[0];
		complexTypes = [];
		for (const child of base.children) {
			const tagName: AxiosTypes = child.tagName;

			switch (tagName) {
				case 'xs:complexType':
					if (typesToShow === 'xs:complexType') {
						addComplexType(child);
					}
					break;
				case 'xs:simpleType':
					if (typesToShow === 'xs:simpleType') {
						addSimpleType(child);
					}
					break;
				default:
					break;
			}
		}
		complexTypes = [...complexTypes];
	}

	async function getXmlData() {
		let fileName = xmlToShow === 'events' ? 'events.xml' : 'actions-schema.xml';
		const url = `/resources/data/${fileName}`;
		let xmlData = '';
		const response = await fetch(url);
		if (response.ok) {
			const text = await response.text();
			xmlData = text;
		}
		const parser = new DOMParser();
		xmlDoc = parser.parseFromString(xmlData, 'text/xml');
		switchTypes();
	}

	function generateCode() {
		if (!contextComplexType) return;
		let code: string = '';
		if (languages === 'cs') {
			code = generateCSharpCode(contextComplexType);
		} else {
			code = generateTypeScriptCode(contextComplexType);
		}
		console.log(code);
		navigator.clipboard.writeText(code);
	}

	onMount(() => {
		getXmlData();
	});
</script>

<div class="p-2">
	<div class=" grid grid-cols-4 mt-2 mb-4 gap-x-4">
		<LabeledSelect labelText="Object Schema" bind:value={xmlToShow} on:change={getXmlData}>
			<option value="events">events</option>
			<option value="actions">actions</option>
		</LabeledSelect>

		<LabeledSelect labelText="Object Type" bind:value={typesToShow} on:change={switchTypes}>
			<option value="xs:complexType"> Complex Types </option>
			<option value="xs:simpleType"> Simple Types </option>
		</LabeledSelect>
		<LabeledSelect labelText="Programming language" bind:value={languages}>
			<option value="cs">C Sharp</option>
			<option value="ts">Type Script</option>
		</LabeledSelect>
		<div class="flex">
			<Button
				type="button"
				buttonStyle="primary"
				customCss="mt-auto flex-grow"
				on:click={generateCode}
			>
				<i class="bi bi-braces-asterisk"></i>
				<span> Generate Code </span>
			</Button>
		</div>
	</div>
	<div class="grid grid-cols-2 gap-x-2">
		<div class="border border-slate-300 rounded-md bd-slate-50">
			<div class="py-2 px-2 border-b border-b-slate-300 shadow-sm">
				<SearchBar bind:value={query} placeholder="search types" />
			</div>
			<div style="height: 300px;" class="overflow-y-scroll">
				{#each typesFiltered as complexType}
					<div>
						<button
							data-checked={complexType === contextComplexType}
							type="button"
							class="py-1.5 px-2 hover:bg-slate-200 w-full
						text-left active:bg-slate-400 active:text-slate-50
						data-[checked='true']:bg-slate-400 data-[checked='true']:text-slate-50
						"
							on:click={() => selectType(complexType)}
						>
							{getName(complexType)}
						</button>
					</div>
				{/each}
			</div>
		</div>
		<div class="border border-slate-300 rounded-md bd-slate-50">
			<div class="p-2 border-b border-b-slate-300 shadow-sm">
				<SearchBar bind:value={elemntsQuery} placeholder="search elements" />
			</div>
			<div style="height: 300px;" class="overflow-y-scroll">
				{#if contextTypeMembersFiltered}
					{#each contextTypeMembersFiltered as member}
						<div>
							<button
								data-checked={member === contextMember}
								type="button"
								class="py-1.5 px-2 hover:bg-slate-200 w-full
						text-left active:bg-slate-400 active:text-slate-50
						data-[checked='true']:bg-slate-400 data-[checked='true']:text-slate-50
						"
								on:click={() => (contextMember = member)}
							>
								{getName(member)}
							</button>
						</div>
					{/each}
				{/if}
			</div>
		</div>
		<div class="border border-slate-300 my-2">
			{#if contextComplexType}
				<table class="w-full">
					<tr class="border-b border-b-slate-300">
						<th class="text-left px-2 py-1.5 border-r border-r-slate-300 w-1/2"> Name </th>
						<td class="px-2 py-1.5">
							{getName(contextComplexType)}
						</td>
					</tr>
					{#if parentTypeName}
						<tr class="border-b border-b-slate-300">
							<th class="text-left px-2 py-1.5 border-r border-r-slate-300 w-1/2"> Base </th>
							<td class="px-2 py-1.5">
								{parentTypeName}
							</td>
						</tr>
					{/if}
					{#if contextMember}
						<tr class="border-b border-b-slate-300">
							<th class="text-left px-2 py1.52 border-r border-r-slate-300 w-1/2"> Member Name </th>
							<td class="px-2 py-1.5">
								{getName(contextMember)}
							</td>
						</tr>
						<tr class="border-b border-b-slate-300">
							<th class="text-left px-2 py-1.5 border-r border-r-slate-300 w-1/2"> Data Type </th>
							<td class="px-2 py-1.5">
								{contextMember.getAttribute('type')}
							</td>
						</tr>
					{/if}
				</table>
			{/if}
		</div>
	</div>
</div>
