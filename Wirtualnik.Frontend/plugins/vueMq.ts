import Vue from 'vue';

Vue.mixin({
    computed: {
        phone() {
            return ['xs'].includes(this.$mq as string);
        },
        tablet() {
            return ['sm', 'md'].includes(this.$mq as string);
        },
        mobile() {
            return ['xs', 'sm'].includes(this.$mq as string);
        },
        laptop() {
            return ['lg'].includes(this.$mq as string);
        },
        desktop() {
            return ['xl'].includes(this.$mq as string);
        }
    }
});
