<template>
<body>
  <div id = container>


    <p></p>
      
     
       <div id = addNew>
       <new-collection-form/>
       </div> 
       <p></p>
       <div id = browse>
       <router-link :to="{ name: 'ComicSearch' }"><button>Browse Comics</button></router-link>
       </div>
       <p></p>
       </div>
       <h2 id = CollectionTitle>My Collections</h2>
       <div id = collectionsDisplay>
       <collection-list/>
       </div>
  
  </body>
</template>

<script>
import NewCollectionForm from '../components/NewCollectionForm.vue';
import CollectionList from '../components/CollectionList.vue';


export default {
  components: { CollectionList, NewCollectionForm,  },
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
   color: aliceblue;
     text-align: center;
}
h1{
  color: aliceblue;
}


div#addNew{
  text-align: center;
  margin-left: 200px;
  
}

div#collectionsDisplay{
  margin-left: 200px;
  padding-top: 30px;
  padding-bottom: 30px;
  background-color: rgb(39, 39, 63);
  border-radius: 30px;
}

div#browse{
  margin-left: 200px;
}

 h2#CollectionTitle
 {
   color: rgb(255, 217, 0);
   margin-left: 200px;
   font-family: bangers;
   font-size: 300%;
   text-shadow: -1px -1px 0 rgb(179, 48, 0), 2px -1px 0 orangered, -1px 1px 0 #000, 1px 1px 0 #000;
 }

div#container{

}
</style>