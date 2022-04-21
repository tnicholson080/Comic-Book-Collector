<template>

  <div class="collection" v-bind:class="{ title: collection.title }">
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <h2 class="collection-title">{{ collection.title }} <i class="fa fa-check" id="check" title="Favorite" v-if="collection.isFavorited"></i></h2>
    <div class="image">
    <router-link v-bind:to="{ name: 'CollectionDetail', params:{collectionId: collection.id} } ">
      <img v-if="collection.cover != 'BatTom'" v-bind:src="collection.cover" />
      <img v-else src="../../assets/BatTom.png" />
    </router-link>
    </div>
     <h4 class="collection-is-public" title="User Access" v-bind:class="collection.isPublic ? 'public' : 'private'">{{collection.isPublic ? 'Public' : 'Private'}}  <i class="fa fa-unlock"  v-if="collection.isPublic"></i><i class="fa fa-lock"  v-else></i>
      </h4>
      <h4></h4>
      

  </div>
</template>

<script>
export default {
   
    data(){
      return{
        
      }
    },
     name: 'collection-card',
    props: {
        collection: Object
    },
    methods: {},
    
    computed: {
         
        


    }
}

</script>

<style>
div{
    padding-bottom: 20px;
    
}
#check{
  color: rgb(0, 189, 0);
  background-color: ivory;
  border-radius: 15px;
  border-color: rgb(0, 255, 0);
  border: solid;
}
.collection{
  border: black;
  border-style: solid;
  padding-left: 40px;
  padding-right: 40px;
  border-radius: 15px;
  background-color: darkmagenta;
}
.image{
  
}
.collection-title{
   white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  max-width: 150px;
}
</style>