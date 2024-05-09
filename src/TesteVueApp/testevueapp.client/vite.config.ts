import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';

export default defineConfig({
    plugins: [vue()],
    resolve: {
        alias: {
            '@': '/src'
        }
    },
    server: {
        proxy: {
            '^/apiknight': {
                target: 'http://microsservice_knights:8089/',
                secure: false
            }
        },
        port: 5173
        //https: false // Desabilita o suporte a HTTPS durante o desenvolvimento
    }
});
