<template>
    <li>
        <slot name="spec-key"></slot>
        <p><slot name="spec-value"></slot></p>
    </li>
</template>
<style lang="scss" scoped>
@import url('@//assets/shadient/shadient.css');
@media screen and (max-width: 720px) {
    @import url('@//assets/shadient/shadient_mobile.css');
}
</style>
