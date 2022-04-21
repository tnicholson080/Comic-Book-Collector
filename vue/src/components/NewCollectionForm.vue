<template>
<div>
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<button class="btn addCollection" v-if="!showAddCollection" v-on:click="showAddCollection = !showAddCollection"><i class="fa fa-plus"> </i> Add New Collection </button>
  <form class="new-collection-form" v-on:submit.prevent="addCollection" v-if="showAddCollection">Add New Collection
      <p></p>
    <input class="title-input" type="text" placeholder="Title" v-model="collection.title" required/>
    <p></p>
    <textarea class="description-input"  placeholder="Description" v-model="collection.description" required/>
    <p></p>
    <label for="cover-input">Collection Cover Image </label>
     <select name="cover-input" class="cover-input" id="cover-input"  v-model="collection.cover" required>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/1/14487/7835285-b7f54158-13c3-4646-bbee-033a765c570d.jpeg">Black Widow</option>    
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/12/124259/7899178-batman_vol_3_86_textless.jpg">Batman</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/12/124259/8126579-amazing_spider-man_vol_5_54_stormbreakers_variant_textless.jpg">Spider-Man</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/5/57023/7391162-cap%20by%20alex%20ross.jpg">Captain America</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/12/124259/7892286-immortal_hulk_vol_1_38_.jpg">Hulk</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/3/31666/3591176-fls_30_52cf49e70d6465.15357135.jpg">The Flash</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/11138/111381541/8292772-wonderwoman.jpg">Wonder Woman</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/11125/111252513/8224947-whrcgpwcwhv5hqkzc4xheg-1920-80.jpg">Nightwing</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/1/14487/8278735-9ef81638-c944-4a63-8fb0-d32883953165.jpeg">Green Lantern</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/5/57023/7469590-wolverinerb.jpg">Wolverine</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/11138/111389575/7768211-4293283244-2Pac8Gpu6dUAUMI0UpVJeqk9rayKSiaTjreIK0H-ChAWsoNV-RxTnTEt4a7tCNryrbLjFPndaoNki-tJJI1Q-_mi8fue_juP4cBRHx0Er1w5EfjNoWwadqewG3JSwaliSSsHnNEN%3Ds1600.jpg">Iron Man</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/3/31666/5396935-thanos2016001-deodato-d9505.jpg">Thanos</option>
        <option value="https://comicvine.gamespot.com/a/uploads/original/3/36052/2122733-l.mythology_the_joker.jpg">The Joker</option>
        <option value="https://comicvine.gamespot.com/a/uploads/scale_small/12/124259/6985439-loki.jpg">Loki</option>
        <option value="https://comicvine.gamespot.com/a/uploads/original/8/83882/1761902-thor_mighty_hammer.jpg">Thor</option>
        <option value="BatTom">BatTom</option>
        <!--<img src="..\assets\BatTom.png" alt="">-->

   </select> 
   <p></p>
   <label for="public">Make Public?</label>
    <label class="public">
    <input type="checkbox" value=true v-model="collection.isPublic">
    <span class="public"></span>
    </label>
    <p></p>
    
    <p></p>
   
    <p></p>
    <button >Add</button><button class="btn btn-cancel" v-on:click="showAddCollection = !showAddCollection">Cancel</button>
  </form>
  </div>
</template>

<script>
import BackendService from '../services/BackendService';
export default {
    name: "new-collection-form",
    data() {
        return {
            showAddCollection: false,
            collection: {
                id: -1,
                title: '',
                isPublic: false,
                userId: -1,
                favorites: 0,
                isFavorited: false,
                comics: [],
                description: '',
                cover: '',
                theme: '',

            },
        }
    },
    methods: {
        addCollection() {
            BackendService.addCollection(this.collection).then(response => {
                if (response.status == 201)
                {
                    this.collection.id = response.data.id;
                    this.collection.title = response.data.title;
                    this.collection.isPublic = response.data.isPublic;
                    this.collection.userId = response.data.userId;
                    this.collection.favorites = response.data.favorites;
                    this.collection.isFavorited = response.data.isFavorited;
                    this.collection.comics = response.data.comics;
                    this.collection.description = response.data.description;
                    this.collection.cover = response.data.cover;
                    this.collection.theme = response.data.theme;
                    
                    this.$store.commit('NEW_COLLECTION', this.collection);
                    this.resetFormData();
                }
            })
            .catch(error => 
            {this.handleErrorResponse(error, "creating");
            });
        },
        resetFormData() {
            this.collection = {
            title: '',
            description: '',
            comics: [],
            cover: '',
            isPublic: false,
            theme: '',
            isFavorited: false,
            id: -1,
            favorites: 0,
            userId: -1
            }
            this.showAddCollection = false;
        },
        handleErrorResponse(error, verb) {
            if (error.response) {
                this.errorMsg =
                "Error " + verb + " collection. Response received was '" +
                error.response.statusText +
                "'.";
            } else if (error.request) {
                this.errorMsg =
                "Error " + verb + " collection. Server could not be reached.";
            } else {
                this.errorMsg =
                "Error " + verb + " collection. Request could not be created.";
            }
        }
    }
}
</script>

<style>

 img{
  height: auto; 
    width: auto; 
    max-width: 200px; 
    max-height: 200px;
}
form{
    text-align: center;
  
}
button {
  display: inline-block;
  padding: .75rem 1.25rem;
  border-radius: 10rem;
  color: rgb(0, 0, 0);
  text-transform: uppercase;
  font-size: 1rem;
  letter-spacing: .15rem;
  transition: all .3s;
  position: relative;
  overflow: hidden;
  z-index: 1;
  background:rgb(255, 0, 179);
  font-family:-apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
  font-weight: 700;
}
</style>