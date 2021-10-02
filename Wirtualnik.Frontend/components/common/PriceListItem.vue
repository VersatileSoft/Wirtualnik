<template>
    <button class="btnPrice">
        <slot name="shop-icon"></slot>
        <h4><slot name="shop-name"></slot></h4>
        <slot name="shop-price"></slot>
    </button>
</template>
<style lang="scss" scoped>
@import url('@//assets/shadient/shadient_mobile.css');
</style>
<script>
import { Component, Vue } from 'nuxt-property-decorator';

export default class PriceListItem extends Vue {}
</script>
