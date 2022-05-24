import { defineNuxtConfig } from 'nuxt'

// https://v3.nuxtjs.org/api/configuration/nuxt.config
export default defineNuxtConfig({
    app: {
        head: {
            title: 'Wirtualnik',
            meta: [
                { charset: 'utf-8' },
                { 
                    name: 'viewport', 
                    content: 'width=device-width, initial-scale=1' 
                },
                { hid: 'description', name: 'description', content: '' }  
            ],
            script: [
                {
                    src: 'https://connect.facebook.net/pl_PL/sdk.js#xfbml=1&version=v11.0',
                    async: true,
                    crossorigin: 'anonymous',
                    nonce: 'fqQMlKDG'
                }
            ],
            link: [
                { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' },
                { rel: 'preconnect', href: 'https://fonts.googleapis.com' },
                {
                    rel: 'preconnect',
                    href: 'https://fonts.gstatic.com',
                    crossorigin: true
                }
            ]
        }
    }
})
