<template>
  <div>
    <div>
    <h2></h2>
     <img v-bind:src="currentComic.imageThumb_url" />
      <h1>{{currentComic.name}}</h1>
      <h2>{{currentComic.cover_date}}</h2>
      <a v-bind:href="currentComic.site_detail_url">Comic Vine Wiki URL</a>
 
      
     
    

  </div>


  </div>
</template>

<script>
import BackendService from '../services/BackendService';
export default {
  
  data(){
    return{
       currentComic: {
      
    },
    }
  },
 components: {  },
 created(){
   this.getComicDetails()
 },
 methods:{
 getComicDetails(){
         BackendService.getComicById(this.$route.params.comicId
         ) 
         
         .then(response => {
                
                {
                    // this.currentComic.id = response.id;
                    // this.currentComic.title = response.title;
                    // this.currentComic.coverUrl = response.coverUrl;
                    // this.currentComic.wikiUrl = response.wikiUrl;
                    // this.currentComic.year = response.year;
                    this.currentComic = response.data;
                    this.$store.commit('VIEW_COMIC_DETAILS', this.currentComic);
                    
                }
            })
    }
    },
 }

</script>

<style>
a{
  font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
  font-size: 140%;
}
</style>
