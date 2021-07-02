<template>
  <ul class="bread-track">
    <li
      v-for="(crud, idx) in breadCrumbs"
      :key="idx"
      :class="{ indicator: !isLast(idx) }"
    >
      <nuxt-link :to="{ name: crud.route }" class="crumb">
        {{ crud.name }}
      </nuxt-link>
    </li>
  </ul>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator'

interface CrumbDetail {
  name: string
  route: string
}

@Component({
  name: 'BreadCrumb',
})
export default class Breadcrumb extends Vue {
  private breadCrumbs: CrumbDetail[] = [
    { name: 'Wirtualnik.pl', route: 'index' },
  ]

  public isLast(crumbIdx: number): boolean {
    return this.breadCrumbs.length - 1 === crumbIdx
  }
}
</script>

<style lang="scss" scoped>
.bread-track {
  display: flex;
  margin: 15px 0 15px 10px;
}
.crumb {
  color: var(--gray4);
  &:hover {
    text-decoration: underline;
  }
}
.indicator {
  ::after {
    color: var(--gray4);
    content: '>';
    margin: 0 5px;
    display: inline-block;
  }
}
</style>
