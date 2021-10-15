<template>
    <div
        class="userCard"
        style="justify-content: space-between; align-items: center"
    >
        <button class="btnOrange btnCircle btnBasic">
            Sprawdź kompatybilność podzespołów
        </button>
        <button class="btnGreen btnCircle btnBasic">
            <i class="las la-save"></i>Zapisz jako publiczny
        </button>

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
    </div>
</template>
<script>
export default {};
</script>
<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
</style>
