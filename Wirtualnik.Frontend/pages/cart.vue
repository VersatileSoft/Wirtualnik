<template>
    <div class="container">
        <div
            class="productCard"
            style="max-width: 100%; background: var(--white); width: 100rem"
        >
            <CartProduct v-if="cart" :items="cart.products" />
            <br />
            <CartWarningList />
        </div>
        <!-- True discounts -->
    </div>
</template>
<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator';
import CartProduct from '~/components/common/CartProduct.vue';
import CartWarningList from '~/components/common/CartWarningList.vue';
import CartProp from '~/components/common/CartProp.vue';
import { DetailsModel } from '~/services/CartService';

@Component({
    components: {
        CartProduct,
        CartWarningList,
        CartProp
    }
})
export default class Cart extends Vue {
    private get cart(): DetailsModel {
        return this.$store.state.cart.currentCart;
    }

    public async created(): Promise<void> {
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
