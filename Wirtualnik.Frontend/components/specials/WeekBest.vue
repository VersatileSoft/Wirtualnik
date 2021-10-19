<template>
    <div class="product-card week-best">
        <div class="week-best__image glow-cyan">
            <img src="~/assets/images/cpu/ryzen_3_3100-box.png" />
        </div>
        <div class="product-card__card-title">
            <h2>Stworzony przez Kacpra Trynieckiego 🎉🥳</h2>
        </div>
        <div class="product-card__product-price">
            <h4>495.00 PLN</h4>
            <img src="~/assets/images/shop/morele-sygnet.png" />
        </div>
        <div class="product-card__quote">
            <p class="quote">
                Wirtualnik Kacpra został wyróżniony z uwagi na świetny dobór
                komponentów. Ten komputer zapewni jednocześnie świetną wydajność
                dziś jak i ogromne możliwości rozbudowy w przeszłości.
            </p>
        </div>
        <div class="week-best__part-list">
            <div v-for="item in items" :key="item.publicId">
                <img :src="item.image" />
                <nuxt-link
                    :to="{
                        name: 'c-category',
                        params: { category: 'cpu' }
                    }"
                >
                    {{ item.name }}
                </nuxt-link>
                <p>
                    <!-- Price TODO w API-->
                    {{ item.price }}PLN
                    <img src="~/assets/images/shop/xkom-sygnet.png" />
                </p>
            </div>
        </div>
        <div class="product-card__card-controls">
            <div
                class="
                    product-card__product-points-red product-card__points-box
                "
            >
                FPS CS:GO
                <h5>123</h5>
            </div>
            <div
                class="
                    product-card__product-points-blue product-card__points-box
                "
            >
                FPS GTA:V
                <h5>93</h5>
            </div>
            <div class="product-card__buttons">
                <button class="btn-circle btn-green">
                    <span class="las la-angle-double-right"></span>
                </button>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator';
import { Product } from '~/models/Product';
import Pager from '~/helpers/Pager';
import { FilterModel } from '~/models/FilterModel';

@Component({})
export default class StartingPage extends Vue {
    private items: Product[] = [];

    // TODO load week best fom api
    public async created(): Promise<void> {
        await this.loadData();
    }

    private async loadData(): Promise<void> {
        this.items = (
            await this.$productService.getProducts(
                new Pager(1, 5, 'Id', 'ASC'),
                {
                    category: 'cpu'
                } as FilterModel
            )
        ).items;
    }
}
</script>

<style lang="scss">
.product-card.week-best {
    width: 99%;
    margin-bottom: 60px;
}

.week-best {
    margin: 3px;
    &::before {
        content: '👑 WIRTUALNIK TYGODNIA';
        color: var(--white);
        background: linear-gradient(
            90deg,
            rgba(231, 71, 71, 1) 0%,
            rgba(230, 51, 120, 1) 100%
        );
        padding: 6px 12px;
        margin: -12px 0 0 -12px;
        border-radius: 15px 0 5px 0;
        width: fit-content;
        display: block;
        font-weight: 400;
    }
    &__image {
        margin-left: -12px;
        width: 100%;
        max-height: 227px;
        padding: 12px;
    }
    &__part-list {
        border-radius: 0;
        display: flex;
        flex-direction: column;
        margin-left: -12px;
        margin-right: -12px;
    }
    &__part-list > div {
        padding: 12px 10px;
        margin: 0;
        display: flex;
        align-items: center;
        &:nth-child(even) {
            background-color: var(--gray1);
        }
    }
    &__part-list div > p {
        display: flex;
        align-items: center;
        min-width: 120px;
        justify-content: flex-end;
        flex-grow: 1;
    }
    &__part-list img {
        width: 20px;
        max-height: 30px;
        margin-left: 10px;
        margin-right: 10px;
    }
}
.glow-cyan {
    background: radial-gradient(
        ellipse at center,
        rgba(40, 176, 240, 0.15) 20%,
        rgba(255, 255, 255, 0) 70%
    );
}
</style>
