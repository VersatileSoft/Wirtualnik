<template>
    <div class="container">
        <div
            class="productCard"
            style="max-width: 100%; background: var(--white)"
        >
            <CartProduct />
            <CartWarningList />
            <div class="pricelist fullwidth">
                <button class="btnPrice best">
                    <img
                        src="static\img\shop\morele-sygnet.png"
                        alt="Morele.net"
                    />
                    <h4>Morele.net</h4>
                    5462.32
                </button>
                <button class="btnPrice">
                    <img src="static\img\shop\xkom-sygnet.png" alt="X-kom" />
                    <h4>X-kom</h4>
                    5492.32
                </button>
                <button class="btnPrice">
                    <img
                        src="static\img\shop\euro-sygnet.png"
                        alt="RTV Euro AGD"
                    />
                    <h4>RTV Euro AGD</h4>
                    6462.32
                </button>
                <button class="btnPrice">
                    <img src="static\img\shop\oleole-sygnet.png" alt="OleOle" />
                    <h4>OleOle</h4>
                    6762.32
                </button>
                <button class="btnPrice">
                    <img
                        src="static\img\shop\mediaexpert-sygnet.png"
                        alt="MediaExpert"
                    />
                    <h4>MediaExpert</h4>
                    6962.32
                </button>
                <button class="btnPrice">
                    <img
                        src="static\img\shop\proline-sygnet.png"
                        alt="ProLine"
                    />
                    <h4>ProLine</h4>
                    2962.64 ⚠️
                </button>
            </div>
            <h3>Więcej o tym Wirtualniku</h3>
            <div class="list col-3">
                <CartProp />
            </div>
        </div>
        <!-- True discounts -->
    </div>
</template>
<script lang="ts">
import { Component, Vue, Prop } from 'nuxt-property-decorator';
import BreadCrumb from '@/components/navigation/Breadcrumb.vue';
import CartProduct from '@/components/common/CartProduct';
import CartWarningList from '@/components/common/CartWarningList';
import CartProp from '@/components/common/CartProp';

@Component({
    name: 'cart',
    components: {
        CartProduct,
        CartWarningList,
        CartProp,
        BreadCrumb
    }
})
export default class cart extends Vue {
    private cartId!: string;
    public async created(): Promise<void> {
        this.category = this.$route.params.category;

        this.$store.commit('breadcrumb/SET_BREADCRUMBS', [
            {
                name: 'Wirtualnik.pl',
                route: '/'
            },
            {
                name: 'Koszyk',
                route: '/ca/' + this.cartId
            }
        ]);
    }
}
</script>
<style lang="scss" scoped>
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
