<template>
    <div id = uStats v-if="$store.state.token != ''">
        <h3>Number of Collections for this User: {{this.$store.state.userStats.numberOfCollections}}</h3>
        <h3>Number of Comics in this User's Collections: {{this.$store.state.userStats.numberOfComics}}</h3>
    </div>
</template>

<script>
import BackendService from '../services/BackendService';
export default {
    name: 'user-stats',
    created() {
        this.setUserStats();
    },
    methods: {
        setUserStats() {
            BackendService.getUserStats(this.$store.state.user.userId).then(response => {
                this.$store.commit('SET_USER_STATS', response.data);
            })
        }
    }
}
</script>

<style>
div#uStats{
    display: grid;
    grid-template-columns: 1fr 1fr;
    border: grey;
    border-style: solid;
    border-width: 1px;
    border-radius: 25px;
    padding-top: 50px;
    padding-bottom: 0px;
    margin-left: 50px;
    margin-right: 50px;
    background-color: rgb(24, 9, 36);
}
</style>