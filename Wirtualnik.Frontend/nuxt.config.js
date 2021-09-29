/* eslint-disable no-undef */
import path from 'path';
import fs from 'fs';

module.exports = {
    // Target: https://go.nuxtjs.dev/config-target
    target: 'server',

    // Global page headers: https://go.nuxtjs.dev/config-head
    head: {
        title: 'Wirtualnik',
        bodyAttrs: {
            'data-theme': 'light'
        },
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
            },
            {
                rel: 'stylesheet',
                href: 'https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,300;0,400;0,900;1,300;1,600&display=swap'
            }
        ]
    },

    // Global CSS: https://go.nuxtjs.dev/config-css
    css: [
        '@/assets/scss/main.scss',
        '@/assets/scss/_mixins.scss',
        '@/assets/line-awesome/1.3.0/css/line-awesome.min.css',
        '@/assets/scss/icons.scss'
    ],
    // Plugins to run before rendering page: https://go.nuxtjs.dev/config-plugins
    plugins: [
        '@/plugins/vueMq.ts',
        '@/plugins/services.ts',
        { src: '@/plugins/vue-awesome-swiper.ts', mode: 'client' },
        { src: '@/plugins/paginator.ts', mode: 'client' }
    ],

    // Auto import components: https://go.nuxtjs.dev/config-components
    components: true,

    // Modules for dev and build (recommended): https://go.nuxtjs.dev/config-modules
    buildModules: [
        // https://go.nuxtjs.dev/typescript
        '@nuxt/typescript-build',
        // style resources
        '@nuxtjs/style-resources',
        // dotenv
        '@nuxtjs/dotenv'
    ],

    styleResources: {
        scss: ['@/assets/scss/_mixins.scss']
    },

    // Modules: https://go.nuxtjs.dev/config-modules
    modules: [
        // https://go.nuxtjs.dev/axios
        '@nuxtjs/axios',
        // https://go.nuxtjs.dev/pwa
        '@nuxtjs/pwa',
        [
            'nuxt-mq',
            {
                // Default breakpoint for SSR
                defaultBreakpoint: 'sm',
                breakpoints: {
                    xs: 450,
                    sm: 800,
                    md: 1100,
                    lg: 1400,
                    xl: Infinity
                }
            }
        ]
    ],

    generate: {
        fallback: '404.html'
    },

    // Axios module configuration: https://go.nuxtjs.dev/config-axios
    axios: {
        baseURL: process.env.VUE_APP_API_URL
    },

    publicRuntimeConfig: {
        axios: {
            baseURL: process.env.VUE_APP_API_URL
        }
    },

    // PWA module configuration: https://go.nuxtjs.dev/pwa
    pwa: {
        manifest: {
            lang: 'en'
        }
    },

    // Build Configuration: https://go.nuxtjs.dev/config-build
    build: {},

    // enable loading bar
    loading: {
        height: '3px',
        continuous: true,
        throttle: 0
    },

    // // configure server
    // server: {
    //     https: {
    //         key: fs.readFileSync(path.resolve(__dirname, 'server.key')),
    //         cert: fs.readFileSync(path.resolve(__dirname, 'server.crt'))
    //     }
    // }
};
