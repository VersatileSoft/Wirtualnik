<template>
    <div class="container">
        <div class="productCardImage" @click="imageModal">
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
<script>
import { Component, Vue } from 'nuxt-property-decorator';

export default class ProductInformation extends Vue {}
</script>
<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
@media screen and (max-width: 720px) {
    @import url('@//assets/shadient/shadient_mobile.css');
}
</style>
<script>
import { Component, Vue } from 'nuxt-property-decorator'

@Component({
  methods: {
    imageModal() {
      this.$parent.imageModal()
    }
  }
})
export default class ProductInformation extends Vue {}
</script>
