<template>
    <button class="btnPrice">
        <img :src="shop.image" :alt="shop.name" />
        <h4>{{ shop.name }}</h4>
        {{ shop.price }}
    </button>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'nuxt-property-decorator';
import { ProductShopDetails } from '../../models/ProductShopDetails';

@Component({})
export default class CommonProduct extends Vue {
    @Prop({ default: null })
    private shop: ProductShopDetails;
}
</script>

<style lang="scss" scoped>
@import url('@//assets/shadient/shadient_mobile.css');
</style>
<script>
import { Component, Vue } from 'nuxt-property-decorator'

export default class PriceListItem extends Vue {}
</script>
