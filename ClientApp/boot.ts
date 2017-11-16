import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
import VeeValidate from 'vee-validate';
import * as globals from './globals';


Vue.use(VueRouter);
Vue.use(VeeValidate);

import moment from 'moment';

moment.updateLocale('en', {
    calendar: {
        lastDay: '[Yesterday]',
        sameDay: '[Today]',
        nextDay: '[Tomorrow]',
        lastWeek: '[last] dddd',
        nextWeek: 'dddd',
        sameElse: 'L',
    },
});

const routes = [
    { path: '/callback', component: require('./components/dashboard/dashboard.vue.html') },
    // { path: '/', component: require('./components/home/home.vue.html') },
    // { path: '/home', component: require('./components/home/home.vue.html') },
    // { path: '/callback', name: 'callback', redirect: to => {  return location.href = 'http://localhost:8080'} },
    // { path: '/counter', component: require('./components/counter/counter.vue.html') },
    // { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html') },
    // { path: '/vehicle/new', component: require('./components/vehicle-form/vehicle-form.vue.html') },
    // { path: '/vehicles', component: require('./components/vehicle/vehicle.vue.html') },
    // { name: 'vehicle', path: '/vehicles/:vehicleId', component: require('./components/vehicle/vehicle.vue.html') },
    // { path: '/user/settings', component: require('./components/user/settings.vue.html') },
];

new Vue({
    el: '#dashboard-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    mounted() {

        // window.onbeforeunload = () => {return false;}
    },
    render: (h: any) => h(require('./components/dashboard-components/dashboard-components.vue.html'))
});