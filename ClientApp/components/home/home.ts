import { Component } from 'vue-property-decorator';
import Vue from 'vue';
import axios from 'axios';


@Component
export default class MainDashboardComponent extends Vue {
    queryResult: any = {}

    mounted(){
        this.getAllVehicles();
    }

    
    getAllVehicles () {
        axios.get("api/dashboard").then(response => {
            this.queryResult = response.data
        })
        .catch(error => {});
    }
    
}
