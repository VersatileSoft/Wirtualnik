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
import { CartSimpleModel } from '~/services/CartService';

@Component({})
export default class ProductInformation extends Vue {
    @Prop({ default: null })
    public product: Product;

    public get id(): string {
        return this.product.publicId;
    }

    public get currentCart(): CartSimpleModel {
        return this.$store.state.cart?.currentCart ?? null;
    }

    private async addToCart(): Promise<void> {
        try {
            let result = await this.$cartService.addToCart(
                this.product.publicId
            );
            var model: CartSimpleModel = {
                temporaryId: result.temporaryId ?? '',
                quantity: result.quantity,
                products: result.products
            };

            this.$store.commit('cart/setCurrentCart', model);
            localStorage.setItem(
                'cartId',
                result.temporaryId?.toString() ?? ''
            );
        } catch {
            localStorage.removeItem('cartId');
            this.$store.commit('cart/setCurrentCart', null);
        }
        this.$emit('reload');
    }
}
</script>

<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
</style>
