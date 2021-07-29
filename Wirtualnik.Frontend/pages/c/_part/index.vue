<template>
  <div>
    <ProductsTrack>
      <template #title>
        <h2>Najpopularniejsze</h2>
      </template>
      <template #cards>
        <ProductCard v-for="item in items" :key="item.publicId">
          <template #image>
            <img :src="'https://api.zlcn.pro/' + item.image" />
          </template>
          <template #title>
            <h2>{{ item.name }}</h2>
          </template>
          <template #price>
            <h4>495.00 PLN</h4>
            <img src="~/assets/images/shop/morele-sygnet.png" />
          </template>
          <template #specs>
            <p v-for="prop in item.properties" :key="prop.key">{{ prop.key }}: {{ prop.value }}</p>
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
import axios from 'axios'

@Component({
  name: 'ProductPage',
  components: {
    ProductCard,
    ProductsTrack,
    BottomNavbar,
  },
})
export default class ProductPage extends Vue {
  private items: any[] = [];

  public async created(): Promise<void>
  {
      await this.loadData();
  }

  private async loadData(): Promise<boolean>
  {
      this.items = [];
      try
      {
        this.items = (await axios.get(`https://api.zlcn.pro/api/product`)).data.items;

        console.log(this.items);

      }
      catch (ex)
      {
        console.log(ex);
          this.items = [];
          return false;
      }
      return true;
  }
}
</script>
