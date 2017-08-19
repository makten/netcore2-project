import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
import VeeValidate from 'vee-validate';


Vue.use(VueRouter);
Vue.use(VeeValidate);


const routes = [
    { path: '/', component: require('./components/home/home.vue.html') },
    { path: '/home', component: require('./components/home/home.vue.html') },
    { path: '/callback', name: 'Callback', component: require('./services/authentication/callback.vue.html') },
    { path: '/counter', component: require('./components/counter/counter.vue.html') },
    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html') },
    { path: '/vehicle/new', component: require('./components/vehicle-form/vehicle-form.vue.html') },
    { path: '/vehicles', component: require('./components/vehicle/vehicle.vue.html') },
    { name: 'vehicle', path: '/vehicles/:vehicleId', component: require('./components/vehicle/vehicle.vue.html') },
    { path: '/user/settings', component: require('./components/user/settings.vue.html') },
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    mounted() { },
    render: (h: any) => h(require('./components/app/app.vue.html'))
});





