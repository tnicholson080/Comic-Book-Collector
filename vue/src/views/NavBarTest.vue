<template>
<div class="main"> 
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
     <button class="showNav" v-on:click="showNav = !showNav"><i class="fa fa-bars"> </i> </button>



  <div class="navbar"  v-if="showNav">
     
      <ul class="links">
          <li>
              <router-link v-bind:to="{ name: 'login' }"><button v-on:click="showNav = !showNav">Login</button></router-link>&nbsp;&nbsp;
          </li>
      
       
      <li>
          <router-link :to="{ name: 'register' }"><button v-on:click="showNav = !showNav">Register</button></router-link>
      </li>
       <li>
           <router-link v-bind:to="{ name: 'MyCollections' }"><button v-on:click="showNav = !showNav">My Collections</button></router-link>
       </li>
       <li>
            <router-link :to="{ name: 'CollectionSearch' }"><button v-on:click="showNav = !showNav">Browse Collections</button></router-link>
       </li>
      
     <li>
           <router-link :to="{ name: 'ComicSearch' }"><button v-on:click="showNav = !showNav">Browse Comics</button></router-link>
     </li>
      <li>
            <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''"><button v-on:click="showNav = !showNav">Logout</button></router-link>
        </li>
       </ul>
  </div>
  </div>
</template>

<script>
export default {
 data() {
        return {
            showNav: false,
        }    
    }
}
</script>

<style>
div.main{
    
}
div.navbar{
    width: 12rem;
    height: 100vh;
    position: fixed;
    opacity: 70%;

}
ul{
    
    list-style: none;
    padding: 0;
    margin: 0;
    display: flex;
    flex-direction: column;
    
}
ul:last-child{
    margin-top: auto;
}
li{
    display: flex;
    align-items: center;
    text-decoration: none;
   
}
button.showNav:click{
transition: height 200ms ease;
}
</style>