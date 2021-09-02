<template>
    <div class="container">
        <div class="productCardImage">
            <slot name="image"></slot>
        </div>

        <div class="productDescription">
            <slot name="title"></slot>
            <slot name="description"></slot>
            <slot name="buttons">
                <button class="btnGreen btnCircle btnBasic">
                    <i class="las la-cart-plus"></i>Dodaj do koszyka
                </button>
            </slot>
        </div>
        <div class="productPoints">
            <div class="columnContainer">
                <div class="productPointsBox productPointsRed">
                    Gaming
                    <slot name="red-points"></slot>
                </div>
                <div class="productPointsBox productPointsBlue">
                    Pro
                    <slot name="blue-points"></slot>
                </div>
                <div class="productPointsBox productPointsGrey">
                    Biuro
                    <slot name="gray-points"></slot>
                </div>
            </div>
        </div>
    </div>
</template>
<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
</style>
