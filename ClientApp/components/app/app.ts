import Vue from 'vue';
import { Component } from 'vue-property-decorator';
// import 'bootstrap-material-design/dist/css/bootstrap-material-design.css';



@Component({
    components: {
           
        DashboardComponent: require('../dashboard/dashboard.vue.html'),
        // MenuComponent: require('../navmenu/navmenu.vue.html'),
    }
})
export default class AppComponent extends Vue {
    mounted (){
       
    }
}
