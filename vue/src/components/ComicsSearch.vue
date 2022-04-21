<template>
  
    <form >

        <p></p>
            <input type="search" name="search" id="search" v-model="searchParameter"/>
            <button v-on:click.prevent="searchByIssueName(searchParameter)">Search</button><p></p>
            <div class="comic-search"> 
              <comic-card v-for="comic in $store.state.searchList" v-bind:comic="comic" v-bind:key="comic.id"/>
        </div>
      
    </form>


 
</template>

<script>
import BackendService from '../services/BackendService';
import ComicCard from './ComicCard.vue';

export default {
  components: { ComicCard },
    name: "ComicsSearch",
    props:{
        comic: Object,
        searchList: Object
    },
    data(){
        return{
            searchParameter: '',
            searchedComic:{
                title: '',
                coverUrl: '',
                id: '',
                wikiUrl: '',
                year: '',
            },
            comicList: [],
            
        }
    },
    created(){
        this.resetFormData();
    },
    methods:{
        searchByIssueName(searchParameter){
           BackendService.searchComicByIssueName(searchParameter).then(response =>{
            
                    {
                        
                        // this.searchedComic.title = response.data.ComicName;
                        // this.searchedComic.coverUrl = response.data.coverUrl;
                        // this.searchedComic.id = response.data.id;
                        // this.searchedComic.wikiUrl = response.data.wikiUrl;
                        // this.searchedComic.year = response.data.year;
                        this.comicList = response.data
                        this.$store.commit("GET_COMIC_SEARCH", this.comicList);}
                        
            })
        },
        resetFormData() {
           this.comicList = []
            this.$store.commit("GET_COMIC_SEARCH", this.comicList)
        },
    }
      
}
</script>

<style>
.comic-search{
   display:grid;
     grid-template-columns: repeat(5, 1fr);
    gap: 20px;
    justify-content: space-evenly;
    padding-left: 400px;
    padding-right: 400px;
    
    border-radius: 10rem;

}
</style>