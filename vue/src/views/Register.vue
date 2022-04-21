<template>
  <div id="register" class="text-center">
    <form class="form-register" @submit.prevent="register">
      <h1 class="h3 mb-3 font-weight-normal">Create Account</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <!-- <label for="username" class="sr-only">Username</label> -->
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <!-- <label for="password" class="sr-only">Password</label> -->
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <input
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      <!-- <label for="emailAddress" class="sr-only">Email Address</label> -->
      <input
        type="email"
        id="emailAddress"
        class="form-control"
        placeholder="Email Address (Optional)"
        v-model="user.emailAddress"
      />
      <input
        type="email"
        id="confirmEmailAddress"
        class="form-control"
        placeholder="Confirm Email Address (Optional)"
        v-model="user.confirmEmailAddress"
      />
  
      <button class="btn btn-lg btn-primary btn-block" type="submit">
        Create Account
      </button>
       <router-link v-bind:to="{ name: 'login' }"><button>Have an Account?</button></router-link>&nbsp;&nbsp;
    </form>
    <h2 class="blurb">If you provide an email address, then you become a premium user!</h2><h2 class="blurb"> This allows you to add over 100 comics to each collection!</h2>
  </div>
</template>

<script>
import authService from '../services/AuthService';

export default {
  name: 'register',
  data() {
    return {
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        emailAddress: '',
        confirmEmailAddress: ''
      },
      registrationErrors: false,
      registrationErrorMsg: 'There were problems registering this user.'
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Password & Confirm Password do not match.';
      } /* else if (this.checkForInvalidEmail(this.emailAddress)) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Please enter a valid Email Address.';
      } */ else if (this.user.emailAddress != this.user.confirmEmailAddress) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Email Address & Confirm Email Address do not match.';
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: '/login',
                query: { registration: 'success' },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = 'Bad Request: Validation Errors';
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = 'There were problems registering this user.';
    },
    /* checkForInvalidEmail(emailAddress) {
      const mailFormat = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,24}))$/
      if (emailAddress.match(mailFormat))
      {
        return (false) //email is valid
      }
        return (true) //email is invalid
    } */
  },
};
</script>

<style>
div#register{
   display: grid;
  justify-items: center;
  
}
#registerButton{
  background-color:darkmagenta;
}
#loginButton{
  background-color:darkmagenta;
  margin-bottom: 20px;
}
form.form-register{
  background-color: rgb(59,59,95);
  width: 300px;
   height: 350px;
  display: grid;
 justify-items: center;
 border: 5px;
 border-style: groove;
 border-color: rgb(255, 230, 0);
 border-radius: 5%;
 margin-left: 200px;
 margin-top: 125px;

}
input{
  width: 15rem;
}
input#username.form-control{
  width: 15rem;
}
input#password.form-control{
  width: 15rem;
  margin-bottom: 0px;
}
input#confirmPassword{
  margin-bottom: 20px;
}
input#confirmEmailAddress{
  margin-bottom: 20px;
}
.blurb{
   margin-left: 200px;
   color: rgb(255, 230, 0);
}
</style>
