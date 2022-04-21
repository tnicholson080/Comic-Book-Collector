<template>
  <div id="app" class="appDiv">
    <div id="nav" class="nav">

      
      
      <transition name="bar">
      <nav-bar />
      
      </transition>
    </div>
    <router-view />
  </div>
</template>

<script>

import NavBar from './views/NavBar.vue'

export default {
  name: 'app',
  components: { NavBar
    
  },


}
</script>
<style>
div.app{
  text-align: left;
  margin-left: 15rem;
  
}
div.nav{
  text-align: left;
  
}
div.navbar{
  transition: width 200ms ease;
}
.bar-enter-active,
.bar-leave-active {
  transition: all 0.5s ease;
}
.bar-enter-from,
.bar-leave-to {
  opacity: 0;
  transform: translateX(30px);
}
</style>