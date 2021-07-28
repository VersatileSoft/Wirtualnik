<template>
  <div class="products-track">
    <div class="products-track__title">
      <slot name="title"></slot>
    </div>
    <div class="products-track__cards">
      <slot name="cards"></slot>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator'
@Component({
  name: 'ProductsHorizontalTrack',
})
export default class ProductsHorizontalTrack extends Vue {}
</script>

<style lang="scss">
.products-track {
  display: flex;
  flex-wrap: wrap;
  &__title {
    h2 {
      background-image: linear-gradient(69deg, var(--red), var(--orange));
      font-weight: 600;
      -webkit-background-clip: text;
      -webkit-text-fill-color: transparent;
    }
  }
  &__cards {
    margin-bottom: 40px;
    display: flex;
    gap: 1rem;
    padding-bottom: 10px;
    height: 100%;
    width: 100%;
    overflow-x: auto;
    overflow-y: hidden;
    flex-wrap: nowrap;
  }
}
</style>
