import ProductService from '@/services/ProductService';
import CartService from '@/services/CartService';

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
    }
    // Global properties (Vue.) can be declared on the `VueConstructor` interface
}
