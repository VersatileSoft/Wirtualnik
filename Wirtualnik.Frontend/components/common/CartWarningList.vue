<template>
    <div class="warninglist">
        <li
            v-for="warning in warnings"
            :key="warning.title"
            :class="warning.type"
        >
            <span class="icon-motherboard"></span>
            <h4>{{ warning.title }}</h4>
            <p>
                {{ warning.message }}
            </p>
        </li>
    </div>
</template>
<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator';
import { WarningModel } from '~/services/CartService';

@Component({})
export default class CartWarningList extends Vue {
    private warnings: WarningModel[] = [];

    public async created(): Promise<void> {
        await this.loadData();
    }

    private async loadData(): Promise<void> {
        // Test cart warnings, move to cart page after created
        try {
            this.warnings = await this.$cartService.getWarnings();
            console.log();
        } catch (e) {
            console.log(e);
        }
    }
}
</script>

<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
</style>
