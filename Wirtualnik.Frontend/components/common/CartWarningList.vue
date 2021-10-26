<template>
    <div>
        <div
            class="userCard"
            style="justify-content: space-between; align-items: center"
        >
            <button
                class="btnOrange btnCircle btnBasic"
                v-on:click="getCartWarnings()"
            >
                Sprawdź kompatybilność podzespołów
            </button>
            <button class="btnGreen btnCircle btnBasic">
                <i class="las la-save"></i>Zapisz jako publiczny
            </button>

            <!--
        <div style="flex-basis: 100%; margin-top: 40px">
            -- 1 User kliknął w buttona kompatybilności, pokazuje się loader --
        </div>

        <div class="dot-container">
            <div class="dot-floating"></div>
        </div>

        <div style="flex-basis: 100%; margin-top: 40px">
            -- 1A Serwer nie zwrócił błędu --
        </div>

        <h5>Nie wykryto błędów! 😊<br />Szacowany pobór mocy: 288W</h5>

        <button class="btnGreen btnCircle btnBasic">
            <i class="las la-save"></i>Zapisz jako publiczny
        </button>

        <div style="flex-basis: 100%; margin-top: 40px">
            -- 1B Serwer zwrócił błąd, kliknięcie w butoona przenosi niżej do
            diva z błędami --
        </div>

        <button class="btnRed btnCircle btnBasic">
            <i class="las la-bug"></i>Wykryto problemy!
        </button>
        <button class="btnGreen btnCircle btnBasic">
            <i class="las la-save"></i>Zapisz jako publiczny
        </button>

        <div style="flex-basis: 100%; margin-top: 40px">
            -- 2 User kliknął w buttona zapisania, pokazuje się loader --
        </div>

        <div class="dot-container">
            <div class="dot-floating"></div>
        </div>

        <div style="flex-basis: 100%; margin-top: 40px">
            -- 2A Serwer zwraca linka --
        </div>
        <button class="btnOrange btnCircle btnBasic">
            Sprawdź kompatybilność podzespołów
        </button>
        <button class="btnGreen btnCircle btnBasic">
            <i class="las la-link"></i>Przejdź do publicznej listy
        </button>
        --></div>
        <div class="warninglist">
            <li class="error">
                <span class="icon-motherboard"></span>
                <h4>Brak kompatybilności</h4>
                <p>
                    Wybrany procesor AMD Ryzen 3 3100 posiada złącze Socket AM4,
                    a płyta główna znajdująca się w tym Wirtualniku obsługuje
                    Socket LGA1200.
                </p>
            </li>
            <li class="warning">
                <span class="icon-case"></span>
                <h4>Obudowa może być zbyt mała</h4>
                <p>
                    W obudowie SilentiumPC Signum SG1 TG jest miejsce na karte
                    graficzną o długości maksymalnie 300mm, a wybrana Gigabyte
                    RTX 3070 Gaming X ma 298mm.
                </p>
            </li>
            <li class="warning">
                <span class="icon-gpu"></span>
                <h4>--</h4>
                <p>--</p>
            </li>
            <li class="warning">
                <span class="icon-psu"></span>
                <h4>--</h4>
                <p>--</p>
            </li>
        </div>
    </div>
</template>
<script lang="ts">
import { Component, Vue, Prop } from 'nuxt-property-decorator';
import { Product } from '~/models/Product';

export default class CartWarningList extends Vue {
    public warnings: [] = [];

    public async created(): Promise<void> {
        await this.loadData();
        console.log(this.warnings);
    }

    private async loadData(): Promise<void> {
        //After debug
        //this.warnings = await this.$cartService.getWarnings();
    }
}
</script>
<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
</style>
