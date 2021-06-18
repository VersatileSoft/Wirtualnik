<template>
  <div>
    <header>Header</header>
    <nuxt />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({
  name: 'DefaultLayout',
})
export default class DefaultLayout extends Vue {
  public mounted(): void {
    console.log(this.mobile)
  }
}
</script>
