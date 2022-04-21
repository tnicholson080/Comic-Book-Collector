<template>
  <div id="login" class="text-center">
    <form class="form-signin" @submit.prevent="login">
      <h1 class="h3 mb-3 font-weight-normal">Please Sign In</h1>
      <div
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username and password!</div>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      >Thank you for registering, please sign in.</div>
      <label for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
        
      <button id=loginButton type="submit">Sign in</button>
        <router-link :to="{ name: 'register' }"><button id=btnToRegisterPage>Register</button></router-link>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>

<style>

div#login{
  
  display: grid;
  justify-items: center;
 
}

form.form-signin{
  background-color: rgba(59,59,95);
  width: 300px;
  height: 350px;
  display: grid;
 justify-items: center;
 margin-top: 125px;
 margin-left: 200px;
 border: 5px;
 border-style: groove;
 border-color: rgb(255, 230,0);
 border-radius: 5%;
}
#loginButton{
  background-color: darkmagenta;
  margin-top: 20px;
  margin-bottom: 0px;
}
#btnToRegisterPage{
  background-color: darkmagenta;
}
input#username.form-control{
  width: 230px;
}

input#password.form-control{
  width: 230px;
  margin-bottom: 20px;
}

h1{
  font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
}
</style>
