<template>
    <div style="display: flex; flex-direction: column; align-items: center">
        <sliding-pagination
            :current="pager.getPageIndex()"
            :total="pager.totalPages"
            @page-change="pageChangeHandler"
        ></sliding-pagination>
        <div
            style="
                display: flex;
                flex-wrap: wrap;
                flex-direction: row;
                gap: 1rem;
            "
        >
            <ProductCard v-for="item in items" :key="item.publicId">
                <template #image>
                    <nuxt-link :to="`/p/` + item.publicId">
                        <img :src="item.image" />
                    </nuxt-link>
                </template>
                <template #title>
                    <h2>{{ item.name }}</h2>
                </template>
                <template #price>
                    <h4>495.00 PLN</h4>
                    <img src="~/assets/images/shop/morele-sygnet.png" />
                </template>
                <template #specs>
                    <p v-for="prop in item.properties" :key="prop.key">
                        {{ prop.key }}: {{ prop.value }}
                    </p>
                </template>
                <template #red-points>
                    Gaming
                    <h5>123</h5>
                </template>
                <template #blue-points>
                    Pro
                    <h5>93</h5>
                </template>
                <template #buttons>
                    <button class="btn-circle btn-green">
                        <span class="las la-balance-scale"></span>
                    </button>
                    <button class="btn-circle btn-green">
                        <span class="las la-cart-plus"></span>
                    </button>
                </template>
            </ProductCard>
            <BottomNavbar />
        </div>
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator';
import ProductCard from '@/components/common/ProductCard.vue';
import ProductsTrack from '@/components/common/ProductsTrack.vue';
import BottomNavbar from '@/components/common/BottomNavbar.vue';
import { Product } from '~/models/Product';
import Pager from '@/helpers/Pager';

@Component({
    name: 'CategoryPage',
    components: {
        ProductCard,
        ProductsTrack,
        BottomNavbar
    }
})
export default class CategoryPage extends Vue {
    private items: Product[] = [];
    private category!: string;
    private currentPage = 1;
    private totalPages = 10;
    private pager: Pager = new Pager(1, 20, 'Id', 'ASC');

    public async created(): Promise<void> {
        this.category = this.$route.params.category;
        this.$store.commit('breadcrumb/SET_BREADCRUMBS', [
            {
                name: 'Wirtualnik.pl',
                route: '/'
            },
            {
                name: this.category,
                route: '/c/' + this.category // TODO add i18n
            }
        ]);

        await this.loadData();
    }

    private async loadData(): Promise<void> {
        try {
            let response = await this.$productService.getProductsByCategory(
                this.pager,
                this.category
            );
            this.items = response.items;
            this.pager.setTotalRows(response.totalRows);
        } catch {
            console.log('error');
        }
    }

    private async pageChangeHandler(selectedPage: number): Promise<void> {
        this.pager.setPageIndex(selectedPage);
        await this.loadData();
    }
}
</script>
