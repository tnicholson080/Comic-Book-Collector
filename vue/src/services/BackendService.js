import axios from "axios";

// const http = axios.create({
//     baseURL: "https://localhost:44315"
// })

export default{



searchComicByIssueName(search){
return axios.get(`/comics/search/${search}`);
},
getComicById(comicId){
    return axios.get(`/comics/${comicId}`);
 },
getAllPublicCollections(){
    return axios.get(`/collections/public`);
},
getMyCollections(userId){
    return axios.get(`/users/${userId}/collections`);
  },

getPublicCollectionByUser(userId){
    return axios.get(`/users/${userId}/collections`);
  },
getCollectionDetails(collectionId){
    return axios.get(`/collections/${collectionId}`);
  },
addCollection(collection){
    return axios.post('/collections', collection);
},
addComicToCollection(collectionId, comic){
    return axios.post(`/collections/${collectionId}`, comic);
},
deleteCollection(collectionId){
    return axios.delete(`/collections/${collectionId}`);
},
deleteComicFromCollection(collectionId, comic){
    return axios.delete(`/collections/${collectionId}/delete-comic-from-collection`, comic)
},
getComicDetails(comicId){
    return axios.get(`/comics/${comicId}`);
},
updateCollectionDetails(collectionId, Collection){
    return axios.put(`/collections/${collectionId}`, Collection);
},
getComicsFromCollection(collectionId){
    return axios.get(`/collections/${collectionId}/comics`);
},
getOverallStats(){
    return axios.get('/stats/overall');
},
getUserStats(userId){
    return axios.get(`/stats/${userId}`);
},
toggleFavoriteStatus(collectionId){
    return axios.put(`collections/${collectionId}/toggle-favorite`);
}
}