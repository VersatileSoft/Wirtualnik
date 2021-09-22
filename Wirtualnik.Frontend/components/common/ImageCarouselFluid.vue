<template>
    <client-only>
        <swiper
            :slides-per-view="2"
            :space-between="30"
            @swiper="onSwiper"
            @slideChange="onSlideChange"
        >
            <swiper-slide
                ><img
                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
            /></swiper-slide>
            <swiper-slide
                ><img
                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
            /></swiper-slide>
            <swiper-slide
                ><img
                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
            /></swiper-slide>
        </swiper>
    </client-only>
</template>
<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator';

@Component({
    components: {}
})
export default class ImageCarouselFluid extends Vue {
    public async created(): Promise<void> {
        console.log('Jest');
    }

    private onSwiper(): void {
        console.log('onSwiper');
    }

    private onSlideChange(): void {
        console.log('onSlideChange');
    }
}
</script>

<style lang="scss" scoped></style>
