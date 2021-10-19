<template>
    <div>
        <div v-if="mobile" class="quick-filters">
            <button class="btn-light" @click="scrollIntoView('promo')">
                Promocje 🔥
            </button>
            <button class="btn-light" @click="scrollIntoView('new')">
                Nowe produkty
            </button>
        </div>
        <div class="wrapper">
            <div class="thick-sidebar">
                <WeekBest />
            </div>
            <BlogFeed />
        </div>
        <ProductsGrid :title="'Prawdziwe promocje'">
            <VerticalCard
                v-for="item in items"
                :key="item.publicId"
                :item="item"
                @reload="loadData"
            />
        </ProductsGrid>
        <ProductsTrack :title="'Nowe produkty'">
            <ProductCard
                v-for="item in items"
                :key="item.publicId"
                :item="item"
                @reload="loadData"
            />
        </ProductsTrack>
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator';
import WeekBest from '@/components/specials/WeekBest.vue';
import BlogFeed from '@/components/cms/BlogFeed.vue';
import BreadCrumb from '@/components/navigation/Breadcrumb.vue';
import ProductsGrid from '@/components/common/ProductsGrid.vue';
import ProductsTrack from '@/components/common/ProductsTrack.vue';
import ProductCard from '@/components/common/ProductCard.vue';
import VerticalCard from '@/components/common/VerticalCard.vue';
import { Product } from '~/models/Product';
import Pager from '~/helpers/Pager';
import { FilterModel } from '~/models/FilterModel';

@Component({
    name: 'StartingPage',
    components: {
        WeekBest,
        BlogFeed,
        BreadCrumb,
        ProductsGrid,
        ProductsTrack,
        ProductCard,
        VerticalCard
    }
})
export default class StartingPage extends Vue {
    private items: Product[] = [];

    public async created(): Promise<void> {
        this.$store.commit('breadcrumb/SET_BREADCRUMBS', [
            {
                name: 'Wirtualnik.pl',
                route: '/'
            }
        ]);
        await this.loadData();
    }

    private async loadData(): Promise<void> {
        this.items = (
            await this.$productService.getProducts(
                new Pager(1, 6, 'Id', 'ASC'),
                {
                    category: 'cpu'
                } as FilterModel
            )
        ).items;
    }

    public scrollIntoView(section: string): void {
        let offsetTop: number;
        if (section === 'promo') {
            const promo = this.$refs.promo as HTMLDivElement;
            offsetTop = promo.offsetTop - 60;
        } else {
            const newSection = this.$refs.new as HTMLDivElement;
            offsetTop = newSection.offsetTop - 60;
        }
        window.scrollTo({ top: offsetTop, behavior: 'smooth' });
    }
}
</script>

<style lang="scss" scoped>
.wrapper {
    display: grid;
    grid-template-columns: 1fr;
    min-height: 100vh;
    @media screen and (min-width: 850px) {
        grid-template-columns: 1.4fr 1fr;
    }
}
.thick-sidebar {
    width: 100%;
    height: 100%;
    flex: 1 60%;
}
</style>
