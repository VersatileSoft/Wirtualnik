<template>
    <div id="imageModal" v-on:click="$parent.showModal = false">
        <div class="imageModalContainer" v-on:click.stop>
            <swiper class="swiper" :options="swiperOption" ref="swiper">
                <swiper-slide v-for="image in images" :key="image">
                    <div class="product-image-carousel-item">
                        <img :src="image" />
                    </div>
                </swiper-slide>
                <div class="swiper-pagination" slot="pagination"></div>
                <div class="swiper-button-prev" slot="button-prev"></div>
                <div class="swiper-button-next" slot="button-next"></div>
            </swiper>

            <button class="btnGreen btnCircle btnBasic" @click="downloadImg()">
                <i class="las la-download"></i>Pobierz zdjęcie
            </button>
        </div>
    </div>
</template>
<script lang="ts">
import { Component, Prop, Vue } from 'nuxt-property-decorator';
import { Swiper, SwiperSlide } from 'vue-awesome-swiper';
import SwiperClass from 'node_modules/@types/swiper/index';
import download from 'downloadjs';

@Component({
    components: { Swiper, SwiperSlide }
})
export default class ImageCarouselFluid extends Vue {
    @Prop({ default: [] })
    public images: string[];

    public get swiper(): SwiperClass {
        return this.$refs.swiper?.$swiper;
    }

    private swiperOption = {
        pagination: { el: '.swiper-pagination' },
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev'
        }
    };

    private async downloadImg(): Promise<void> {
        download(this.images[this.swiper.activeIndex]);
    }
}
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
.btnRed {
    display: flex;
    justify-content: space-between;
    align-items: center;
    height: 30px;
    padding: 0;
}
.btnRed i {
    margin: 0;
}
</style>
