<template>
    <div class="container">
        <div class="productCardImage">
            <img
                v-if="product && product.images && product.images.length > 0"
                :src="product.images[0]"
                @click="$emit('showModal')"
            />
        </div>

        <div class="productDescription">
            <h2>{{ product.name }}</h2>
            <p>{{ product.description }}</p>

            <div>
                <button
                    @click="addToCart()"
                    class="btnGreen btnCircle btnBasic"
                >
                    <i class="las la-cart-plus"></i>Dodaj do koszyka
                </button>
                <div v-if="product.isInCart">Produkt w koszyku</div>
            </div>
        </div>
        <div class="productPoints">
            <div class="columnContainer">
                <div class="productPointsBox productPointsRed">
                    Gaming
                    <h5>123</h5>
                </div>
                <div class="productPointsBox productPointsBlue">
                    Pro
                    <h5>93</h5>
                </div>
                <div class="productPointsBox productPointsGrey">
                    Biuro
                    <h5>93</h5>
                </div>
            </div>
        </div>
    </div>
</template>
<script lang="ts">
import { Component, Prop, Vue } from 'nuxt-property-decorator';
import { Product } from '~/models/Product';

@Component({})
export default class ProductInformation extends Vue {
    @Prop({ default: null })
    public product: Product;

    private async addToCart(): Promise<void> {
        try {
            await this.$cartService.addToCart(this.product.publicId);
        } catch {
            console.log('error');
        }
        this.$emit('reload');
    }
}
</script>

<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
</style>
