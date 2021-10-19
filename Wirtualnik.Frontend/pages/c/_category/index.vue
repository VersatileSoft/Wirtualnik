<template>
    <div>
        <ProductsGrid>
            <ProductCard
                v-for="item in items"
                :key="item.publicId"
                :item="item"
                @reload="loadData"
            />
        </ProductsGrid>
        <PagerComponent :pager="pager" @reload="loadData" />
        <BottomNavbar />
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator';
import ProductCard from '@/components/common/ProductCard.vue';
import BottomNavbar from '@/components/common/BottomNavbar.vue';
import ProductsGrid from '@/components/common/ProductsGrid.vue';
import { Product } from '~/models/Product';
import Pager from '@/helpers/Pager';
import PagerComponent from '@/components/common/PagerComponent.vue';
import { FilterModel } from '~/models/FilterModel';

@Component({
    name: 'CategoryPage',
    components: {
        ProductCard,
        BottomNavbar,
        ProductsGrid,
        PagerComponent
    }
})
export default class CategoryPage extends Vue {
    private items: Product[] = [];
    private pager: Pager = new Pager(1, 16, 'Id', 'ASC');
    private filter: FilterModel = {
        name: null,
        category: null,
        manufacturer: null,
        priceFrom: null,
        priceTo: null
    };

    public async created(): Promise<void> {
        this.filter.category = this.$route.params.category;
        this.$store.commit('breadcrumb/SET_BREADCRUMBS', [
            {
                name: 'Wirtualnik.pl',
                route: '/'
            },
            {
                name: this.filter.category,
                route: '/c/' + this.filter.category // TODO add i18n
            }
        ]);
        await this.loadData();
    }

    private async loadData(): Promise<void> {
        try {
            let response = await this.$productService.getProducts(
                this.pager,
                this.filter
            );
            this.items = response.items;
            this.pager.setTotalRows(response.totalRows);
        } catch {
            console.log('error');
        }
    }
}
</script>

<style lang="scss"></style>
