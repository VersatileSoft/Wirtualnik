<template>
    <a :href="shop.refLink" target="_blank" class="btnPrice">
        <img v-if="shop.image" :src="shop.image" :alt="shop.name" />
        <h4>{{ shop.name }}</h4>
        {{ shop.price }}
    </a>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'nuxt-property-decorator';
import { ProductShopDetails } from '../../models/ProductShopDetails';

@Component({})
export default class PriceListItem extends Vue {
    @Prop({ default: null })
    private shop: ProductShopDetails;
}
</script>

<style lang="scss" scoped>
@import url('@//assets/shadient/shadient_mobile.css');
</style>
