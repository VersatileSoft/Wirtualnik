<template>
  <div class="products-grid">
    <div class="products-grid__title">
      <slot name="title"></slot>
    </div>
    <div class="products-grid__cards">
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
.products-grid {
  display: grid;
  &__title {
    h2 {
      background-image: linear-gradient(69deg, var(--red), var(--orange));
      font-weight: 600;
      -webkit-background-clip: text;
      -webkit-text-fill-color: transparent;
    }
  }
  &__cards {
    display: flex;
    flex-wrap: wrap;
    gap: 1rem;
    min-width: 50%;
    align-self: flex-start;
    justify-content: center;
    margin-bottom: 40px;
  }
}
</style>
