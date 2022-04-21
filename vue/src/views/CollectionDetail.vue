<template>
  <div id = cDetail>
      <collection-detail/>


  </div>
</template>

<script>
import CollectionDetail from '../components/CollectionDetail.vue'
export default {
  components: { CollectionDetail },
  created(){
      this.resetFormData();
    
    },
methods:{
    resetFormData() {
           this.comicList = []
            this.$store.commit("GET_COMIC_SEARCH", this.comicList)
        },
}
}
</script>

<style>
div#cDetail{
  margin-left: 300px;
}
</style>