<template>
    <div
        class="search-box-hints"
        :class="{ 'hints-opened': isHintsOpened }"
    ></div>
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
.search-box-hints {
    display: none;
    background: #fff;
    position: absolute;
    min-height: 100px;
    height: auto;
    width: 325px;
    top: 50px;
    margin-left: -15px;
}
.hints-opened {
    z-index: 2;
    display: block;
}
</style>
