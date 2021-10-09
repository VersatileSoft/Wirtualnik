<template>
    <div class="cart">
        <div class="left">
            <div class="productCardImage productCardGlowCyan">
                <img
                    src="static/img/cpu/ryzen_3_3100-box.png"
                    alt="Zdjęcie produktu"
                    loading="lazy"
                />
            </div>
            <div class="userCard">
                <a href="#"
                    ><button class="btnFlat">
                        <img src="static/img/user.jpg" alt="Avatar" /></button
                ></a>
                <p>
                    Autor<br />
                    <a href="#"><b>Piotr Plenzler</b></a>
                    <sub
                        >Dodano: 24.07.2021 10:42<br />
                        Aktualizacja: 24.07.2021 11:01</sub
                    >
                </p>
            </div>

            <div class="userCard" style="justify-content: space-around">
                <button
                    class="btnGreen btnCircle btnBasic"
                    style="display: none"
                >
                    <i class="las la-cart-plus"></i>Utwórz publicznego
                    Wirtualnika
                </button>
                <button class="btnOrange btnCircle btnBasic">
                    <i class="las la-exclamation"></i>Ostrzeżenia (3)
                </button>
                <button class="btnRed btnCircle btnBasic">
                    <i class="las la-bug"></i>Błąd! (1)
                </button>
            </div>

            <sub style="display: none"
                >Nie wykryto problemów z tą konfiguracją 😊</sub
            >
        </div>
        <div class="list sidebarList currency">
            <li>
                <img
                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                /><a href="amd_ryzen_3_3100.htm"> AMD Ryzen 3 3100 </a>
                <p>
                    2342.97<img
                        src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                        alt="Morele.net"
                    />
                </p>
                <i class="las la-angle-up"></i>
            </li>
            <div class="productExtraInfo">
                <div class="pcs-controls">
                    <i class="las la-angle-up"></i>
                    <p>1x</p>
                    <i class="las la-angle-down"></i>
                </div>
                <button class="btnRed btnCircle btnBasic">
                    <i class="las la-trash"></i>Usuń produkt
                </button>
            </div>

            <li>
                <img
                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                /><a href="amd_ryzen_3_3100.htm"> G.Skill 2x8GB 3200MHz C16 </a>
                <p>
                    2943.13<img
                        src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                        alt="Morele.net"
                    />
                </p>

                <div class="pcs-controls">
                    <i class="las la-angle-down"></i>
                </div>
            </li>
            <li>
                <img
                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                /><a href="amd_ryzen_3_3100.htm"> Gigabyte Z490 Gaming X </a>
                <p>
                    2541.71<img
                        src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                        alt="Morele.net"
                    />
                </p>
                <div class="pcs-controls">
                    <i class="las la-angle-down"></i>
                </div>
            </li>
            <li>
                <img
                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                /><a href="amd_ryzen_3_3100.htm"> Crucial MX500 1TB </a>
                <p>
                    462.23<img
                        src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                        alt="Morele.net"
                    />
                </p>
                <div class="pcs-controls">
                    <i class="las la-angle-down"></i>
                </div>
            </li>
            <li>
                <img
                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                /><a href="amd_ryzen_3_3100.htm">
                    Gigabyte RTX 3070 Gaming X
                </a>
                <p>
                    9877.32<img
                        src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                        alt="Morele.net"
                    />
                </p>
                <div class="pcs-controls">
                    <i class="las la-angle-down"></i>
                </div>
            </li>
            <li>
                <img
                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                /><a href="amd_ryzen_3_3100.htm"> SilentiumPC Vero L3 600W </a>
                <p>
                    3842.00<img
                        src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                        alt="Morele.net"
                    />
                </p>
                <div class="pcs-controls">
                    <i class="las la-angle-down"></i>
                </div>
            </li>
            <li>
                <img
                    src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                /><a href="amd_ryzen_3_3100.htm"> SilentiumPC Signum SG1 TG </a>
                <p>
                    214.55<img
                        src="https://wirtualnik.pl/static/img/cpu/ryzen_3_3100-box.png"
                        alt="Morele.net"
                    />
                </p>
                <div class="pcs-controls">
                    <i class="las la-angle-down"></i>
                </div>
            </li>
        </div>
    </div>
</template>
<script lang="ts">
export default {};
</script>
<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
</style>
