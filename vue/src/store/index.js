import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    collectionList: [],
    comicList: [],
    collection: {
      title: '',
      id: '',
      description: '',
      comics: [],
      cover: '',
      isPublic: true,
      theme: '',
      isFavorited: false,
      favorites: 0,
      userId: -1
    },
    comic: {
      title: '',
      coverUrl: '',
      id: '',
      wikiUrl: '',
      year: '',
    },
    searchList: [],
    token: currentToken || '',
    user: currentUser || {},
    userStats: {
      numberOfCollections:'',
      numberOfComics:''
    },
    overallStats: {
      numberOfUsers:'',
      numberOfCollections:'',
      numberOfComics:''
    }
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    NEW_COLLECTION(state, collection) {
      state.collectionList.push(collection);
    },
    GET_COMIC_SEARCH(state, data){
      state.searchList = data;
    },
    ADD_COMIC(state, comic) {
      state.collection.comics.push(comic);
    },
    VIEW_MY_COLLECTIONS(state, data){
      state.collectionList = data;
    },
    VIEW_COLLECTION_DETAILS(state, data){
      state.collection = data;
    },
    VIEW_COMIC_DETAILS(state, data){
      state.comic = data;
    },
    VIEW_COLLECTION_COMICS(state, data){
      state.comicList = data;
    },
    SET_OVERALL_STATS(state, data){
      state.overallStats = data;
    },
    SET_USER_STATS(state, data){
      state.userStats = data;
    },
    
    
  }
})
