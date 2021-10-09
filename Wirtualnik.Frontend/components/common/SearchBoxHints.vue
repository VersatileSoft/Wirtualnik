<template>
    <div class="search-box-position" :class="{ 'hints-opened': isHintsOpened }">
        <div class="search-box-container">
            <div class="search-box-product">
                <img src="https://api.zlcn.pro/static/img/2bc16383-3475-4ea9-ae6f-6eb5f7b24d44.png"></img>
                <h4>AMD Ryzen 3 3100</h4>
                <button class="btn-light">Od 519.32PLN</button>
            </div>
            <div class="search-box-product">
                <img src="https://api.zlcn.pro/static/img/2bc16383-3475-4ea9-ae6f-6eb5f7b24d44.png"></img>
                <h4>AMD Ryzen 3 3100</h4>
                <button class="btn-light">Od 519.32PLN</button>
            </div>
            <div class="search-box-product">
                <img src="https://api.zlcn.pro/static/img/2bc16383-3475-4ea9-ae6f-6eb5f7b24d44.png"></img>
                <h4>Gigabyte GeForce RTX 2060 Gaming OC</h4>
                <button class="btn-light">Od 519.32PLN</button>
            </div>
        </div>
        
    </div>
</template>
<script lang="ts">
import { Component, Vue, Prop, Emit } from 'nuxt-property-decorator';

@Component({
    name: 'SearchBoxHints'
})
export default class SearchBoxHints extends Vue {
    @Prop({
        default: false
    })
    private isHintsOpened = false;

    @Emit('hintsClosed')
    public closeHints(event: Event): Event {
        return event;
    }
}
</script>
<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
.search-box-position {
    display: none; /* ZMIENIC NA NONE!!! */
    position: absolute;
    height: 0px;
    top: 64px;
    margin-left: -15px;
}
.hints-opened {
    z-index: 2;
    display: block;
}
.search-box-container {
    display: flex;
    background-color: var(--grey1);
    box-shadow: var(--shadow20);
    flex-wrap: wrap;
}

.search-box-product {
    flex-direction: row;
    display: flex;
    flex-grow: 1;
    padding: 20px 20px;
    margin: 10px 10px;
    width: 100%;
    height: 100%;
    border-radius: 10px;
    background-color: var(--grey1);
    box-shadow: var(--shadow20);
    border: 1px solid var(--grey2);
    align-items: center;
    & h4 {
        justify-content: flex-start;
        margin-right: auto;
        flex-wrap: wrap;

    }
    & button {
        margin-left: 5px;
        height: 100%;
    }
    & img {
        width: 20px;
        max-height: 30px;
        margin-right: 10px;
    }
}

</style>
