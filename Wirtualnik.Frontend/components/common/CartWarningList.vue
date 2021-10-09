<template>
    <div class="warninglist">
        <li class="error">
            <span class="icon-motherboard"></span>
            <h4>Brak kompatybilności</h4>
            <p>
                Wybrany procesor AMD Ryzen 3 3100 posiada złącze Socket AM4, a
                płyta główna znajdująca się w tym Wirtualniku obsługuje Socket
                LGA1200.
            </p>
        </li>
        <li class="warning">
            <span class="icon-case"></span>
            <h4>Obudowa może być zbyt mała</h4>
            <p>
                W obudowie SilentiumPC Signum SG1 TG jest miejsce na karte
                graficzną o długości maksymalnie 300mm, a wybrana Gigabyte RTX
                3070 Gaming X ma 298mm.
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
</template>
<script lang="ts">
export default {};
</script>
<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
</style>
