<template>

</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator'
@Component({
  name: 'ProductsHorizontalTrack',
})
export default class ProductPage extends Vue {

    public get id() {
        return this.$route.params.id;
    }
}
</script>

<style lang="scss">

</style>
