import { formatDate } from './../../core/helper-util';
// import { auth } from './../../globals';
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import vSelect from 'vue-select';
import * as _ from 'lodash';
import axios from 'axios';
import * as globals from '../../globals';
import Form from '../../core/Form';

Vue.component('vSelect', vSelect)

@Component
export default class DashboardComponent extends Vue {

    queryResult: any = {}
    user: any = { firstName: 'Hafiz', lastName: 'Abass', id: 2, avatar: '', teamId: 1 }


    newTODO: any = new Form({ title: '', sprintCode: '', description: '', goalStart: '', goalEnd: '', done: false, teamMemberId: '' });
    newEnvironment: any = new Form({ clientGroupId: '', clientgroup: null, name: '', description: '', extraDetails: '' });
    storyCodes: any[] = [
        "FRC-67121",
        "FRC-37677",
        "FRC-67885",
        "FRC-435343",
    ];
    selectedCode: string = "";

    todoList: any = [];

    environments: any = [];

    clients: any[] = [];
    selectClient: any = {};

    @Prop()
    rows: number;
    @Prop()
    columns: number;

    mounted() {

        this.getGoals();
        this.getClients();
        this.getEnvironments();
    }

    getGoals() {
        axios.get(`api/goals/${this.user.id}`).then(resp => {
            this.todoList = resp.data;
        }).catch(err => { })
    }

    getClients() {
        axios.get('api/clientgroups').then(resp => {
            this.clients = resp.data;
        }).catch(err => { })
    }

    getEnvironments() {
        axios.get('api/environments').then(resp => {
            this.environments = resp.data;
        }).catch(err => { })
    }


    addNewToDo() {

        if (this.newTODO.title != "" && this.selectedCode != "") {

            this.newTODO.teamMemberId = this.user.id;
            this.newTODO.sprintCode = this.selectedCode;

            axios.post('/api/goals', this.newTODO).then(resp => {
                console.log(resp.data)
                this.todoList.push(resp.data)
                this.clearInputs();
            }).catch(err => { console.log(err) })

        }
    }

    addEnvironment() {

        if (this.newEnvironment.name != '' && this.newEnvironment.code != '' && this.newEnvironment.clientgroup.id != '') {

            this.newEnvironment.clientGroupId = this.newEnvironment.clientgroup.id

            axios.post('/api/environments', this.newEnvironment).then(resp => {
                console.log(resp.data)
                this.environments.push(resp.data)
                this.clearInputs();
            }).catch(err => { console.log(err) })

        }
    }

    clearInputs() {
        this.newEnvironment = { clientGroupId: '', clientgroup: null, name: '', description: '', extraDetails: '' };
        this.newTODO = { title: '', sprintCode: '', description: '', goalStart: '', goalEnd: '', done: false, teamMemberId: '' }
    }

    removeTodo(index, item) {

        axios.delete(`/api/goals/${item.id}`).then(resp => {
            this.todoList.splice(index, 1)
        }).catch(err => { })
        // this.todoList = _.reject(this.todoList, (i) => { return i.name == item.name })
    }

    removeEnvironment(index, item) {

        axios.delete(`/api/environments/${item.id}`).then(resp => {
            this.environments.splice(index, 1)
        }).catch(err => { })
    }


}
