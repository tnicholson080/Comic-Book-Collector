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
        user:{
      isPremium: this.$store.state.user.isPremium,
      role:"",
      userId:this.$store.state.user.userId,
      username: this.$store.state.user.username}
      }
    },
    created() {
    this.getCollection();
  },
    methods:{
 getCollection() {
            BackendService.getMyCollections(this.user.userId).then(response => {
                
                {
                    this.collectionList = response.data;
                    this.$store.commit('VIEW_MY_COLLECTIONS', this.collectionList);
                    
                }
            })
            
    },
  deleteCollection(){
      BackendService.deleteCollection(this.$route.params.collectionId).then(response =>{
        if(response.status === 200){
          alert("Collection Deleted.");
        }
      })
  }
    }}
</script>

<style>
.collections-container {
    display:flex;
    flex-wrap: wrap;
    gap: 25px;
    justify-content: space-evenly;
    padding-left: 40px;
    padding-right: 40px;
     

    border-radius: 3rem;
    
}


</style>