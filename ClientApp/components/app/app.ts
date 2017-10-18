import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
    components: {
           
        HomeComponent: require('../home/home.vue.html'),
        DashboardComponent: require('../dashboard/dashboard.vue.html'),
    }
})
export default class AppComponent extends Vue {
    mounted (){
       
    }
}
