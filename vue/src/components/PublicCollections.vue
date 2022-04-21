<template>
  <div class="collections-container">

         <collection-card v-for="collection in $store.state.collectionList" v-bind:collection="collection" v-bind:key="collection.title" />
  
  </div>
</template>

<script>
import CollectionCard from '@/components/CollectionCard.vue';
import BackendService from '../services/BackendService';


export default {
    name: 'collection-list',
    components: {
       CollectionCard
       
    },
    data(){
      return {
        collectionList: [],
        
      }
    },
    created() {
    this.getPublicCollections();
  },
    methods:{
 getPublicCollections() {
            BackendService.getAllPublicCollections().then(response => {
                
                {
                    this.collectionList = response.data;
                    this.$store.commit('VIEW_MY_COLLECTIONS', this.collectionList);
                    
                }
            })
            
    }
    }}
</script>

<style>
.collections-container {
    display:grid;
     grid-template-columns: repeat(5, 1fr);
    gap: 20px;
    justify-content: space-evenly;
    padding-left: 400px;
    padding-right: 400px;
    
    border-radius: 10rem;
    
}

</style>