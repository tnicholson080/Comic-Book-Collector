<template>
  <div class="comic" v-bind:class="{ title: comic.name }">
      
    <h2 class="comic-title">{{ comic.name }}</h2>
    <router-link v-bind:to="{ name: 'ComicDetail', params: {comicId: comic.id} }">
      <img v-if="comic.imageThumb_url" v-bind:src="comic.imageThumb_url" />
   
    </router-link>
    
    <!-- <button>Add Comic</button> -->
    <div class="rightHalf">
    <select name="collectionList" id="collectionList" v-model="selection">
      <option v-for="collection in $store.state.collectionList" v-bind:key="collection.id" v-bind:value="collection.id">{{collection.title}}</option>
    </select><p></p>
    <button v-on:click.prevent="addComic(selection)">Add</button>
    </div>
     <!-- <p ></p><i  class="fa fa-ban" id="ban" title="Delete Comic" v-on:click="deleteComicFromCollection" @mouseover="comicWarning = true" @mouseleave="comicWarning = false"  ></i> <p v-if="comicWarning">WARNING! This will permanently delete comic from collection. </p> -->
  </div>
</template>

<script>
import BackendService from '../services/BackendService'
export default {
data(){
      return{
        comicWarning: false,
        selection: ""
      }
    },
     name: 'comic-card',
    props: {
        comic: Object
    },
    methods: {
      addComic(option){
          
          BackendService.addComicToCollection(parseInt(option), this.comic);
          alert("Comic Added");
      },
      
    },
    
    computed: {
         
        


    }
}
</script>

<style>
.comic{
   background-color: darkmagenta;
    
    padding-left: 50px;
    padding-right: 50px;
     display: grid;

    border-radius: 3rem;
}
.rightHalf{
 display: grid;
align-self: end;
}
.comic-title{
    white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  max-width: 200px;
}
</style>