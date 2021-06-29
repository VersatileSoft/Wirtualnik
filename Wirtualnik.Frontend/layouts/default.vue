<template>
  <div class="app container">
    <Header />
    <div class="page-content">
      <BreadCrumb />
      <nuxt />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import Header from '@/components/common/Header.vue'
import BreadCrumb from '@/components/navigation/Breadcrumb.vue'

@Component({
  name: 'DefaultLayout',
  components: {
    Header,
    BreadCrumb,
  },
})
export default class DefaultLayout extends Vue {}
</script>

<style lang="scss" scoped>
.page-content {
  padding: 65px 10px 0 10px;
  overflow: hidden;
  @include for-tablet-landscape-up {
    padding-top: 0;
  }
}
</style>
