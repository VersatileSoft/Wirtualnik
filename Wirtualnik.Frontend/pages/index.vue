<template>
  <div>
    <ProductCard>
      <template #image>
        <img src="~/assets/images/ryzen_3_3100-box.png" />
      </template>
      <template #title>
        <h2>AMD Ryzen 3 1200</h2>
      </template>
      <template #price>
        <h4>495.00 PLN</h4>
        <img src="~/assets/images/morele-sygnet.png" />
      </template>
      <template #specs>
        <p>4 rdzenie, 4 wątki</p>
        <p>Socket AM4</p>
        <p>65W</p>
      </template>
      <template #red-points>
        Gaming
        <h5>123</h5>
      </template>
      <template #blue-points>
        Pro
        <h5>93</h5>
      </template>
      <template #buttons>
        <button class="btn-circle btn-green">
          <span class="las la-balance-scale"></span>
        </button>
        <button class="btn-circle btn-green">
          <span class="las la-cart-plus"></span>
        </button>
      </template>
    </ProductCard>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator'
import ProductCard from '@/components/common/ProductCard.vue'
@Component({
  name: 'StartingPage',
  components: {
    ProductCard,
  },
})
export default class StartingPage extends Vue {}
</script>
