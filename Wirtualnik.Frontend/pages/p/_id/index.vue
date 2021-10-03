<template>
    <div>
        <ImageCarouselFluid
            v-if="showModal"
            :images="product.images"
            @close="showModal = false"
        />
        <div class="container">
            <div class="thickColumn">
                <div class="productCard fullwidth">
                    <ProductInformation
                        :product="product"
                        @showModal="showModal = true"
                    />
                    <div class="pricelist fullwidth">
                        <div
                            v-if="
                                product.productShopDetails &&
                                product.productShopDetails.length > 0
                            "
                        >
                            <PriceListItem
                                v-for="shop in product.productShopDetails"
                                :key="shop.name"
                                :shop="shop"
                            />
                        </div>
                        <div v-else>Produkt niedostępny</div>
                    </div>

                    <h3>Specyfikacja</h3>
                    <div class="list col-3">
                        <li v-for="prop in product.properties" :key="prop.key">
                            {{ prop.key }}
                            <p>{{ prop.value }}</p>
                        </li>
                    </div>

                    <sub
                        >EAN: {{ product.ean }} | Kod producenta:
                        {{ product.sku }} | ID Wirtualnika: 132</sub
                    >
                </div>
            </div>
        </div>
        <div class="container">
            <div class="productContainer">
                <div class="productsGridTitle">
                    <h2><b>Podobne produkty</b></h2>
                </div>
                <div class="productsGrid" id="popular_items">
                    <div class="productsGridSlider">
                        <CommonProduct
                            v-for="commonProduct in commonProducts"
                            :key="commonProduct.publicId"
                            :product="commonProduct"
                        />
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator';
import BreadCrumb from '@/components/navigation/Breadcrumb.vue';
import ProductInformation from '@/components/common/ProductInformation.vue';
import PriceListItem from '@/components/common/PriceListItem.vue';
import CommonProduct from '@/components/common/CommonProduct.vue';
import { Product } from '~/models/Product';
import ImageCarouselFluid from '@/components/common/ImageCarouselFluid.vue';
import Pager from '~/helpers/Pager';

@Component({
    name: 'ProductPage',
    components: {
        BreadCrumb,
        ProductInformation,
        PriceListItem,
        CommonProduct,
        ImageCarouselFluid
    }
})
export default class ProductPage extends Vue {
    private product: Product = {} as Product;
    private commonProducts: Product[] = [];
    private showModal = false;

    public get id(): string {
        return this.$route.params.id;
    }

    public async created(): Promise<void> {
        await this.loadData();

        this.$store.commit('breadcrumb/SET_BREADCRUMBS', [
            {
                name: 'Wirtualnik.pl',
                route: '/'
            },
            {
                name: this.product?.productTypeName,
                route: '/c/' + this.product?.productTypeName
            },
            {
                name: this.product?.name,
                route: '/p/' + this.product?.publicId
            }
        ]);
    }

    private async loadData(): Promise<void> {
        try {
            this.product = await this.$productService.getProduct(this.id);
            this.commonProducts = (
                await this.$productService.getProductsByCategory(
                    new Pager(1, 20, 'Id', 'asc'),
                    'cpu'
                )
            ).items;
        } catch {
            // TODO show popup
        }
    }
}
</script>

<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
:root {
    --background: #f3f3f3;
}
body {
    background-color: var(--background);
    font-family: 'Poppins Devanagari', -apple-system, BlinkMacSystemFont,
        'Segoe UI', Roboto, Helvetica, Arial, sans-serif, 'Apple Color Emoji',
        'Segoe UI Emoji', 'Segoe UI Symbol';
    min-width: 320px;
    font-size: 15px;
    max-width: 1280px;
    margin: 0 auto;
}
a {
    text-decoration: none;
}
@keyframes fadeIn {
    from {
        opacity: 0;
        transform: translate3d(0, 10px, 0);
    }
    to {
        opacity: 1;
        transform: translate3d(0, 0, 0);
    }
}
.btnPrice i {
    font-size: 30px;
}
</style>
