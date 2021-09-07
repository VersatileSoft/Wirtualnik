<template>
    <div>
        <ImageCarouselFluid />
        <div class="container">
            <div class="thickColumn">
                <div class="productCard fullwidth">
                    <ProductInformation>
                        <template #image>
                            <img
                                :src="'https://api.zlcn.pro/' + item.images"
                                @Click="imageModal()"
                            />
                        </template>
                        <template #title>
                            <h2>{{ item.name }}</h2>
                        </template>
                        <template #description>
                            <p>
                                {{ item.description }}
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
                        <PriceListItem
                            v-for="shop in item.productShopDetails"
                            :key="shop.name"
                        >
                            <template #shop-icon>
                                <img :src="shop.image" :alt="shop.name" />
                            </template>
                            <template #shop-name>{{ shop.name }}</template>
                            <template #shop-price> {{ shop.price }} </template>
                        </PriceListItem>
                    </div>

                    <h3>Specyfikacja</h3>
                    <div class="list col-3">
                        <ProductSpecificationItem
                            v-for="prop in item.properties"
                            :key="prop.key"
                        >
                            <template #spec-key>{{ prop.key }}</template>
                            <template #spec-value>{{ prop.value }}</template>
                        </ProductSpecificationItem>
                    </div>

                    <sub
                        >EAN: {{ item.ean }} | Kod producenta: {{ item.sku }} |
                        ID Wirtualnika: 132</sub
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
                        <div class="productCard">
                            <div class="productCardImage ProductCardGlowOrange">
                                <img
                                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                                    alt="Zdjęcie produktu"
                                    loading="lazy"
                                />
                            </div>
                            <h2>AMD Ryzen 3 1200</h2>
                            <h4>
                                495.00 PLN
                                <img
                                    src="https://wirtualnik.pl/static/img/shop/morele-sygnet.png"
                                    alt="Morele.net"
                                />
                            </h4>
                            <p>4 rdzenie, 4 wątki</p>
                            <p>Socket AM4</p>
                            <p>65W</p>
                            <div class="productPoints">
                                <div class="productPointsBox productPointsRed">
                                    Gaming
                                    <h5>123</h5>
                                </div>
                                <div class="productPointsBox productPointsBlue">
                                    Pro
                                    <h5>93</h5>
                                </div>
                            </div>
                            <div class="productCardButtons">
                                <i
                                    class="
                                        las
                                        la-balance-scale
                                        btnCircle
                                        btnGreen
                                    "
                                ></i
                                ><i
                                    class="las la-cart-plus btnCircle btnGreen"
                                ></i>
                            </div>
                        </div>
                        <div class="productCard">
                            <div class="productCardImage ProductCardGlowOrange">
                                <img
                                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                                    alt="Zdjęcie produktu"
                                    loading="lazy"
                                />
                            </div>
                            <h2>AMD Ryzen 3 1200</h2>
                            <h4>
                                495.00 PLN
                                <img
                                    src="https://wirtualnik.pl/static/img/shop/morele-sygnet.png"
                                    alt="Morele.net"
                                />
                            </h4>
                            <p>4 rdzenie, 4 wątki</p>
                            <p>Socket AM4</p>
                            <p>65W</p>
                            <div class="productPoints">
                                <div class="productPointsBox productPointsRed">
                                    Gaming
                                    <h5>123</h5>
                                </div>
                                <div class="productPointsBox productPointsBlue">
                                    Pro
                                    <h5>93</h5>
                                </div>
                            </div>
                            <div class="productCardButtons">
                                <i
                                    class="
                                        las
                                        la-balance-scale
                                        btnCircle
                                        btnGreen
                                    "
                                ></i
                                ><i
                                    class="las la-cart-plus btnCircle btnGreen"
                                ></i>
                            </div>
                        </div>
                        <div class="productCard">
                            <div class="productCardImage ProductCardGlowOrange">
                                <img
                                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                                    alt="Zdjęcie produktu"
                                    loading="lazy"
                                />
                            </div>
                            <h2>AMD Ryzen 3 1200</h2>
                            <h4>
                                495.00 PLN
                                <img
                                    src="https://wirtualnik.pl/static/img/shop/morele-sygnet.png"
                                    alt="Morele.net"
                                />
                            </h4>
                            <p>4 rdzenie, 4 wątki</p>
                            <p>Socket AM4</p>
                            <p>65W</p>
                            <div class="productPoints">
                                <div class="productPointsBox productPointsRed">
                                    Gaming
                                    <h5>123</h5>
                                </div>
                                <div class="productPointsBox productPointsBlue">
                                    Pro
                                    <h5>93</h5>
                                </div>
                            </div>
                            <div class="productCardButtons">
                                <i
                                    class="
                                        las
                                        la-balance-scale
                                        btnCircle
                                        btnGreen
                                    "
                                ></i
                                ><i
                                    class="las la-cart-plus btnCircle btnGreen"
                                ></i>
                            </div>
                        </div>
                        <div class="productCard">
                            <div class="productCardImage ProductCardGlowOrange">
                                <img
                                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                                    alt="Zdjęcie produktu"
                                    loading="lazy"
                                />
                            </div>
                            <h2>AMD Ryzen 3 1200</h2>
                            <h4>
                                495.00 PLN
                                <img
                                    src="https://wirtualnik.pl/static/img/shop/morele-sygnet.png"
                                    alt="Morele.net"
                                />
                            </h4>
                            <p>4 rdzenie, 4 wątki</p>
                            <p>Socket AM4</p>
                            <p>65W</p>
                            <div class="productPoints">
                                <div class="productPointsBox productPointsRed">
                                    Gaming
                                    <h5>123</h5>
                                </div>
                                <div class="productPointsBox productPointsBlue">
                                    Pro
                                    <h5>93</h5>
                                </div>
                            </div>
                            <div class="productCardButtons">
                                <i
                                    class="
                                        las
                                        la-balance-scale
                                        btnCircle
                                        btnGreen
                                    "
                                ></i
                                ><i
                                    class="las la-cart-plus btnCircle btnGreen"
                                ></i>
                            </div>
                        </div>
                        <div class="productCard">
                            <div class="productCardImage ProductCardGlowOrange">
                                <img
                                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                                    alt="Zdjęcie produktu"
                                    loading="lazy"
                                />
                            </div>
                            <h2>AMD Ryzen 3 1200</h2>
                            <h4>
                                495.00 PLN
                                <img
                                    src="https://wirtualnik.pl/static/img/shop/morele-sygnet.png"
                                    alt="Morele.net"
                                />
                            </h4>
                            <p>4 rdzenie, 4 wątki</p>
                            <p>Socket AM4</p>
                            <p>65W</p>
                            <div class="productPoints">
                                <div class="productPointsBox productPointsRed">
                                    Gaming
                                    <h5>123</h5>
                                </div>
                                <div class="productPointsBox productPointsBlue">
                                    Pro
                                    <h5>93</h5>
                                </div>
                            </div>
                            <div class="productCardButtons">
                                <i
                                    class="
                                        las
                                        la-balance-scale
                                        btnCircle
                                        btnGreen
                                    "
                                ></i
                                ><i
                                    class="las la-cart-plus btnCircle btnGreen"
                                ></i>
                            </div>
                        </div>
                        <div class="productCard">
                            <div class="productCardImage ProductCardGlowOrange">
                                <img
                                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                                    alt="Zdjęcie produktu"
                                    loading="lazy"
                                />
                            </div>
                            <h2>AMD Ryzen 3 1200</h2>
                            <h4>
                                495.00 PLN
                                <img
                                    src="https://wirtualnik.pl/static/img/shop/morele-sygnet.png"
                                    alt="Morele.net"
                                />
                            </h4>
                            <p>4 rdzenie, 4 wątki</p>
                            <p>Socket AM4</p>
                            <p>65W</p>
                            <div class="productPoints">
                                <div class="productPointsBox productPointsRed">
                                    Gaming
                                    <h5>123</h5>
                                </div>
                                <div class="productPointsBox productPointsBlue">
                                    Pro
                                    <h5>93</h5>
                                </div>
                            </div>
                            <div class="productCardButtons">
                                <i
                                    class="
                                        las
                                        la-balance-scale
                                        btnCircle
                                        btnGreen
                                    "
                                ></i
                                ><i
                                    class="las la-cart-plus btnCircle btnGreen"
                                ></i>
                            </div>
                        </div>
                        <div class="productCard">
                            <div class="productCardImage ProductCardGlowOrange">
                                <img
                                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                                    alt="Zdjęcie produktu"
                                    loading="lazy"
                                />
                            </div>
                            <h2>AMD Ryzen 3 1200</h2>
                            <h4>
                                495.00 PLN
                                <img
                                    src="https://wirtualnik.pl/static/img/shop/morele-sygnet.png"
                                    alt="Morele.net"
                                />
                            </h4>
                            <p>4 rdzenie, 4 wątki</p>
                            <p>Socket AM4</p>
                            <p>65W</p>
                            <div class="productPoints">
                                <div class="productPointsBox productPointsRed">
                                    Gaming
                                    <h5>123</h5>
                                </div>
                                <div class="productPointsBox productPointsBlue">
                                    Pro
                                    <h5>93</h5>
                                </div>
                            </div>
                            <div class="productCardButtons">
                                <i
                                    class="
                                        las
                                        la-balance-scale
                                        btnCircle
                                        btnGreen
                                    "
                                ></i
                                ><i
                                    class="las la-cart-plus btnCircle btnGreen"
                                ></i>
                            </div>
                        </div>
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

@Component({
    name: 'ProductPage',
    components: {
        BreadCrumb,
        ImageCarouselFluid,
        ProductInformation,
        PriceListItem,
        ProductSpecificationItem
    }
})
export default class ProductPage extends Vue {
    private item: any[] = [];

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
                name: this.item.productTypeName,
                route: '/c/' + this.item.productTypeName
            },
            {
                name: this.item.name,
                route: '/p/' + this.item.publicId
            }
        ]);
    }

    private async loadData(): Promise<boolean> {
        this.item = await ProductService.getProduct(this.id);
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
</style>
