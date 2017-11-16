// import { auth } from './../../globals';
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import vSelect from 'vue-select';
import * as _ from 'lodash';
import axios from 'axios';
import * as globals from '../../globals';

Vue.component('vSelect', vSelect)

@Component
export default class DashboardComponent extends Vue {

    queryResult: any = {}

    newTODO: string = "";
    newEnvironment: string = "";
    storyCodes: any[] = [
        "FRC-67121",
        "FRC-37677",
        "FRC-67885",
        "FRC-435343",
    ];
    selectedCode: string = "";

    todoList: any = [
        { code: "FRC-67121", name: "Clear cache 2112", completed: false },
        { code: "FRC-37677", name: "Omtimize code 212", completed: false },
        { code: "FRC-67885", name: "Configure server", completed: false },
        { code: "FRC-435343", name: "Fix bug 123", completed: false },
    ];

    environments: any = [];

    clients: any[] = [];
    selectClient: string = '';

    @Prop()
    rows: number;
    @Prop()
    columns: number;

    mounted() {
        this.getClients();
    }


    getClients() {
        axios.get('api/clientgroups').then(resp => {
            this.clients = resp.data;
        }).catch(err => { })
    }


    addNewToDo() {

        if (this.newTODO != "") {
            let item = { code: this.selectedCode, name: this.newTODO, completed: false };
            this.todoList.push(item);
            this.newTODO = "";
        }
    }

    addEnvironment() {

        if (this.newEnvironment != "") {

            // let envs = JSON.parse(this.selectClient)
            console.log(this.selectClient)
            let item = { code: this.selectClient, name: this.newEnvironment, completed: false };
            this.environments.push(item);
            this.newEnvironment = "";
        }
    }

    removeTodo(index) {
        this.todoList.splice(index, 1)
        // this.todoList = _.reject(this.todoList, (i) => { return i.name == item.name })
    }

    removeEnvironment(index) {
        this.environments.splice(index, 1)
    }


}
