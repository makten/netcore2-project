import { Component, Prop } from 'vue-property-decorator';
import Vue from 'vue';
import axios from 'axios';
import * as globals from '../../globals';


@Component({
    components: {
        memberComponent: require('../member/member.vue.html'),
        environmentComponent: require('../client-group/client-group.vue.html'),
        dashboardComponent: require('../dashboard/dashboard.vue.html'),
        weatherComponent: require('../weather/weather.vue.html'),
        jenkinsComponent: require('../jenkins/jenkins-stats.vue.html'),
        FooterComponent: require('../footer/footer.vue.html'),
        HomeComponent: require('../home/home.vue.html'),

    }
})

export default class MainDashboardComponent extends Vue {
    authenticated: boolean = globals.authenticated;
    auth: any = globals.auth;
    login: any = globals.login;
    logout: any = globals.logout;
    fullScreen: boolean = false;
    weatherCity: string = 'Deventer';



    mounted() {        
        
        globals.eventBroadcaster.$on('changeRoute', (routeLink: any) => {
            this.$root.$router.push(routeLink)
        })

        globals.eventBroadcaster.$on('authChange', (authState: any) => {
            this.authenticated = authState.authenticated
        })
    }
}