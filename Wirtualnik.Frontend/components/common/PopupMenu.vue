<template>
  <div class="user-menu" :class="{ 'menu-opened': isMenuOpened }">
    <section class="user-menu__header">
      <h3>Hej Maksymilian!</h3>
      <div class="page-header__extras">
        <div class="btn-flat">
          <img src="~/assets/images/user.jpg" />
        </div>
        <button class="btn-flat" @click="themeChange">
          <span class="las la-moon"></span>
        </button>
        <button class="btn-flat" @click="closeMenu">
          <span class="las la-times"></span>
        </button>
      </div>
    </section>
    <section class="user-menu__items">
      <nuxt-link class="user-menu__items-link" to="/">
        <span
          class="las la-bell icon"
          :class="{ 'bell-ring': isMenuOpened }"
        ></span>
        <p class="user-menu__items-text">Powiadomienia (4)</p>
      </nuxt-link>
      <nuxt-link class="user-menu__items-link" to="#">
        <span class="las la-cloud icon"></span>
        <p class="user-menu__items-text">Twoje Wirtualniki (333)</p>
      </nuxt-link>
      <nuxt-link class="user-menu__items-link" to="#">
        <span class="las la-cog icon"></span>
        <p class="user-menu__items-text">Ustawienia</p>
      </nuxt-link>
      <nuxt-link class="user-menu__items-link" to="#">
        <span class="las la-bug icon"></span>
        <p class="user-menu__items-text">Zgłoś błąd / sugestie</p>
      </nuxt-link>
      <nuxt-link class="user-menu__items-link" to="#">
        <span class="las la-sign-out-alt icon"></span>
        <p class="user-menu__items-text">Wyloguj sie</p>
      </nuxt-link>
    </section>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop, Emit } from 'nuxt-property-decorator'
import { ThemeMutations } from '@/enums/storeEnums'
@Component({
  name: 'PopupMenu',
})
export default class PopupMenu extends Vue {
  @Prop({
    default: false,
  })
  private isMenuOpened: boolean = false

  private get theme(): string {
    return this.$store.state.theme.theme
  }

  public head() {
    return {
      bodyAttrs: {
        'data-theme': this.theme,
      },
    }
  }

  @Emit('menuClosed')
  public closeMenu(event: Event): Event {
    return event
  }

  public themeChange(): void {
    this.theme === 'light'
      ? this.$store.commit(`theme/${ThemeMutations.CHANGE_THEME}`, 'dark')
      : this.$store.commit(`theme/${ThemeMutations.CHANGE_THEME}`, 'light')
  }
}
</script>

<style lang="scss" scoped>
.user-menu {
  display: none;
  position: absolute;
  top: 0;
  z-index: 10;
  border-radius: 0 0 15px 15px;
  padding: 0 10px 5px;
  background-color: var(--ltgray);
  box-shadow: var(--shadowcard), var(--shadowcard);
  color: var(--black);
  min-width: 98vw;
  margin: 0 auto;
  @include for-tablet-landscape-up {
    min-width: 300px;
    max-width: 300px;
    right: 0;
  }
  &__header {
    display: flex;
    margin: 0 8px;
  }
  &__items {
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: 8px;
    @include for-tablet-landscape-up {
      grid-template-columns: 1fr;
    }
  }
  &__items-text {
    margin: 0;
    line-height: 100%;
  }
  &__items-link {
    display: flex;
    align-items: center;
    flex: 1 1 50%;
    width: 100%;
    padding: 10px;
    margin-right: 4px;
    background-color: var(--white);
    color: var(--black);
    border-radius: 10px;
    cursor: pointer;
    transition: 0.15s ease-out;
  }
}

.nuxt-link-exact-active {
  background: var(--orange);
  box-shadow: var(--gloworange);
  color: var(--white);
}
.menu-opened {
  display: block;
  z-index: 2;
}
.icon {
  font-size: 32px;
  margin-right: 8px;
}
.bell-ring {
  transform-origin: 50% 4px;
  -moz-transform-origin: 50% 4px;
  -webkit-transform-origin: 50% 4px;
  animation: ring 4s 0.7s ease-in-out 1;
}

@keyframes ring {
  0% {
    transform: rotate(0);
  }
  1% {
    transform: rotate(30deg);
  }
  3% {
    transform: rotate(-28deg);
  }
  5% {
    transform: rotate(34deg);
  }
  7% {
    transform: rotate(-32deg);
  }
  9% {
    transform: rotate(30deg);
  }
  11% {
    transform: rotate(-28deg);
  }
  13% {
    transform: rotate(26deg);
  }
  15% {
    transform: rotate(-24deg);
  }
  17% {
    transform: rotate(22deg);
  }
  19% {
    transform: rotate(-20deg);
  }
  21% {
    transform: rotate(18deg);
  }
  23% {
    transform: rotate(-16deg);
  }
  25% {
    transform: rotate(14deg);
  }
  27% {
    transform: rotate(-12deg);
  }
  29% {
    transform: rotate(10deg);
  }
  31% {
    transform: rotate(-8deg);
  }
  33% {
    transform: rotate(6deg);
  }
  35% {
    transform: rotate(-4deg);
  }
  37% {
    transform: rotate(2deg);
  }
  39% {
    transform: rotate(-1deg);
  }
  41% {
    transform: rotate(1deg);
  }

  43% {
    transform: rotate(0);
  }
  100% {
    transform: rotate(0);
  }
}
</style>
