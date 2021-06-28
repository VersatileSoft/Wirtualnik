<template>
  <div class="app">
    <Header />
    <nuxt />
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
