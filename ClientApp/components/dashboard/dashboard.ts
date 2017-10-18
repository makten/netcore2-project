// import { auth } from './../../globals';
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import vSelect from 'vue-select';
import * as _ from 'lodash';
import axios from 'axios';
import * as globals from '../../globals';


@Component
export default class DashboardComponent extends Vue {    

    queryResult: any = {}
    
        @Prop()
        rows: number;
        @Prop()
        columns: number;
    
        mounted() {
    
            // this.getAllVehicles();
        }
    
    
        getAllVehicles() {
    
            axios.get("api/dashboard").then(response => {
                    this.queryResult = response.data
                })
                .catch(error => {});
        }
    
        get gridTemplate() {
            return `grid-template: repeat(${this.rows}, 1fr) / repeat(${this.columns}, 1fr);`;
        }
    

}
