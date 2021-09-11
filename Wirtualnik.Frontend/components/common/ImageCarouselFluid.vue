<template>
    <div id="imageModal">
        <div class="imageModalContainer">
            <swiper
                :pagination="{
                    type: 'progressbar'
                }"
                :navigation="true"
                class="mySwiper"
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
        </div>
    </div>
</template>
<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
@import url('https://unpkg.com/swiper/swiper-bundle.min.css');
</style>
<script>
/* Swiper compotent - To Fix in future
// Import Swiper Vue.js components
import { Swiper, SwiperSlide } from 'swiper/vue';

// import Swiper core and required modules
import SwiperCore, { Pagination, Navigation } from 'swiper';

// install Swiper modules
SwiperCore.use([Pagination, Navigation]);

export default {
    components: {
        Swiper,
        SwiperSlide
    },
    data() {
        return {};
    },
    methods: {}
};

*/
</script>
