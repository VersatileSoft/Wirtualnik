<template>
    <div>
        <!-- ImageCarouselFluid will be remade after swiper dependency bugfix -->
        <ImageCarouselFluid />
        <div class="container">
            <div class="thickColumn">
                <div class="productCard fullwidth">
                    <ProductInformation>
                        <template #image>
                            <img
                                :src="'https://api.zlcn.pro/' + product.images"
                                v-on:click="imageModal"
                            />
                        </template>
                        <template #title>
                            <h2>{{ product.name }}</h2>
                        </template>
                        <template #description>
                            <p>
                                {{ product.description }}
                            </p>
                        </template>
                        <template #buttons>
                            <button class="btnGreen btnCircle btnBasic">
                                <i class="las la-cart-plus"></i>Dodaj do koszyka
                            </button>
                        </template>
                        <template #red-points>
                            <h5>123</h5>
                        </template>
                        <template #blue-points>
                            <h5>93</h5>
                        </template>
                        <template #gray-points>
                            <h5>93</h5>
                        </template>
                    </ProductInformation>

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
                            >
                                <template #shop-icon>
                                    <img :src="shop.image" :alt="shop.name" />
                                </template>
                                <template #shop-name>{{ shop.name }}</template>
                                <template #shop-price>
                                    {{ shop.price }}
                                </template>
                            </PriceListItem>
                        </div>
                        <div v-else>
                            <PriceListItem>
                                <template #shop-icon>
                                    <i class="las la-sad-cry"></i>
                                </template>
                                <template #shop-name
                                    >Produkt niedostępny</template
                                >
                            </PriceListItem>
                        </div>
                    </div>

                    <h3>Specyfikacja</h3>
                    <div class="list col-3">
                        <ProductSpecificationItem
                            v-for="prop in product.properties"
                            :key="prop.key"
                        >
                            <template #spec-key>{{ prop.key }}</template>
                            <template #spec-value>{{ prop.value }}</template>
                        </ProductSpecificationItem>
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
                        >
                            <template #common-product-image>
                                <nuxt-link :to="`/p/` + commonProduct.publicId">
                                    <img
                                        :src="
                                            'https://api.zlcn.pro/' +
                                            commonProduct.image
                                        "
                                        alt="Zdjęcie produktu"
                                        loading="lazy"
                                    />
                                </nuxt-link>
                            </template>
                            <template #common-product-name>
                                {{ commonProduct.name }}
                            </template>
                            <template #common-product-price
                                >495.00 PLN
                                <!-- {{ commonProduct.price }} --></template
                            >
                            <template #common-product-price-provider>
                                <img
                                    :src="
                                        commonProduct.productShopDetails.image
                                    "
                                    alt="Morele.net"
                            /></template>
                            <template #common-product-first-prop
                                >{{ commonProduct.properties[0].key }}
                                {{
                                    commonProduct.properties[0].value
                                }}</template
                            >
                            <template #common-product-second-prop
                                >{{ commonProduct.properties[1].key }}
                                {{
                                    commonProduct.properties[1].value
                                }}</template
                            >
                            <template #common-product-third-prop
                                >{{ commonProduct.properties[2].key }}
                                {{
                                    commonProduct.properties[2].value
                                }}</template
                            >
                            <template #common-product-red-points>123</template>
                            <template #common-product-gray-points>93</template>
                        </CommonProduct>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator';
import ProductService from '@/services/ProductService.ts';
import BreadCrumb from '@/components/navigation/Breadcrumb.vue';
import ImageCarouselFluid from '@/components/common/ImageCarouselFluid.vue';
import ProductInformation from '@/components/common/ProductInformation.vue';
import PriceListItem from '@/components/common/PriceListItem.vue';
import ProductSpecificationItem from '@/components/common/ProductSpecificationItem.vue';
import CommonProduct from '@/components/common/CommonProduct.vue';

@Component({
    name: 'ProductPage',
    components: {
        BreadCrumb,
        ImageCarouselFluid,
        ProductInformation,
        PriceListItem,
        ProductSpecificationItem,
        CommonProduct
    },
    methods: {
        imageModal: function () {
            document.getElementById('imageModal');
            var x = document.getElementById('imageModal');
            if (x.style.display === 'block') {
                x.style.display = 'none';
            } else {
                x.style.display = 'block';
            }
        }
    }
})
export default class ProductPage extends Vue {
    private product: any[] = [];
    private commonProducts: any[] = [];

    public get id() {
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
                name: this.product.productTypeName,
                route: '/c/' + this.product.productTypeName
            },
            {
                name: this.product.name,
                route: '/p/' + this.product.publicId
            }
        ]);
    }

    private async loadData(): Promise<boolean> {
        this.product = await ProductService.getProduct(this.id);
        this.commonProducts = await ProductService.getProductsByCategory(
            this.typePublicId
        );
        console.log(this.product);
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
