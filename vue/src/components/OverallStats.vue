<template>
    <div id = overallStats>
        <div>
        <h3>Number of Total Collections: </h3>
        <h6> {{this.$store.state.overallStats.numberOfCollections}} </h6></div>
        <div>
        <h3> Total comics across all users':</h3>
        <h6> {{this.$store.state.overallStats.numberOfComics}}</h6></div>
        <div><h3>Registered users:</h3>
        <h6> {{this.$store.state.overallStats.numberOfUsers}} </h6></div>
    </div>
</template>

<script>
import BackendService from '../services/BackendService';
export default {
    name: 'overall-stats',
    created() {
        this.setOverallStats();
    },
    methods: {
        setOverallStats() {
            BackendService.getOverallStats().then(response => {
                this.$store.commit('SET_OVERALL_STATS', response.data);
            })
        }
    }
    
}
</script>

<style>
div#overallStats{
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
    
    padding-top: 50px;
    padding-bottom: 0px;
    margin-left: 50px;
    margin-right: 50px;
   
    margin-top: 0px;
}

h6{
    margin-top: -20px;
    font-size: 125px;
    margin-bottom: 0px;
    font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
    color: white;
}
</style>