<template>
  
    <form >
        <div class="collection-search"> <p></p>
            <input type="search" name="search" id="search" v-model="searchParameter"/>
             <comics-list v-for="collection in $store.state.searchList" v-bind:collection="collection" v-bind:key="collection.id"/><p></p>
             <button v-on:click.prevent="GetCollection(searchParameter)">Search</button>
        </div>
    </form>


 
</template>

<script>


export default {
    name: "CollectionSearch",
    props:{
        
    },
data(){
    return{
        searchParameter: '',
        
    }
},
methods:{
GetCollection(){
    
    
},
/*computed:{
    listResults(){
        return this.$store.state.searchList;
    }
}
*/

}
}
</script>

<style>

</style>