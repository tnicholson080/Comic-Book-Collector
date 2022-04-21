<template>
  <div>
    <h2></h2>
     <img class="cover" v-if="currentCollection.cover != 'BatTom'" v-bind:src="currentCollection.cover" /> 
     <img v-else src="../../assets/BatTom.png" />
      <p ></p><i class="fa fa-ban" id="ban" title="Delete Collection" v-on:click="deleteCollection" @mouseover="warning = true" @mouseleave="warning = false"  ></i> <p v-if="warning">WARNING! This will permanently delete collection. </p>
      <h1>{{currentCollection.title}}
        
       <i class="fa fa-check" id="check" title="Favorite" v-if="currentCollection.isFavorited"></i>
      
      </h1>

      <h2>{{currentCollection.description}}</h2>
      <h4 class="collection-is-public" title="User Access" v-bind:class="currentCollection.isPublic ? 'public' : 'private'">{{currentCollection.isPublic ? 'Public' : 'Private'}}  <i class="fa fa-unlock"  v-if="currentCollection.isPublic"></i><i class="fa fa-lock"  v-else></i>
      <p></p> Number of Favorites: {{currentCollection.favorites}}
      <p></p>
      <button v-on:click.prevent="toggleFavoriteStatus()">Favorite</button>
      </h4>

<div id = editArea>
<button class="btn edit-collection" v-if="!showEditForm" v-on:click="showEditForm = !showEditForm"><i class="fa fa-pencil"> </i> Edit Collection </button>
  <form class="edit-form" v-on:submit.prevent="updateCollectionDetails" v-if="showEditForm">
      <p></p>
      <label for="title-input">Title: </label>
    <input class="title-input" type="text" placeholder="Title" v-model="currentCollection.title" required/>
    
    <h4>Description: </h4>
    <textarea class="description-input"  placeholder="Description" v-model="currentCollection.description" required/>
    <p></p>
    <label for="cover-input">Collection Cover Image </label>
     <select name="cover-input" class="cover-input" id="cover-input"  v-model="currentCollection.cover" required>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/1/14487/7835285-b7f54158-13c3-4646-bbee-033a765c570d.jpeg">Black Widow</option>    
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/12/124259/7899178-batman_vol_3_86_textless.jpg">Batman</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/12/124259/8126579-amazing_spider-man_vol_5_54_stormbreakers_variant_textless.jpg">Spider-Man</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/5/57023/7391162-cap%20by%20alex%20ross.jpg">Captain America</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/12/124259/7892286-immortal_hulk_vol_1_38_.jpg">Hulk</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/3/31666/3591176-fls_30_52cf49e70d6465.15357135.jpg">The Flash</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/11138/111381541/8292772-wonderwoman.jpg">Wonder Woman</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/11125/111252513/8224947-whrcgpwcwhv5hqkzc4xheg-1920-80.jpg">Nightwing</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/1/14487/8278735-9ef81638-c944-4a63-8fb0-d32883953165.jpeg">Green Lantern</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/5/57023/7469590-wolverinerb.jpg">Wolverine</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/11138/111389575/7768211-4293283244-2Pac8Gpu6dUAUMI0UpVJeqk9rayKSiaTjreIK0H-ChAWsoNV-RxTnTEt4a7tCNryrbLjFPndaoNki-tJJI1Q-_mi8fue_juP4cBRHx0Er1w5EfjNoWwadqewG3JSwaliSSsHnNEN%3Ds1600.jpg">Iron Man</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/3/31666/5396935-thanos2016001-deodato-d9505.jpg">Thanos</option>
        <option value="https://comicvine.gamespot.com/a/uploads/original/3/36052/2122733-l.mythology_the_joker.jpg">The Joker</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/12/124259/6985439-loki.jpg">Loki</option>
        <option value="https://comicvine.gamespot.com/a/uploads/original/8/83882/1761902-thor_mighty_hammer.jpg">Thor</option>
        <option value="BatTom">BatTom</option>
   </select> 
   <p></p>
   <label for="public">Make Public?</label>
    <label class="public">
    <input type="checkbox" value=true v-model="currentCollection.isPublic">
    <span class="public"></span>
    </label>
    <p></p>
    <!-- <label for="theme">Theme Selection </label>  -->
    <!-- <select  id="theme" placeholder="Theme" v-model="currentCollection.theme" >
        <option value="">Placeholder </option>
        <option value="">Placeholder</option>
    </select> -->
    <p></p>
   
    <p></p>
    <button v-on:click="showEditForm = !showEditForm">Update</button><button class="btn btn-cancel" v-on:click="showEditForm = !showEditForm">Cancel</button>
  </form>
  </div>
    <h4 class="comic-card">
      <comic-card v-for="comic in comicList" v-bind:comic="comic" v-bind:key="comic.title"/>
        
    </h4>
  </div>
</template>

<script>

import BackendService from '../services/BackendService';
import ComicCard from './ComicCard.vue';

export default {
  data(){
    return{
      self: this,
      currentCollection: {
        title: '',
        id: '',
        description: '',
        comics: [],
        cover: '',
        isPublic: true,
        theme: '',
        isFavorited: false,
        favorites: 0,
        userId: -1
      },
      comicList:[],
      showEditForm: false,
      warning: false,
      comicWarning: false
    }
  },
  components: {ComicCard  },
    name: 'collection-detail',
    props: {
        collection: Object,
        comic: Object

    },
    created(){
      this.getCollectionDetails();
      this.getComicsFromCollection();
    },
    methods: {
    getCollectionDetails(){
         BackendService.getCollectionDetails(this.$route.params.collectionId
           
          //  this.$store.state.searchList.find((element) => {
          //  element.id == this.$route.params.comicId;
            
         ) 
         
         .then(response => {
                
                {
                    this.currentCollection.id = response.data.id;
                    this.currentCollection.title = response.data.title;
                    this.currentCollection.isPublic = response.data.isPublic;
                    this.currentCollection.userId = response.data.userId;
                    this.currentCollection.favorites = response.data.favorites;
                    this.currentCollection.isFavorited = response.data.isFavorited;
                    this.currentCollection.comics = response.data.comics;
                    this.currentCollection.description = response.data.description;
                    this.currentCollection.cover = response.data.cover;
                    this.currentCollection.theme = response.data.theme;
                    
                    this.$store.commit('VIEW_COLLECTION_DETAILS', this.currentCollection);
                    this.showEditForm = false;
                    
                }
            })
    },
    
    getComicsFromCollection(){
      BackendService.getComicsFromCollection(this.$route.params.collectionId)
      .then(response => {
          this.comicList = response.data;
          this.$store.commit('VIEW_COLLECTION_COMICS', this.comicList);
      })
    },
    updateCollectionDetails(){
           BackendService.updateCollectionDetails(this.$route.params.collectionId, this.currentCollection)
         .then(response => {
                {
                    if (response.status === 200)
                    this.$store.commit('VIEW_COLLECTION_DETAILS', this.currentCollection);
                    
                }
            })
    },
    deleteCollection(){
       if (
        confirm(
          "Are you sure you want to delete this collection? This action cannot be undone."
        ))
      BackendService.deleteCollection(this.currentCollection.id).then(response =>{
        if(response.status != 400){
          alert("Collection Deleted.");
          this.$router.push({ name: 'MyCollections' })
        }
      })
  },
  toggleFavoriteStatus() {
    BackendService.toggleFavoriteStatus(this.currentCollection.id).then(response => {
      if(response.status == 200){
        this.currentCollection.isFavorited =response.data.isFavorited;
        this.$store.commit('VIEW_COLLECTION_DETAILS', this.currentCollection);
      }
    })
  },
  deleteComic(){
    if (
        confirm(
          "Are you sure you want to delete this comic? This action cannot be undone."
        ))
    BackendService.deleteComicFromCollection(this.currentCollection.id, this.comic).then(response =>{
      if(response.status != 400){
          alert("Comic Deleted.");}
          
    })
  }
 
}}

</script>

<style>
.comic-card {
    display:grid;
     grid-template-columns: repeat(5, 1fr);
    gap: 20px;
    justify-content: space-evenly;
    padding-left: 400px;
    padding-right: 400px;
    
    border-radius: 10rem;
}
#ban{
  color: red;
  font-size: 150%;
}
#ban:hover{
  font-size: 300%;
  animation: blinker 1s linear infinite;
 
}
@keyframes blinker {
  50% {
    opacity: 0;
  }
}
.cover{
 
  
}

div#editArea{
  
 
}

</style>