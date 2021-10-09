import ProductService from '@/services/ProductService';
import CartService from '@/services/CartService';
import { Auth } from '@/services/AuthService';
import { AxiosStatic } from 'axios';

declare module 'vue/types/vue' {
    // Instance properties (this.) can be declared on the `Vue` interface
    interface Vue {
        $mq: string;
        phone: boolean;
        tablet: boolean;
        mobile: boolean;
        laptop: boolean;
        desktop: boolean;
        $productService: ProductService;
        $cartService: CartService;
        $auth: Auth;
    }
}

declare module '@nuxt/types/app' {
    interface Context {
        $axios: AxiosStatic;
    }
}
