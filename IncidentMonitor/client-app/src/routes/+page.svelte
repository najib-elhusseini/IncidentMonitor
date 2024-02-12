<script lang="ts">
    async function getCount() {
        const url = '/api/remedyforceincidents/gettest';
        const response = await fetch(url);
        if(response.ok){
            const result = await response.text();
            console.log(result)
        }
    }
</script>

<h1>Welcome to SvelteKit</h1>
<button type="button" on:click={getCount}>Get count</button>
