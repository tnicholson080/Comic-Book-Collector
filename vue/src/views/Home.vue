<template>
<body>
  

  <div>
    <p></p>
       <h1 id = pubCollectionsTitle> Public Collections </h1>
       <div id= "publicCollectionsDisplay">
       <public-collections/>
       </div>
    <p> </p>
   <div class="stats">
      <overall-stats/> 
      <p></p>
      <user-stats/>
     </div> 
     <div id="nav">
       
       
      
    </div>
  </div>
  </body>
</template>

<script>


import PublicCollections from '../components/PublicCollections.vue';
import UserStats from '../components/UserStats.vue';
import OverallStats from '../components/OverallStats.vue';


export default {
  components: {  PublicCollections, UserStats, OverallStats },


    created(){
      this.resetFormData();
    
    },
methods:{
    resetFormData() {
           this.comicList = []
            this.$store.commit("GET_COMIC_SEARCH", this.comicList)
        },
}
};

</script>
<style>
body{
  background: rgb(24, 6, 32);
 
}

h1{
  color: rgb(255, 251, 0);
  text-align: center;
}
button.home{
   background:rgb(255, 230, 0);
}

div#publicCollectionsDisplay{
  
   
 border: grey;
    border-style: solid;
    border-width: 1px;
    border-radius: 25px;
    padding-top: 35px;
    padding-bottom: 35px;
    margin-left: 250px;
    margin-right: 50px;
     background-color: rgb(39, 39, 63);
}

h1#pubCollectionsTitle{
  margin-left: 200px;
  font-size: 72px;
  background: -webkit-linear-gradient(rgb(229, 255, 0), rgb(255, 0, 0));
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  margin-top: -50px;
  margin-bottom: 35px;
  font-family: bangers;
}
.stats{
text-align: center;
margin-left: 200px;
color: yellow;
}
</style>