<template>
    <div class="productCard">
        <div class="productCardImage ProductCardGlowOrange">
            <slot name="common-product-image"></slot>
        </div>
        <h2><slot name="common-product-name"></slot></h2>
        <h4>
            <slot name="common-product-price"></slot>
            <slot name="common-product-price-provider"></slot>
        </h4>
        <p><slot name="common-product-first-prop"></slot></p>
        <p><slot name="common-product-second-prop"></slot></p>
        <p><slot name="common-product-third-prop"></slot></p>
        <div class="productPoints">
            <div class="productPointsBox productPointsRed">
                Gaming
                <h5>
                    <slot name="common-product-red-points"></slot>
                </h5>
            </div>
            <div class="productPointsBox productPointsBlue">
                Pro
                <h5>
                    <slot name="common-product-gray-points"></slot>
                </h5>
            </div>
        </div>
        <div class="productCardButtons">
            <i class="las la-balance-scale btnCircle btnGreen"></i
            ><i class="las la-cart-plus btnCircle btnGreen"></i>
        </div>
    </div>
</template>
<script></script>
<style scoped>
@import url('@//assets/shadient/shadient.css');
@media screen and (max-width: 720px) {
    @import url('@//assets/shadient/shadient_mobile.css');
}
</style>
