<template>
 <div class="user-menu" :class="{ 'menu-opened': isMenuOpened}">
   <section>
     <h3>Hej Maksymilian</h3>
     <div class="page-header__extras">
       <div class="btn-flat">
         <img src="~/assets/images/user.jpg" />
       </div>
     </div>
   </section>
 </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'
@Component({
  name: 'PopupMenu'
})
export default class PopupMenu extends Vue {
  @Prop({
    default: false
  })
  private isMenuOpened: boolean
}
</script>
