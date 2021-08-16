<template>
    <div class="product-card product-card__vertical">
        <div class="vertical__img prodict-card__img product-card__card-image">
            <slot name="image"></slot>
        </div>
        <div class="product-card__card-title">
            <slot name="title"></slot>
        </div>
        <div class="vertical__product-promo">
            <sub>
                <slot name="promo"></slot>
            </sub>
        </div>
        <div class="product-card__product-price">
            <h4 class="vertical__price">
                <slot name="price"></slot>
            </h4>
        </div>
        <div class="product-card__product-short-specs vertical__specs">
            <p><slot name="first"></slot></p>
            <p><slot name="second"></slot></p>
            <p><slot name="third"></slot></p>
        </div>
        <div class="vertical__price-list">
            <slot name="shop-price"></slot>
        </div>
        <div class="product-card__card-controls">
            <div class="product-card__buttons">
                <slot name="buttons"></slot>
            </div>
        </div>
    </div>
</template>

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
