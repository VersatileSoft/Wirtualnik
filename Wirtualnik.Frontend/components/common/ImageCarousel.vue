<template>
    <div id="imageModal">
        <div class="imageModalContainer">
            <div
                class="
                    swiper-container
                    swiper-initialized
                    swiper-horizontal
                    swiper-pointer-events
                    swiper-free-mode
                "
            >
                <div
                    class="swiper-wrapper"
                    style="transition-duration: 0ms"
                    id="swiper-wrapper-8311a551d65f919c"
                    aria-live="polite"
                >
                    <div
                        class="swiper-slide product_card_glow_orange"
                        style="
                            background-image: url(./static/img/cpu/ryzen_3_3100-box.png);
                        "
                    ></div>
                    <div
                        class="swiper-slide product_card_glow_orange"
                        style="
                            background-image: url(./static/img/cpu/ryzen_3_3100-box.png);
                        "
                    ></div>
                    <div
                        class="swiper-slide product_card_glow_orange"
                        style="
                            background-image: url(./static/img/cpu/ryzen_3_3100-box.png);
                        "
                    ></div>
                </div>
                <div
                    class="swiper-button-prev swiper-button-black"
                    tabindex="0"
                    role="button"
                    aria-label="undefined"
                    aria-controls="Previous slide"
                    aria-disabled="false"
                ></div>
                <div
                    class="swiper-button-next swiper-button-black"
                    tabindex="0"
                    role="button"
                    aria-label="undefined"
                    aria-controls="Next slide"
                    aria-disabled="false"
                ></div>
                <span
                    class="swiper-notification"
                    aria-live="assertive"
                    aria-atomic="true"
                ></span>
            </div>
            <button
                class="btn-green btn-circle btn-addtocart"
                onclick="imageModal()"
            >
                <i class="las la-download"></i>Pobierz zdjęcie
            </button>
        </div>
    </div>
</template>
<style scoped>
@import url('@/assets/swiper-bundle/swiper-bundle.css');
.imageModalContainer .swiper-container {
    width: inherit;
}
.btn-green:hover {
    color: green;
    border: 1px solid rgba(24, 222, 87, 0.4);
}

.btn-green:active {
    box-shadow: 0px 0px 0px 2px rgba(24, 222, 87, 0.4),
        0px 0px 0px 6px rgba(24, 222, 87, 0.3);
}
.btn-addtocart i {
    margin-right: 6px;
    font-size: 20px;
}
.btn-circle {
    border-radius: 100%;
    background-color: var(--white);
    color: var(--black);
    padding: 8px;
    font-size: 20px;
    text-align: center;
    transition: 0.15s ease-out;
    border: 1px solid var(--grey2);
    margin-top: 5px;
    margin-bottom: 5px;
}

.btn-addtocart {
    font: 400 15px Poppins Devanagari !important;
    width: auto;
    border-radius: 10px;
    margin-top: 10px;
    margin-bottom: 10px;
    display: flex;
    align-items: center;
}
.swiper-slide {
    background-position: center center;
    background-repeat: no-repeat;
    background-size: contain, 10%;
}

.swiper-button-prev,
.swiper-button-next {
    color: var(--grey4) !important;
}

.swiper-button-next:after,
.swiper-button-prev:after {
    font-size: 28px !important;
}

#imageModal {
    display: none;
    position: fixed;
    top: 0;
    left: 0;
    height: 100vh;
    z-index: 2;
    width: 100%;
    background-color: var(--semitransparent2);
    overflow-y: hidden;
    backdrop-filter: blur(10px);
    -webkit-backdrop-filter: blur(10px);
}

.imageModalContainer {
    display: flex;
    flex: 1 1 500px;
    min-width: 100px;
    width: 95%;
    height: 60%;
    max-height: 1000px;
    max-width: 1000px;
    padding: 20px;
    justify-content: center;
    position: absolute;
    left: 50%;
    top: 50%;
    transform: translate(-50%, -50%);
}

.imageModalContainer .swiper-container {
    width: inherit;
}

.imageModalContainer .btn-green {
    position: absolute;
    bottom: -20%;
}
</style>
