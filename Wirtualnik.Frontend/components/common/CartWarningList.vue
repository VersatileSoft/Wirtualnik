<template>
    <div class="warninglist">
        <button
            v-if="!loaded"
            class="btnOrange btnCircle btnBasic"
            @click="loadData"
        >
            Sprawdź kompatybilność podzespołów
        </button>
        <div v-if="loading" class="dot-container">
            <div class="dot-floating"></div>
        </div>
        <div v-if="loaded">
            <div v-if="hasWarnings">
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
            <h5 v-else>
                Nie wykryto błędów! 😊<br />Szacowany pobór mocy: 288W
            </h5>
        </div>
    </div>
</template>
<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator';
import { WarningModel } from '~/services/CartService';

@Component({})
export default class CartWarningList extends Vue {
    private warnings: WarningModel[] = [];
    private loaded = false;
    private loading = false;

    private get hasWarnings(): boolean {
        return this.warnings.length > 0;
    }

    public async created(): Promise<void> {
        // await this.loadData();
    }

    private async loadData(): Promise<void> {
        this.loading = true;
        try {
            this.warnings = await this.$cartService.getWarnings();
        } catch (e) {
            console.log(e);
        }
        this.loading = false;
        this.loaded = true;
    }
}
</script>

<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
</style>
