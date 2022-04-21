<template>
<div class="main"> 
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
     <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Bangers">
 


  <div class="navbar">
   

      <ul class="links" >
          <!-- <li>
              <i class="fa fa-bars" id="bars" title="Navigation"></i>
          </li> -->
          <div class="isPremium" v-if="isPremium">
          <li v-if="!premiumShield" class="prem">Premium User!</li>
            <li class="shield" @mouseover="premiumShield = false" @mouseleave="premiumShield = true">
                <img src="../assets/Captain_America's_shield.svg - Copy.png">
              
            </li>
            </div>
           <li> <router-link class="link" v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;&nbsp;
    </li>
          <li>
              <router-link class="link" v-bind:to="{ name: 'login' }">Login</router-link>&nbsp;&nbsp;
          </li>
      
       
      <li>
          <router-link class="link"  :to="{ name: 'register' }"><font-awesome-icon icon="fa-solid fa-user-plus" />Register</router-link>
      </li>
       <li>
           <router-link class="link"  v-bind:to="{ name: 'MyCollections' }">My Collections</router-link>
       </li>
   
      
     <li>
           <router-link class="link"  :to="{ name: 'ComicSearch' }">Browse Comics</router-link>
     </li>
      <li>
            <router-link class="link"  v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
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
            premiumShield: true,
            isPremium: false,
        }    

    },
      created(){
      this.isUserPremium()
    
    },
methods:{
    isUserPremium(){
        if (this.$store.state.user.isPremium === true){
            this.isPremium = true;
       
        }
    }
}
}
</script>

<style>
div.main{
  
    
    
}



div.navbar{
    width: 200px;
    height: 100vh;
    position: fixed;
    opacity: 100%;

background: rgba(39,39,63,1) ;
   
}

.navbar:hover {
    /* width:500px; */
    
}
ul{
    
    list-style: none;
    padding: 0px;
    margin: 0px;
    display: flex;
    flex-direction: column;
    align-items: center;
    
    
}







li{
    display: flex;
    align-items: center;
    text-decoration: none;
    justify-content: center;
    width: 200px;
    height: 75px;
    font-size: 10px;
     background:rgb(39 39 63)
    
    /* border-radius: 10rem; */
    
    }

li:last-child{
    margin-bottom: auto;
  
    
}

li:hover{
    background-color: rgb(59, 59, 95);
    border: rgb(255, 230, 0);
    border-style:solid;
    border-radius: 15rem;
}


ul.links {
    display: flex;
    align-items: center;
    background-color:transparent;
    height: 50 px;
    text-decoration: none;
     
    }


 
a:link {
  text-decoration: none;
  color: red;
   
}

a:hover{
    color:yellow
}

link-text {
    display: none;
    
}


button.showNav:click{
transition: height 200ms ease;
}
.shield{
   
    height: auto; 
    width: auto; 
   
}
.link{
    color: white;
font-family: bangers;
font-size:  300%;
}
.prem{
    color: white;
font-family: bangers;
font-size:  200%;
}
.shield:hover{
   border:none;
   background-color: none;
   background: rgba(39,39,63,1) ;
   
}
</style>