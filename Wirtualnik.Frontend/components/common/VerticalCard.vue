<template>
    <div class="product-card product-card__vertical">
        <div class="vertical__img prodict-card__img product-card__card-image">
            <img :src="item.image" />
        </div>
        <div class="product-card__card-title">
            <h2>{{ item.name }}</h2>
            <h6 v-if="item.isInCart">W koszyku</h6>
        </div>
        <div class="vertical__product-promo">
            <sub> {{ item.price }} PLN </sub>
        </div>
        <div class="product-card__product-price">
            <h4 class="vertical__price">
                {{ item.price }} PLN
                <img src="~/assets/images/shop/xkom-sygnet.png" />
            </h4>
        </div>
        <div class="product-card__product-short-specs vertical__specs">
            <p v-for="(prop, index) in item.properties" :key="index">
                {{ prop.key }}: {{ prop.value }}
            </p>
        </div>
        <div class="vertical__price-list">
            <button class="btn-miniprice">
                <a href="#">
                    <img src="~/assets/images/shop/xkom-sygnet.png" />
                    542.00
                </a>
            </button>
            <button class="btn-miniprice">
                <a href="#">
                    <img src="~/assets/images/shop/morele-sygnet.png" />
                    542.00
                </a>
            </button>
        </div>
        <div class="product-card__card-controls">
            <div class="product-card__buttons">
                <button class="btn-circle btn-green">
                    <span class="las la-balance-scale"></span>
                </button>
                <button class="btn-circle btn-green" @click="addToCart">
                    <span class="las la-cart-plus"></span>
                </button>
            </div>
        </div>
    </div>
</template>
<script lang="ts">
import { Component, Prop, Vue } from 'nuxt-property-decorator';
import { Product } from '~/models/Product';

@Component({})
export default class VerticalCard extends Vue {
    @Prop({ default: null })
    private item: Product;

    private async addToCart(): Promise<void> {
        try {
            await this.$cartService.addToCart(this.item.publicId);
        } catch {
            console.log('error');
        }
        this.$emit('reload');
    }
}
</script>

<style lang="scss">
.product-card {
    &__vertical {
        max-width: 375px;
        flex: 1 1 30%;
        min-width: 300px;
        margin-bottom: 40px;
    }
}
.vertical {
    &__img {
        width: 33%;
        float: left;
    }
    &__product-promo sub {
        color: var(--gray3);
        margin-top: -10px;
        display: block;
        text-decoration: line-through;
    }
    &__price {
        color: var(--blue) !important;
        font-weight: 700 !important;
        margin-top: 0px;
    }
    &__specs p {
        margin-left: 33%;
    }
    &__price-list {
        display: flex;
        width: 87%;
        flex-wrap: wrap;
        margin-top: 20px;
    }
}
</style>
