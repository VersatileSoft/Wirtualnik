<template>
    <div class="cart">
        <div class="list bigList currency biggerThumbs">
            <h3><slot name="quantity-in-cart"></slot></h3>
            <li v-for="(item, index) in items" :key="item">
                <img :src="item.image" /><a :href="'p' + item.publicId">
                    {{ item.name }}<br />
                    <sub>{{ item.productTypeName }}</sub> </a
                ><a :href="item.productShopDetails.refLink"></a>
                <p>
                    {{ item.productShopDetails.price
                    }}<img
                        :src="item.productShopDetails.cleanLink"
                        :alt="item.productShopDetails.name"
                    />
                </p>

                <span
                    class="las la-angle-down"
                    v-show="productDetails[index] === false"
                    v-on:click="showDetails(index)"
                ></span>
                <span
                    class="las la-angle-up"
                    v-on:click="showDetails(index)"
                    v-show="productDetails[index] === true"
                ></span>
                <div
                    class="productExtraInfo"
                    v-show="productDetails[index] === true"
                >
                    <div class="pcs-controls">
                        <i class="las la-angle-up"></i>
                        <span>1x</span>
                        <i class="las la-angle-down"></i>
                    </div>
                    <button class="btnRed btnCircle btnBasic">
                        <i class="las la-trash"></i>Usuń produkt
                    </button>
                </div>
            </li>
        </div>
    </div>
</template>
<script lang="ts">
import { Component, Vue, Prop } from 'nuxt-property-decorator';
import { Product } from '~/models/Product';
@Component({
    name: 'CartProduct',
    props: {
        items: []
    }
})
export default class CartProduct extends Vue {
    public items: [] = [];
    public productDetails: boolean[] = [];

    public async created(): Promise<void> {
        await this.loadData();
        this.productDetails = new Array(this.response.quantity).fill(false);

        await this.showDetails(0);
    }

    private async loadData(): Promise<void> {
        this.response = await this.$cartService.getCart();
    }

    private async showDetails(index) {
        this.productDetails[index] = !this.productDetails[index];
    }
}
</script>
<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
</style>
