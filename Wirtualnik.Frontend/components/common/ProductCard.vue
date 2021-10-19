<template>
    <a>
        <div class="product-card">
            <div
                class="product-card__card-image product-card__image-glow-orange"
            >
                <nuxt-link :to="`/p/` + item.publicId">
                    <img :src="item.image" />
                </nuxt-link>
            </div>
            <div class="product-card__card-title">
                <h2>
                    <nuxt-link :to="`/p/` + item.publicId">
                        {{ item.name }}
                    </nuxt-link>
                </h2>
                <h6 v-if="item.isInCart">W koszyku</h6>
            </div>
            <div class="product-card__product-price">
                <h4>495.00 PLN</h4>
                <img src="~/assets/images/shop/morele-sygnet.png" />
            </div>
            <div class="product-card__product-short-specs">
                <p v-for="(prop, index) in item.properties" :key="index">
                    {{ prop.key }}: {{ prop.value }}
                </p>
            </div>
            <div class="product-card__card-controls">
                <div
                    class="
                        product-card__product-points-red
                        product-card__points-box
                    "
                >
                    Gaming
                    <h5>123</h5>
                </div>
                <div
                    class="
                        product-card__product-points-blue
                        product-card__points-box
                    "
                >
                    Pro
                    <h5>93</h5>
                </div>
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
    </a>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'nuxt-property-decorator';
import { Product } from '~/models/Product';

@Component({})
export default class ProductCard extends Vue {
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
    flex: 1 1 41%;
    width: 270px;
    padding: 12px;
    background: rgb(255, 255, 255);
    background: linear-gradient(
        0deg,
        var(--white) 0%,
        var(--white) 50%,
        var(--transparent) 80%
    );
    border-radius: 15px;
    box-shadow: var(--shadowcard);
    animation: fadeIn 0.3s ease-in;
    color: var(--black);
    transition: all 0.2s ease-out;
    height: max-content;
    &__card-image {
        max-height: 227px;
        padding: 12px;
        background: radial-gradient(
            ellipse at center,
            rgba(240, 105, 40, 0.2) 20%,
            rgba(255, 255, 255, 0) 70%
        );
        background-size: 300px 100%;
        background-repeat: no-repeat;
        background-position: center;
        margin-left: -12px;
        width: calc(100% + 24px);
    }
    &__card-title {
        margin-top: 10px;
        h2 {
            font-size: 16px;
            line-height: 18px;
            a {
                text-decoration: none;
            }
        }
    }
    &__product-price {
        display: flex;
        margin-top: -8px;
        align-items: center;
        h4 {
            line-height: 0px;
            font-size: 14px;
            font-weight: 400;
            color: var(--gray4);
        }
        img {
            max-height: 16px;
            margin-left: 5px;
        }
    }
    &__quote {
        background-color: var(--white);
        padding: 15px;
        border-radius: 10px;
        margin: 7px 0;
    }
    &__product-short-specs {
        color: var(--gray6);
    }
    &__card-controls {
        display: flex;
        flex-wrap: wrap;
        justify-content: flex-start;
        width: calc(100% - 42px);
    }
    &__product-points-red {
        color: var(--red);
        background: radial-gradient(
            circle,
            rgba(255, 0, 0, 0.1) 0%,
            rgba(255, 255, 255, 0) 80%
        );
    }
    &__product-points-blue {
        color: var(--blue);
        background: radial-gradient(
            circle,
            rgba(0, 0, 255, 0.08) 0%,
            rgba(255, 255, 255, 0) 80%
        );
    }
    &__points-box {
        width: 50%;
        text-align: center;
        line-height: 5px;
        padding: 25px 0;
        margin: -5px 0;
        h5 {
            margin: 20px 0 0;
            font-size: 20px;
        }
    }
    &__buttons {
        display: flex;
        flex-direction: column;
        justify-content: flex-end;
        margin: 0 0 -6px auto;
        width: 42px;
        height: 0;
        position: relative;
        bottom: -5px;
        right: -38px;
        text-align: right;
    }
    p {
        font-size: 14px;
        margin: 0.5em 0 0.5em 0;
        line-height: 1;
    }
    a {
        color: var(--link);
        text-decoration: underline;
        text-decoration-color: var(--gray3);
        width: 100%;
        transition: 0.1s ease-out;
    }
    a:hover {
        color: var(--red);
    }
}
</style>
