<template>
    <div>
        <div class="head">
            <div class="carousel"></div>

            <div class="details">
                <h2>{{ this.item.data.name }}</h2>
                <p>{{ this.item.data.description }}</p>
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
            <ul
                v-for="property in this.item.data.properties"
                :key="property.publicId"
            >
                <p>{{ property.key }}</p>
                <p>{{ property.value }}</p>
            </ul>
        </div>
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator';
import axios from 'axios';

@Component({
    name: 'ProductPage'
})
export default class ProductPage extends Vue {
    public get id() {
        return this.$route.params.id;
    }

    public async created(): Promise<void> {
        try {
            this.item = await axios.get(
                'https://api.zlcn.pro/api/product/' + this.id
            );
            console.log(this.item);
        } catch (ex) {
            console.log(ex);
            console.log(this.id);
            this.item = undefined;
        }
    }
}
</script>

<style lang="scss"></style>
