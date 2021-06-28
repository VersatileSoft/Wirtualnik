<template>
  <div class="app container">
    <Header />
    <div class="page-content">
      <nuxt />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import Header from '@/components/common/Header.vue'

@Component({
  name: 'DefaultLayout',
  components: {
    Header,
  },
})
export default class DefaultLayout extends Vue {}
</script>

<style lang="scss" scoped>
  .page-content {
    padding-top: 65px;
    @include for-tablet-landscape-up {
      padding-top: 0;
    }
  }
</style>
