import Vue from 'vue';
import axios from 'axios';
import App from './App.vue';

Vue.config.productionTip = false;

let ROOT_URL = process.env.API_URL || 'http://matchmanagerapi.azurewebsites.net';
ROOT_URL = 'http://localhost:49445';
const API_URL = `${ROOT_URL}/api`;
const NEW_PLAYER_URL = `${API_URL}/player`;
const GET_PLAYER_TYPES_URL = `${API_URL}/player`;
const NEW_MATCH_URL = `${API_URL}/match`;
const GET_MOVES_URL = `${API_URL}/moves`;
const HUB_URL = `${ROOT_URL}/match`;

Vue.prototype.$http = axios
Vue.prototype.$ROOT_URL = ROOT_URL;
Vue.prototype.$API_URL = API_URL;
Vue.prototype.$NEW_PLAYER_URL = NEW_PLAYER_URL;
Vue.prototype.$GET_PLAYER_TYPES_URL = GET_PLAYER_TYPES_URL;
Vue.prototype.$NEW_MATCH_URL = NEW_MATCH_URL;
Vue.prototype.$GET_MOVES_URL = GET_MOVES_URL;
Vue.prototype.$HUB_URL = HUB_URL;

new Vue({
  render: h => h(App)
}).$mount('#app')
