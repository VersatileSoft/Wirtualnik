<template>
    <div class="container">
        <div
            class="productCard"
            style="max-width: 100%; background: var(--white)"
        >
            <CartProduct :items="cartItems">
                <template #quantity-in-cart>
                    Twój koszyk ({{ response.quantity }} przedmiotów)
                </template>
            </CartProduct>
            <CartProp />
            <!-- Warnings TODO -->
            <CartWarningList />
        </div>
        <!-- True discounts -->
    </div>
</template>
<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator';
import BreadCrumb from '@/components/navigation/Breadcrumb';
import CartProduct from '@/components/common/CartProduct';
import CartWarningList from '@/components/common/CartWarningList';
import CartProp from '@/components/common/CartProp';
import { CartSimpleModel } from '~/services/CartService';
import { Product } from '~/models/Product';

@Component({
    name: 'cart',
    components: {
        CartProduct,
        CartWarningList,
        CartProp,
        BreadCrumb
    }
})
export default class Cart extends Vue {
    private cartId!: string;
    private response: [] = [];
    private cartItems: Product[] = [];

    public async created(): Promise<void> {
        await this.loadData();
        console.log(this.cartItems);
        this.$store.commit('breadcrumb/SET_BREADCRUMBS', [
            {
                name: 'Wirtualnik.pl',
                route: '/'
            },
            {
                name: 'Koszyk',
                route: '/cart'
            }
        ]);
    }

    private async loadData(): Promise<void> {
        this.response = await this.$cartService.getCart();
        this.cartItems = this.response.products;
    }
}
</script>
<style lang="scss">
@import url('@//assets/shadient/shadient.css');
body {
    background-color: var(--background);
    font-family: 'Poppins Devanagari', -apple-system, BlinkMacSystemFont,
        'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji',
        'Segoe UI Emoji', 'Segoe UI Symbol';
    min-width: 320px;
    font-size: 15px;
    max-width: 1280px;
    margin: 0 auto;
}
a {
    text-decoration: none;
}
@keyframes fadeIn {
    from {
        opacity: 0;
        transform: translate3d(0, 10px, 0);
    }
    to {
        opacity: 1;
        transform: translate3d(0, 0, 0);
    }
}
</style>
