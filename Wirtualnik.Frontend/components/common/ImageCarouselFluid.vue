<template>
    <client-only>
        <swiper class="swiper" :options="swiperOption">
            <swiper-slide
                ><div class="product-image-carousel-item">
                    <img
                        src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                    /></div
            ></swiper-slide>
            <swiper-slide
                ><div class="product-image-carousel-item">
                    <img
                        src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                    /></div
            ></swiper-slide>
            <swiper-slide
                ><div class="product-image-carousel-item">
                    <img
                        src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                    /></div
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

import 'swiper/css/swiper.css';

export default {
    components: {
        Swiper,
        SwiperSlide
    },
    data() {
        return {
            swiperOption: {
                pagination: {
                    el: '.swiper-pagination'
                },
                navigation: {
                    nextEl: '.swiper-button-next',
                    prevEl: '.swiper-button-prev'
                }
            }
        };
    }
};
</script>

<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
.product-image-carousel-item {
    height: 100%;
    display: flex;
    justify-content: space-between;
    align-items: center;
}
.product-image-carousel-item img {
    height: 80%;
    margin-left: auto;
    margin-right: auto;
}
</style>
