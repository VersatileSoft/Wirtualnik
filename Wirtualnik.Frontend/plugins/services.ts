import Vue from 'vue';
import ProductService from '../services/ProductService';
import CartService from '../services/CartService';
import AuthService from '../services/AuthService';
import { Context } from '@nuxt/types';

export default function (context: Context): void {
    Vue.prototype.$productService = new ProductService(context.$axios);
    Vue.prototype.$cartService = new CartService(context.$axios);
    Vue.auth = Vue.prototype.$auth = new AuthService(context.store);
}
