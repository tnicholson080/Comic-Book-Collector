import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import store from '../store/index'
import MyCollections from '../views/MyCollections.vue'
import ComicSearch from '../views/ComicSearch.vue'
import CollectionSearch from '../views/CollectionSearch.vue'
import CollectionDetail from '../views/CollectionDetail.vue'
import ComicDetail from '../views/ComicDetail.vue'
Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/MyCollections",
      name: "MyCollections",
      component: MyCollections,
      meta: {
        requiresAuth: true
      }

    },
    {
      path: "/ComicSearch",
      name: "ComicSearch",
      component: ComicSearch,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/CollectionSearch",
      name: "CollectionSearch",
      component: CollectionSearch,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/CollectionDetail/:collectionId",
      name: "CollectionDetail",
      component: CollectionDetail,
      meta: {
        requiresAuth: false
      },
    },
    {
      path: "/ComicDetail/:comicId",
      name: "ComicDetail",
      component: ComicDetail,
      meta: {
        requiresAuth: false
      },
    },
    
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
