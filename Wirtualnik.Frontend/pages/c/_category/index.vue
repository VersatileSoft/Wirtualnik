<template>
  <div>
    <ProductsTrack>
      <template #title>
        <h2>Najpopularniejsze</h2>
      </template>
      <template #cards>
        <ProductCard v-for="item in items" :key="item.publicId">
          <template #image>
            <nuxt-link :to="`/p/` + item.publicId">
              <img :src="'https://api.zlcn.pro/' + item.image" />
            </nuxt-link>
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
  name: 'CategoryPage',
  components: {
    ProductCard,
    ProductsTrack,
    BottomNavbar,
  },
})
export default class CategoryPage extends Vue {
  private items: any[] = [];
  private category?: string;

  public async created(): Promise<void>
  {
      this.category = this.$route.params.category;
      this.$store.commit('breadcrumb/SET_BREADCRUMBS', [
        {
          name: 'Wirtualnik.pl',
          route: '/'
        },
        {
          name: this.category,
          route: '/c/' + this.category // TODO add i18n 
        }
      ])

      await this.loadData();
  }

  private async loadData(): Promise<boolean>
  {
      this.items = [];
      try
      {
        const response = await axios.get(`https://api.zlcn.pro/api/product`, {
          params: {
            typePublicId: this.category + 's'
          }
        });
        this.items = response.data.items;
      } 
      catch (ex)
      {
        this.items = [];
        return false;
      }
      return true;
  }
}
</script>
