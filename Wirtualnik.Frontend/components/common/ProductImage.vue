<template>
    <img :src="link" />
</template>
<script>
import { Component, Vue } from 'nuxt-property-decorator';

@Component({
    props: {
        url: { type: [], required: true, default: '' }
    },
    data: function () {
        return { link: 'loading' };
    },
    template: '<div>{{ link }} </div>',
    created() {
        this.getLink();
    },
    methods: {
        async getLink() {
            setTimeout(() => {
                this.link = this.url[0];
            }, 1000);
        }
    }
})
export default class ProductImage extends Vue {}
</script>
<style></style>
