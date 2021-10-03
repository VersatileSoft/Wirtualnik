import Vue from 'vue';
import ProductService from '../services/ProductService';
import CartService from '../services/CartService';
import AuthService from '../services/AuthService';

export default function (context: any): void {
    Vue.prototype.$productService = new ProductService(context.$axios);
    Vue.prototype.$cartService = new CartService(context.$axios);
    Vue.prototype.$auth = new AuthService(context.store);
}
