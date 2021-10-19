<template>
    <div class="search-box-position hints-opened">
        <div class="search-box-divider"></div>
        <div class="search-box-container">
            <div
                v-for="product in products"
                :key="product.publicId"
                class="search-box-product"
            >
                <img :src="product.image" />
                <h4>{{ product.name }}</h4>
                <button class="btn-light">💰<br />519.32PLN</button>
            </div>
        </div>
    </div>
</template>
<script lang="ts">
import Debounce from '@/helpers/Debounce';
import { Component, Prop, Vue, Watch } from 'nuxt-property-decorator';
import Pager from '~/helpers/Pager';
import { FilterModel } from '~/models/FilterModel';
import { Product } from '~/models/Product';

@Component({
    name: 'SearchBoxHints'
})
export default class SearchBoxHints extends Vue {
    @Prop({ default: '' })
    private searchText: string;
    private products: Product[] = [];

    @Watch('searchText')
    @Debounce(100)
    private async onSearchTextChanged(value: string): Promise<void> {
        this.search(value);
    }

    @Debounce(100)
    private async search(value: string): Promise<void> {
        if (!value) {
            this.products = [];
            return;
        }

        this.products = (
            await this.$productService.getProducts(
                new Pager(1, 12, 'Id', 'ASC'),
                {
                    name: value
                } as FilterModel
            )
        ).items;
    }
}
</script>
<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');

.search-box-position {
    display: none; /* ZMIENIC NA NONE!!! */
    position: absolute;
    height: 0px;
    top: 46px;
    z-index: 2;
    width: 100%;
    margin-left: -15px;
}
.hints-opened {
    z-index: 2;
    display: block;
}

.search-box-divider {
    width: 100%;
    height: 15px;
    z-index: -1;
    background-color: var(--grayheader);
}

.search-box-container {
    display: flex;
    background-color: var(--grayheader);
    box-shadow: var(--shadow20);
    flex-wrap: wrap;
    z-index: 2;
    max-width: 1440px;
    padding: 0px 0px 5px 0px;
    border-radius: 0px 0px 10px 10px;
    overflow-y: auto;
    max-height: 500px;
}

.search-box-product {
    flex-direction: row;
    display: flex;
    flex-grow: 1;
    padding: 15px;
    margin: 10px 10px;
    width: 100%;
    height: 100%;
    border-radius: 10px;
    background-color: var(--grey1);
    box-shadow: var(--shadow20);
    border: 1px solid var(--grey2);
    align-items: center;
    color: var(--black);
    & h4 {
        justify-content: flex-start;
        margin: 0;
        margin-right: auto;
        flex-wrap: wrap;
    }
    & button {
        margin-left: 5px;
        height: 100%;
        flex-shrink: 0;
    }
    & img {
        width: 50px;
        max-height: 50px;
        margin-right: 10px;
    }
}
@media screen and (max-width: 720px) {
    .search-box-position {
        margin-left: -10px;
    }
}
</style>
