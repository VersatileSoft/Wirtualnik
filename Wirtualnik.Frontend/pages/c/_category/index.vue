<template>
    <div style="display: flex; flex-direction: column; align-items: center">
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
                    <h2>
                        <nuxt-link :to="`/p/` + item.publicId">
                            {{ item.name }}
                        </nuxt-link>
                    </h2>
                    <h6 v-if="item.isInCart">W koszyku</h6>
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
            <div class="pagination-nav">
                <sliding-pagination
                    :current="pager.getPageIndex()"
                    :total="pager.totalPages"
                    @page-change="pageChangeHandler"
                ></sliding-pagination>
            </div>
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
    private pager: Pager = new Pager(1, 16, 'Id', 'ASC');

    public async created(): Promise<void> {
        await this.$cartService.getCart();

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

<style lang="scss">
.pagination-nav {
    width: 100%;
    height: 200px;
    nav {
        height: 100px;
        display: flex;
        justify-content: center;
        align-items: center;
    }
}
.c-sliding-pagination__list-element {
    border: var(--gray3) solid 1px;
    background: #fff;
    color: var(--gray3);
    padding: 0;
}
.c-sliding-pagination__list-element a {
    display: block;
    padding: 0.6em;
}
.c-sliding-pagination__list-element:hover {
    background: var(--gray3);
    color: #fff;
}
.c-sliding-pagination__list-element--active {
    background: var(--gray3);
    color: #fff;
}
.c-sliding-pagination__page {
    display: block;
}
</style>
