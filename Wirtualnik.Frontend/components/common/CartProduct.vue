<template>
    <div class="cart">
        <div class="list bigList currency biggerThumbs">
            <h3><slot name="quantity-in-cart"></slot></h3>
            <li v-for="item in items" :key="item">
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
                <span class="las la-angle-up"></span>

                <!-- Extra info todo
                <div class="productExtraInfo">
                    <div class="pcs-controls">
                        <i class="las la-angle-up"></i>
                        <span>1x</span>
                        <i class="las la-angle-down"></i>
                    </div>
                    <button class="btnRed btnCircle btnBasic">
                        <i class="las la-trash"></i>Usuń produkt
                    </button>
                </div>
                -->
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
}
</script>
<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
</style>
