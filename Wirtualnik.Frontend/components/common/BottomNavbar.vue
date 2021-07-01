<template>
  <nav class="bottom-nav">
    <div class="bottom-nav__wrapper">
      <nuxt-link
        v-for="(link, index) in linksArray"
        :key="index"
        :to="{ name: 'c-part', params: { part: link.part } }"
        class="bottom-nav__components-link"
      >
        <i :class="link.iconName"></i>
        <span>{{ link.description }}</span>
      </nuxt-link>
    </div>
  </nav>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator'
import { NavLinkOptionsModel } from '@/interfaces/GlobalInterfaces'
@Component({
  name: 'BottomNavbar',
})
export default class BottomNavbar extends Vue {
  private linksArray: NavLinkOptionsModel[] = [
    { iconName: 'icon-cpu', description: 'Procesor', part: 'cpu' },
    {
      iconName: 'icon-motherboard',
      description: 'Płyta główna',
      part: 'motherboard',
    },
    { iconName: 'icon-ram', description: 'Pamięć RAM', part: 'ram' },
    { iconName: 'icon-gpu', description: 'Karta graficzna', part: 'gpu' },
    { iconName: 'icon-ssd', description: 'SSD', part: 'ssd' },
    { iconName: 'icon-hdd', description: 'HDD', part: 'hdd' },
    { iconName: 'icon-psu', description: 'Zasilacz', part: 'psu' },
    { iconName: 'icon-case', description: 'Obudowa', part: 'case' },
    { iconName: 'icon-cooler', description: 'Cooler', part: 'cooler' },
  ]
}
</script>

<style lang="scss" scoped>
.bottom-nav {
  display: flex;
  align-items: center;
  justify-content: center;
  position: fixed;
  overflow-x: auto;
  bottom: 0;
  width: 100%;
  left: 0;
  background-color: var(--white);
  z-index: 2;
  box-shadow: var(--shadowcardreverse);
  border-top: 1px solid var(--gray1);
  &__wrapper {
    display: flex;
    min-width: 1px;
  }
  &__components-link {
    margin: 3px;
    font-weight: bold;
    font-size: 24px;
    padding: 8px;
    text-align: center;
    border-radius: 10px;
    transition: all 0.1s ease-out;
    display: flex;
    flex-direction: column;
    color: var(--gray3);
    &.nuxt-link-exact-active {
      color: #ff2b4d !important;
      background: linear-gradient(
        0deg,
        rgba(255, 0, 0, 1) 3%,
        rgba(255, 255, 255, 0) 3%
      );
    }
    span {
      font-size: 15px;
      font-weight: normal;
      white-space: nowrap;
    }
  }
}
</style>
