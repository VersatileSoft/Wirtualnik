<template>
    <div class="pagination-nav">
        <sliding-pagination
            :current="pager.getPageIndex()"
            :total="pager.totalPages"
            @page-change="pageChangeHandler"
        ></sliding-pagination>
    </div>
</template>
<script lang="ts">
import { Component, Prop, Vue } from 'nuxt-property-decorator';
import Pager from '@/helpers/Pager';

@Component({})
export default class PagerComponent extends Vue {
    @Prop({ default: null })
    private pager: Pager;

    private async pageChangeHandler(selectedPage: number): Promise<void> {
        this.pager.setPageIndex(selectedPage);
        this.$emit('reload');
    }
}
</script>
<style lang="scss">
@import url('vue-sliding-pagination/dist/style/vue-sliding-pagination.css');
.pagination-nav {
    width: 100%;
    height: 200px;
    nav {
        height: 100px;
        display: flex;
        justify-content: center;
        align-items: center;
    }
}
.c-sliding-pagination__list-element {
    border: var(--gray3) solid 1px;
    background: #fff;
    color: var(--gray3);
    padding: 0;
}
.c-sliding-pagination__list-element a {
    display: block;
    padding: 0.6em;
}
.c-sliding-pagination__list-element:hover {
    background: var(--gray3);
    color: #fff;
}
.c-sliding-pagination__list-element--active {
    background: var(--gray3);
    color: #fff;
}
.c-sliding-pagination__page {
    display: block;
}
</style>
