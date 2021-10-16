<template>
    <header class="page-header">
        <div class="page-header__logo">
            <button class="btn-flat" @click="toggleMegaMenu">
                <span class="las la-bars"></span>
            </button>
            <CategoryMegaMenu
                :is-mega-menu-opened="megaMenuOpened"
                @megaMenuClosed="megaMenuOpened = false"
            />
            <h1 class="page-header__brand-logo">
                <nuxt-link
                    :to="{ name: 'index' }"
                    class="page-header__brand-logo-link"
                >
                    Wirtualnik
                </nuxt-link>
            </h1>
            <div class="search-box">
                <input
                    type="text"
                    placeholder="Szukaj na Wirtualnik.pl"
                    id="search-box-hints"
                    @focus="toggleHints"
                />

                <button class="btn-flat" @click="toggleMenu">
                    <span class="las la-search"></span>
                </button>
            </div>
        </div>

        <div class="page-header__components">
            <nuxt-link
                :to="{ name: 'c-category', params: { category: 'cpu' } }"
                class="page-header__components-link"
            >
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
                    to="/cart"
                    class="page-header__components-link page-header__basket"
                >
                    <span class="las la-shopping-cart"></span>
                    <sub
                        >{{
                            this.$store.state.cart.currentCart
                                ? this.$store.state.cart.currentCart.quantity
                                : 0
                        }}
                        PLN</sub
                    >
                </nuxt-link>
            </div>
            <button class="btn-flat" @click="toggleMenu">
                <span class="las la-user"></span>
            </button>
        </div>
        <PopupMenu
            :is-menu-opened="menuOpened"
            @menuClosed="menuOpened = false"
        />
        <SearchBoxHints :is-hints-opened="hints" @hintsClosed="hints = false" />
    </header>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import PopupMenu from '@/components/common/PopupMenu.vue';
import CategoryMegaMenu from '@/components/common/CategoryMegaMenu.vue';
import SearchBoxHints from '@/components/common/SearchBoxHints.vue';

@Component({
    name: 'Header',
    components: {
        PopupMenu,
        CategoryMegaMenu,
        SearchBoxHints
    }
})
export default class Header extends Vue {
    private menuOpened = false;
    private megaMenuOpened = false;
    private hints = false;
    private cartCount = 0;

    public async created(): Promise<void> {
        try {
            await this.$cartService.getCart();
        } catch {
            console.log('Cart loading error');
        }
    }

    public toggleMenu(): void {
        this.menuOpened = !this.menuOpened;
    }

    public menuClosed(): void {
        this.menuOpened = false;
    }

    public toggleMegaMenu(): void {
        this.megaMenuOpened = !this.megaMenuOpened;
    }

    public megaMenuClosed(): void {
        this.megaMenuOpened = false;
    }

    public toggleHints(): void {
        this.hints = !this.hints;
    }

    public hintsClosed(): void {
        this.hints = false;
    }
}
</script>

<style lang="scss" scoped>
.search-box {
    border-radius: 15px;
    background-color: var(--transparent);
    box-shadow: var(--shadow10);
    transition: 0.05s ease-out;
    display: flex;
    padding-left: 15px;
    border: 1px solid var(--grey2);
    margin: 0 5px;
}

.search-box:hover {
    background-color: var(--semitransparent);
}

.search-box:focus-within {
    outline: 2px solid var(--orange);
}

.search-box input {
    font-family: 'Poppins', sans-serif;
    border: 0;
    background-color: var(--transparent);
    width: 100%;
}

.search-box input:focus {
    outline: none;
}

.search-box button {
    box-shadow: none;
    border: 0;
}

.search-box .btn-flat {
    color: var(--grey3);
}

.search-box:focus-within .btn-flat {
    color: var(--orange);
}

.page-header {
    background-color: var(--grayheader);
    padding: 0 15px;
    height: 65px;
    backdrop-filter: blur(0px);
    border-bottom: 1px solid var(--gray1);
    margin: 0 0 20px;
    position: fixed;
    width: 100%;
    top: 0;
    display: flex;
    justify-content: stretch;
    z-index: 9;
    @include for-tablet-landscape-up {
        border-radius: 0 0 20px 20px;
        position: static;
    }
    &__brand-logo {
        font-size: 22px;
        font-weight: 900;
        align-self: center;
        margin: 0 10px;
    }
    &__brand-logo-link {
        text-transform: uppercase;
        color: var(--red);
    }
    &__components {
        z-index: 9;
        display: none;
        @include for-tablet-landscape-up {
            display: flex;
            align-items: center;
            justify-content: center;
        }
    }
    &__logo {
        display: flex;
        justify-content: flex-start;
        align-items: center;
        z-index: 10;
    }
    &__logo button {
        margin-left: 0px;
    }
    &__components-link {
        margin: 3px;
        font-weight: bold;
        font-size: 24px;
        padding: 6px;
        text-align: center;
        border-radius: 10px;
        transition: all 0.1s ease-out;
        color: var(--gray2);
        &.nuxt-link-exact-active {
            color: red;
            position: relative;
            -webkit-text-stroke: 1px var(--red);
            &::after {
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
    &__components-link:hover {
        background-color: var(--white);
        color: var(--gray3);
    }
    &__components-link:active {
        filter: brightness(0.9);
    }

    &__basket {
        border-radius: 15px;
        display: flex;
        align-items: center;
        color: var(--ltblue);
        background-color: var(--transparent);
        & > sub {
            margin-left: 6px;
            font-size: 15px;
            font-weight: normal;
        }
    }
}

@media screen and (max-width: 720px) {
    .page-header {
        padding: 0px 10px;
    }
    .page-header__brand-logo {
        display: none;
    }
}
</style>
