<template>
    <div class="modal full-width">
        <p>
            Konto na Wirtualnik.pl zostanie automatycznie utworzone podczas
            pierwszego logowania
        </p>
        <div class="logging-buttons">
            <div
                class="fb-login-button"
                data-width=""
                data-size="large"
                data-button-type="continue_with"
                data-layout="rounded"
                data-auto-logout-link="true"
                data-use-continue-as="true"
            ></div>
        </div>
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator';
@Component({
    name: 'Login'
})
export default class Login extends Vue {}
</script>

<style lang="scss" scoped>
.modal {
    display: flex;
    background: var(--white);
    box-shadow: var(--shadowcard), var(--shadowcard);
    border-radius: 15px;
    flex-wrap: wrap;
}
.full-width {
    width: 100%;
    padding: 20px;
    p {
        flex-basis: 100%;
        color: var(--black);
        text-align: center;
        margin: 0;
    }
}
.logging-buttons {
    display: flex;
    justify-content: center;
    width: 100%;
}
</style>
