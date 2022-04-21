<template>
  <div>

    <collection-search/>
     <div id = collectionsDisplay>
       <h2> MY COLLECTIONS</h2>
    <collection-list/>
    </div>



  </div>
</template>

<script>
import CollectionList from '../components/CollectionList.vue'
import CollectionSearch from '../components/CollectionSearch.vue'

export default {
  components: { CollectionList, CollectionSearch },

}
</script>

<style>
div#collectionsDisplay{
  margin-left: 200px;
}
</style>