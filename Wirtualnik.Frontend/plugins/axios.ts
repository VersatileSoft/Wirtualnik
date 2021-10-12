import Vue from 'vue';
import { Context } from '@nuxt/types';
import { AxiosStatic } from 'axios';
import { DetailsModel } from '../services/CartService';

export default function (context: Context): void {
    if (process.client) {
        const axios = context.$axios as AxiosStatic;
        axios.interceptors.request.use((config) => {
            config.headers.common['cart-id'] = localStorage.getItem('cartId');
            if (Vue.auth.token()) {
                config.headers.Authorization = `Bearer ${Vue.auth.token()}`;
            }

            return config;
        });

        axios.interceptors.response.use((config) => {
            const cart = config.data as DetailsModel;

            if (cart?.temporaryId) {
                localStorage.setItem('cartId', cart.temporaryId);
                context.store.commit('cart/setCurrentCart', cart);
            }

            return config;
        });
    }
}
