<template>
  <p>
<comic-detail/>

  </p>
</template>

<script>
import ComicDetail from '../components/ComicDetail.vue'
export default {
  components: { ComicDetail },
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

</style>