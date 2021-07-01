<template>
  <div class="wrapper">
    <div class="thick-sidebar">
      <WeekBest>
        <template #image>
          <img src="~/assets/images/ryzen_3_3100-box.png" />
        </template>
        <template #creator>
          <h2>Stworzony przez Kacpra Trynieckiego 🎉🥳</h2>
        </template>
        <template #price>
          <h4>495.00 PLN</h4>
          <img src="~/assets/images/morele-sygnet.png" />
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
            <img src="~/assets/images/ryzen_3_3100-box.png" />
            <nuxt-link :to="{ name: 'c-part', params: { part: 'cpu' } }">
              AMD Ryzen 3 3100
            </nuxt-link>
            <p>
              2342.97 PLN
              <img src="~/assets/images/xkom-sygnet.png" />
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
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator'
import WeekBest from '@/components/specials/WeekBest.vue'
@Component({
  name: 'StartingPage',
  components: {
    WeekBest,
  },
})
export default class StartingPage extends Vue {}
</script>

<style lang="scss" scoped>
.wrapper {
  display: grid;
  grid-template-columns: 1fr;
  min-height: 100vh;
  @media screen and (min-width: 850px) {
    grid-template-columns: minmax(200px, 600px) 1fr;
  }
}
.thick-sidebar {
  width: 100%;
  height: 100%;
  flex: 1 60%;
}
</style>
