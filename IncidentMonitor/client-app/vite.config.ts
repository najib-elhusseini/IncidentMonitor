import { sveltekit } from '@sveltejs/kit/vite';
import { defineConfig } from 'vite';
import mkcert from 'vite-plugin-mkcert'

export default defineConfig({
	plugins: [sveltekit(),mkcert()],
	server: {
		https:true,
		proxy: {			
			'/api': {
				target: 'https://localhost:7217/',
				changeOrigin: true,
				secure: false,
				rewrite: (path) => path.replace(/^\/api/, '/api')
			},
			'/server-res':{
				target: 'https://localhost:7217/',
				changeOrigin: true,
				secure: false,
				rewrite: (path) => path.replace(/^\/server-res/, '/server-res')
			}
	
		}
	},
});
