import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'

import BootstrapVue from 'bootstrap-vue'

import routes from './routes'
import store from './store'

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.use(BootstrapVue)
Vue.use(VueRouter)

var router = new VueRouter({
  routes: routes,
  mode: "history"
})

Vue.config.productionTip = false

new Vue({
  store,
  router: router,
  render: h => h(App),
}).$mount('#app')
