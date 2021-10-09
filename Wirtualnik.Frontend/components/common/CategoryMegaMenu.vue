<template>
    <div
        class="userMenu bigMenu"
        id="big-menu"
        :class="{ 'mega-menu-opened': isMegaMenuOpened }"
    >
        <section>
            <div class="headerExtra">
                <button class="btnFlat" @click="closeMegaMenu">
                    <i class="las la-times"></i>
                </button>
            </div>

            <div class="searchContainer">
                <input placeholder="Szukaj..." spellcheck="false" type="text" />
            </div>
        </section>

        <div class="dividerGrey" style="margin-top: 10px"></div>

        <div class="sidebarElement">
            <button>
                <span class="icon-cpu"></span>
                <p>Procesory</p>
            </button>
            <button>
                <span class="icon-motherboard"></span>
                <p>Płyty główne</p>
            </button>
            <button>
                <span class="icon-ram"></span>
                <p>Pamięć RAM</p>
            </button>
            <button>
                <span class="icon-gpu"></span>
                <p>Karty graficzne</p>
            </button>
            <button>
                <span class="icon-ssd"></span>
                <p>Dyski</p>
            </button>
            <button>
                <span class="icon-psu"></span>
                <p>Zasilacze</p>
            </button>
            <button>
                <span class="icon-case"></span>
                <p>Obudowy</p>
            </button>
        </div>

        <div class="dividerGrey" style="margin-top: 10px"></div>

        <div class="sidebarElement">
            <button>
                <span class="icon-laptop"></span>
                <p>Laptopy<br /></p>
            </button>
            <button>
                <span class="icon-cooler"></span>
                <p>Chłodzenia procesora</p>
            </button>
            <button>
                <span class="icon-mouse"></span>
                <p>Myszki<br /></p>
            </button>
            <button>
                <span class="icon-keyboard"></span>
                <p>Klawiatury</p>
            </button>
            <button>
                <span class="icon-headphones"></span>
                <p>Słuchawki</p>
            </button>
            <button>
                <span class="icon-monitor"></span>
                <p>Monitory</p>
            </button>
        </div>

        <div class="dividerGrey" style="margin-top: 10px"></div>

        <div class="shopPreference">
            <div>
                <h3>Preferowany sklep</h3>
                <h4>Aktualnie wybrany: <b>Morele.net</b></h4>
            </div>
            <div class="shopList">
                <button class="btnFlat preferedShopGlow">
                    <img
                        src="static/img/shop/morele-sygnet.png"
                        alt="Morele.net"
                    />
                </button>
                <button class="btnFlat">
                    <img src="static/img/shop/xkom-sygnet.png" alt="X-kom" />
                </button>
                <button class="btnFlat">
                    <img
                        src="static/img/shop/euro-sygnet.png"
                        alt="RTV Euro AGD"
                    />
                </button>
                <button class="btnFlat">
                    <img
                        src="static/img/shop/mediaexpert-sygnet.png"
                        alt="OleOle"
                    />
                </button>
                <button class="btnFlat">
                    <img
                        src="static/img/shop/proline-sygnet.png"
                        alt="MediaExpert"
                    />
                </button>
                <button class="btnFlat">
                    <img
                        src="static/img/shop/oleole-sygnet.png"
                        alt="ProLine"
                    />
                </button>
            </div>
        </div>

        <div class="mobileMenu">
            <div class="headerComponents">
                <a href="najlepsze.htm"
                    ><button><i class="las la-thumbs-up"></i></button
                ></a>
                <a href="ulubione.htm"
                    ><button><i class="las la-heart"></i></button
                ></a>
                <a href="twoje-wirtualniki.htm"
                    ><button><i class="las la-cloud"></i></button
                ></a>
                <a href="porownanie.htm"
                    ><button><i class="las la-balance-scale-left"></i></button
                ></a>
            </div>
        </div>
    </div>
</template>
<script lang="ts">
import { Component, Vue, Prop, Emit } from 'nuxt-property-decorator';

@Component({
    name: 'CategoryMegaMenu'
})
export default class CategoryMegaMenu extends Vue {
    @Prop({
        default: false
    })
    private isMegaMenuOpened = false;

    @Emit('megaMenuClosed')
    public closeMegaMenu(event: Event): Event {
        return event;
    }
}
</script>
<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
.mega-menu-opened {
    display: block;
    z-index: 2;
}
</style>
