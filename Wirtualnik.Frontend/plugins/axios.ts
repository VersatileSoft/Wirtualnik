import Vue from 'vue';
import ProductService from '../services/ProductService';
import CartService from '../services/CartService';

export default function ({ $axios }: any): void {
    Vue.prototype.$productService = new ProductService($axios);
    Vue.prototype.$cartService = new CartService($axios);
}
