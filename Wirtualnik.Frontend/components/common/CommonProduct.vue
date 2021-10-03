<template>
    <div class="productCard">
        <div class="productCardImage ProductCardGlowOrange">
            <nuxt-link :to="`/p/` + product.publicId">
                <img
                    :src="product.image"
                    alt="Zdjęcie produktu"
                    loading="lazy"
                />
            </nuxt-link>
        </div>
        <h2>{{ product.name }}</h2>
        <h4>
            495.00 PLN
            <!-- {{ commonProduct.price }} -->

            <img :src="product.productShopDetails.image" alt="Morele.net" />
        </h4>
        <p v-for="property in product.properties" :key="property.key">
            {{ property.key }}
            {{ property.value }}
        </p>
        <div class="productPoints">
            <div class="productPointsBox productPointsRed">
                Gaming
                <h5>123</h5>
            </div>
            <div class="productPointsBox productPointsBlue">
                Pro
                <h5>93</h5>
            </div>
        </div>
        <div class="productCardButtons">
            <i class="las la-balance-scale btnCircle btnGreen"></i
            ><i class="las la-cart-plus btnCircle btnGreen"></i>
        </div>
    </div>
</template>
<script lang="ts">
import { Component, Prop, Vue } from 'nuxt-property-decorator';

import { Product } from '~/models/Product';

@Component({})
export default class CommonProduct extends Vue {
    @Prop({ default: null })
    private product: Product;
}
</script>
<style scoped>
@import url('@//assets/shadient/shadient.css');
</style>
