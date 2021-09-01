<template>
    <div>
        <div class="head">
            <ImageCarousel />
            <div class="details">
                <h2>{{ item.name }}</h2>
                <p>{{ item.description }}</p>
                <button>Dodaj to koszyka</button>
            </div>

            <div class="stats">
                <div class="red">
                    <h2>Gaming</h2>
                    <h3>123</h3>
                </div>

                <div class="blue">
                    <h2>Pro</h2>
                    <h3>123</h3>
                </div>

                <div class="black">
                    <h2>Biuro</h2>
                    <h3>123</h3>
                </div>
            </div>
        </div>

        <div class="prize">
            <ul></ul>
        </div>

        <div class="spec">
            <h2>Specyfikacja</h2>
            <ul v-for="property in item.properties" :key="item.publicId">
                <p>{{ property.key }}</p>
                <p>{{ property.value }}</p>
            </ul>
        </div>
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator';
import axios from 'axios';
import BreadCrumb from '@/components/navigation/Breadcrumb.vue';
import ImageCarousel from '@/components/common/ImageCarousel.vue';

@Component({
    name: 'ProductPage',
    components: {
        BreadCrumb,
        ImageCarousel
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
        try {
            const response = await axios.get(
                'https://api.zlcn.pro/api/product/' + this.id
            );
            console.log(response);
            this.item = response.data;
        } catch (ex) {
            this.item = undefined;
        }
    }
}
</script>

<style lang="scss" scoped>
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
