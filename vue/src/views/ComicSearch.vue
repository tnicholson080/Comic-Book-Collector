<template>
  <p class="searchForm">

    <comics-search />
  </p>
</template>

<script>
import ComicsSearch from '../components/ComicsSearch.vue'
export default {
  components: { ComicsSearch },

}
</script>

<style>
p{
  display: flex;
  justify-content: center;
}
.searchForm{
  
  margin-left: 200px;

    
    gap: 20px;
    justify-content: space-evenly;
    padding-left: 400px;
    padding-right: 400px;
  
    border-radius: 10rem;
}
</style>