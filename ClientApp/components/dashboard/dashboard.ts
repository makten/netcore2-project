// import { auth } from './../../globals';
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import vSelect from 'vue-select';
import * as _ from 'lodash';
import * as globals from '../../globals';

@Component({
    components: {
        DashboardComponent: require('../dashboard/dashboard.vue.html'),
        HeaderComponent: require('../header/header.vue.html'),
        SidebarComponent: require('../sidebar/sidebar.vue.html'),
        FooterComponent: require('../footer/footer.vue.html'),
        // MenuComponent: require('../navmenu/navmenu.vue.html'),

    }
})

export default class DashboardComponent extends Vue {

    authenticated: boolean = globals.authenticated;
    auth: any = globals.auth;
    login: any = globals.login;
    logout: any = globals.logout;


    mounted() {        
        
        globals.eventBroadcaster.$on('changeRoute', (routeLink: any) => {
            this.$root.$router.push(routeLink)
        })

        globals.eventBroadcaster.$on('authChange', (authState: any) => {
            this.authenticated = authState.authenticated
        })
    }

}
