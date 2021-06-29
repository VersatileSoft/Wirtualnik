<template>
  <header class="page-header">
    <h1 class="page-header__brand-logo">
      <nuxt-link to="/" class="page-header__brand-logo-link">
        Wirtualnik
      </nuxt-link>
    </h1>
    <div class="page-header__components">
      <nuxt-link to="/" class="page-header__components-link">
        <span class="las la-plus"></span>
      </nuxt-link>
      <nuxt-link to="#" class="page-header__components-link">
        <span class="las la-thumbs-up"></span>
      </nuxt-link>
      <nuxt-link to="#" class="page-header__components-link">
        <span class="las la-heart"></span>
      </nuxt-link>
      <nuxt-link to="#" class="page-header__components-link">
        <span class="las la-cloud"></span>
      </nuxt-link>
      <nuxt-link to="#" class="page-header__components-link">
        <span class="las la-balance-scale-left"></span>
      </nuxt-link>
    </div>
    <div class="page-header__extras">
      <div class="page-header__extras-basket">
        <nuxt-link
          to="#"
          class="page-header__components-link page-header__basket"
        >
          <span class="las la-shopping-cart"></span>
          <sub>342,23 PLN</sub>
        </nuxt-link>
      </div>
      <button class="btn-flat" @click="toggleMenu">
        <span class="las la-bars"></span>
      </button>
    </div>
    <PopupMenu :is-menu-opened="menuOpened" @menuClosed="menuOpened = false" />
  </header>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import PopupMenu from '@/components/common/PopupMenu.vue'
@Component({
  name: 'Header',
  components: {
    PopupMenu,
  },
})
export default class Header extends Vue {
  private menuOpened: boolean = false

  public toggleMenu(): void {
    this.menuOpened = !this.menuOpened
  }

  public menuClosed(): void {
    this.menuOpened = false
  }
}
</script>

<style lang="scss" scoped>
.page-header{
  background-color: var(--semitransparent);
  padding: 0 15px;
  height: 65px;
  backdrop-filter: blur(50px);
  border-bottom: 1px solid (--gray1);
  margin: 0 0 20px;
  position: fixed;
  width: 100%;
  top: 0;
  display: flex;
  justify-content: center;
  @include for-tablet-landscape-up {
    border-radius: 0 0 20px 20px;
    position: static;
  }
  &__brand-logo {
    font-size: 22px;
    font-weight: 900;
    align-self: center;
    margin-right: auto;
  }
  &__brand-logo-link {
    text-transform: uppercase;
    color: var(--red);
  }
  &__components{
    display: none;
    @include for-tablet-landscape-up {
      display: flex;
      align-items: center;
      justify-content: center;
    }
  }
  &__components-link{
    margin: 3px;
    font-weight: bold;
    font-size: 24px;
    padding: 8px;
    text-align: center;
    border-radius: 10px;
    transition: all 0.1s ease-out;
    color: var(--gray2);
  }
  &__basket{
    display: flex;
    flex-direction: column;
    justify-content: center;
    color: var(--ltblue);
    & > sub {
      font-size: 12.5px;
      font-weight: normal;
    }
  }
  .nuxt-link-active {
    color: red;
    position: relative;
    -webkit-text-stroke: 1px var(--red);
    &::after{
      display: block;
      position: absolute;
      content: '';
      width: 85%;
      height: 3px;
      border-radius: 5px 5px 0 0;
      bottom: -8px;
      background-color: var(--red);
      left: 8%;
    }
}
}
</style>