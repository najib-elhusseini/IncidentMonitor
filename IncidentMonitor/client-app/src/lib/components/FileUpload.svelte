<script lang="ts">
	export let id: string | undefined = undefined;
	export let name: string | undefined = undefined;
    
</script>

<label>
    <i class="bi bi-paperclip"></i>
    <input type="file" class="hidden" {id} {name}/>
</label>
