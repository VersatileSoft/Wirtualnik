<template>
  <div>
    <ProductsTrack>
      <template #title>
        <h2>Najpopularniejsze</h2>
      </template>
      <template #cards>
        <ProductCard>
          <template #image>
            <img src="~/assets/images/cpu/ryzen_3_3100-box.png" />
          </template>
          <template #title>
            <h2>AMD Ryzen 3 1200</h2>
          </template>
          <template #price>
            <h4>495.00 PLN</h4>
            <img src="~/assets/images/shop/morele-sygnet.png" />
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
        <ProductCard>
          <template #image>
            <img src="~/assets/images/cpu/ryzen_3_3100-box.png" />
          </template>
          <template #title>
            <h2>AMD Ryzen 3 1200</h2>
          </template>
          <template #price>
            <h4>495.00 PLN</h4>
            <img src="~/assets/images/shop/morele-sygnet.png" />
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
        <ProductCard>
          <template #image>
            <img src="~/assets/images/cpu/ryzen_3_3100-box.png" />
          </template>
          <template #title>
            <h2>AMD Ryzen 3 1200</h2>
          </template>
          <template #price>
            <h4>495.00 PLN</h4>
            <img src="~/assets/images/shop/morele-sygnet.png" />
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
      </template>
    </ProductsTrack>
    <BottomNavbar />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator'
import ProductCard from '@/components/common/ProductCard.vue'
import ProductsTrack from '@/components/common/ProductsTrack.vue'
import BottomNavbar from '@/components/common/BottomNavbar.vue'
@Component({
  name: 'ProductPage',
  components: {
    ProductCard,
    ProductsTrack,
    BottomNavbar,
  },
})
export default class ProductPage extends Vue {}
</script>
