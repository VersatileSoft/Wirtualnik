<template>
    <client-only>
        <swiper class="swiper" :options="swiperOption">
            <swiper-slide v-for="image in images" v-bind:key="image"
                ><div class="product-image-carousel-item">
                    <img :src="image" /></div
            ></swiper-slide>
            <div class="swiper-pagination" slot="pagination"></div>
            <div class="swiper-button-prev" slot="button-prev"></div>
            <div class="swiper-button-next" slot="button-next"></div>
        </swiper>
    </client-only>
</template>
<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator';
import { Swiper, SwiperSlide } from 'vue-awesome-swiper';
import $ from 'jquery';

@Component({
    components: { Swiper, SwiperSlide },
    props: {
        images: []
    }
})
export default class ImageCarouselFluid extends Vue {
    private swiperOption = {
        pagination: { el: '.swiper-pagination' },
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev'
        }
    };
}
</script>

<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
.product-image-carousel-item {
    height: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
}
</style>
