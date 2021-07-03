<template>
  <div>
    <div v-if="mobile" class="quick-filters">
      <button class="btn-light" @click="scrollIntoView('promo')">
        Promocje 🔥
      </button>
      <button class="btn-light" @click="scrollIntoView('new')">
        Nowe produkty
      </button>
    </div>
    <div class="wrapper">
      <div class="thick-sidebar">
        <WeekBest>
          <template #image>
            <img src="~/assets/images/cpu/ryzen_3_3100-box.png" />
          </template>
          <template #creator>
            <h2>Stworzony przez Kacpra Trynieckiego 🎉🥳</h2>
          </template>
          <template #price>
            <h4>495.00 PLN</h4>
            <img src="~/assets/images/shop/morele-sygnet.png" />
          </template>
          <template #quote>
            <p class="quote">
              Wirtualnik Kacpra został wyróżniony z uwagi na świetny dobór
              komponentów. Ten komputer zapewni jednocześnie świetną wydajność
              dziś jak i ogromne możliwości rozbudowy w przeszłości.
            </p>
          </template>
          <template #parts>
            <div v-for="index in 10" :key="index">
              <img src="~/assets/images/cpu/ryzen_3_3100-box.png" />
              <nuxt-link :to="{ name: 'c-part', params: { part: 'cpu' } }">
                AMD Ryzen 3 3100
              </nuxt-link>
              <p>
                2342.97 PLN
                <img src="~/assets/images/shop/xkom-sygnet.png" />
              </p>
            </div>
          </template>
          <template #red-points>
            FPS CS:GO
            <h5>123</h5>
          </template>
          <template #blue-points>
            FPS GTA:V
            <h5>93</h5>
          </template>
          <template #buttons>
            <button class="btn-circle btn-green">
              <span class="las la-angle-double-right"></span>
            </button>
          </template>
        </WeekBest>
      </div>
      <BlogFeed />
    </div>
    <div ref="promo">
      <ProductsGrid>
        <template #title>
          <h2>Prawdziwe promocje</h2>
        </template>
        <template #cards>
          <VerticalCard>
            <template #image>
              <img src="~/assets/images/cpu/ryzen_3_3100-box.png" />
            </template>
            <template #title>
              <h2>AMD Ryzen 3 1200</h2>
            </template>
            <template #promo> 549.00 PLN </template>
            <template #price>
              495.00 PLN <img src="~/assets/images/shop/xkom-sygnet.png" />
            </template>
            <template #first> 4 rdzenie, 4 wątki </template>
            <template #second> Socket AM4 </template>
            <template #third> 65W </template>
            <template #shop-price>
              <button class="btn-miniprice">
                <a href="#">
                  <img src="~/assets/images/shop/xkom-sygnet.png" />
                  542.00
                </a>
              </button>
              <button class="btn-miniprice">
                <a href="#">
                  <img src="~/assets/images/shop/morele-sygnet.png" />
                  542.00
                </a>
              </button>
            </template>
            <template #buttons>
              <button class="btn-circle btn-green">
                <span class="las la-balance-scale"></span>
              </button>
              <button class="btn-circle btn-green">
                <span class="las la-cart-plus"></span>
              </button>
            </template>
          </VerticalCard>
          <VerticalCard>
            <template #image>
              <img src="~/assets/images/cpu/ryzen_3_3100-box.png" />
            </template>
            <template #title>
              <h2>AMD Ryzen 3 1200</h2>
            </template>
            <template #promo> 549.00 PLN </template>
            <template #price>
              495.00 PLN <img src="~/assets/images/shop/xkom-sygnet.png" />
            </template>
            <template #first> 4 rdzenie, 4 wątki </template>
            <template #second> Socket AM4 </template>
            <template #third> 65W </template>
            <template #shop-price>
              <button class="btn-miniprice">
                <a href="#">
                  <img src="~/assets/images/shop/xkom-sygnet.png" />
                  542.00
                </a>
              </button>
              <button class="btn-miniprice">
                <a href="#">
                  <img src="~/assets/images/shop/morele-sygnet.png" />
                  542.00
                </a>
              </button>
              <button class="btn-miniprice">
                <a href="#">
                  <img src="~/assets/images/shop/morele-sygnet.png" />
                  542.00
                </a>
              </button>
              <button class="btn-miniprice">
                <a href="#">
                  <img src="~/assets/images/shop/morele-sygnet.png" />
                  542.00
                </a>
              </button>
            </template>
            <template #buttons>
              <button class="btn-circle btn-green">
                <span class="las la-balance-scale"></span>
              </button>
              <button class="btn-circle btn-green">
                <span class="las la-cart-plus"></span>
              </button>
            </template>
          </VerticalCard>
        </template>
      </ProductsGrid>
    </div>
    <div ref="new">
      <ProductsTrack>
        <template #title>
          <h2>Nowe produkty</h2>
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
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator'
import WeekBest from '@/components/specials/WeekBest.vue'
import BlogFeed from '@/components/cms/BlogFeed.vue'
import BreadCrumb from '@/components/navigation/Breadcrumb.vue'
import ProductsGrid from '@/components/common/ProductsGrid.vue'
import ProductsTrack from '@/components/common/ProductsTrack.vue'
import ProductCard from '@/components/common/ProductCard.vue'
import VerticalCard from '@/components/common/VerticalCard.vue'
@Component({
  name: 'StartingPage',
  components: {
    WeekBest,
    BlogFeed,
    BreadCrumb,
    ProductsGrid,
    ProductsTrack,
    ProductCard,
    VerticalCard,
  },
})
export default class StartingPage extends Vue {
  public scrollIntoView(section: string): void {
    let offsetTop = 0
    if (section === 'promo') {
      const promo = this.$refs.promo as HTMLDivElement
      offsetTop = promo.offsetTop - 60
    } else {
      const newSection = this.$refs.new as HTMLDivElement
      offsetTop = newSection.offsetTop - 60
    }
    window.scrollTo({ top: offsetTop, behavior: 'smooth' })
  }
}
</script>

<style lang="scss" scoped>
.wrapper {
  display: grid;
  grid-template-columns: 1fr;
  min-height: 100vh;
  @media screen and (min-width: 850px) {
    grid-template-columns: 1.4fr 1fr;
  }
}
.thick-sidebar {
  width: 100%;
  height: 100%;
  flex: 1 60%;
}
.quick-filters {
  color: var(--gray4);
  text-align: center;
  background-color: var(--ltgray);
  border-radius: 15px;
  padding: 10px 0;
}
</style>
