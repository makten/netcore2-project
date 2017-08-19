import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import * as _ from 'lodash';
import axios from 'axios';


interface Vehicle {
    id: number;
    make: any;
    feature: any;
    isRegistered: boolean;
    contact: any;
    lastUpdate: string;

}

Vue.component('tabs', require('../../core/tabs/tabs.vue.html'))
Vue.component('tab', require('../../core/tabs/tab.vue.html'))

@Component
export default class VehicleComponent extends Vue {
    vehicle: any = {};
    vehicleId: number;
    showDetails: boolean = false;
    photos: any[] = [];    
    uploadProgress: number = null;

    mounted() {
        
        // auth.login();

        this.showDetails = false;
        this.getVehicle(this.$route.params.vehicleId);
        if (this.vehicleId != null || this.vehicleId != undefined)
            this.getPhotos()

    }


    getVehicle(vehicleId) {
        this.vehicleId = vehicleId;
        fetch(`/api/vehicles/${vehicleId}`)
            .then(response => response.json() as Promise<Vehicle[]>)
            .then(data => {
                this.vehicle = data;
                this.showDetails = !this.showDetails;
            });
    }


    getPhotos() {

        axios.get(`/api/vehicles/${this.vehicleId}/photos`)
            .then(response => {
                this.photos = response.data;
            })
            .catch(error => { })
    }

    gggg(ss){
        alert(ss);
    }


    processFile(e) {
        let files = e.target.files || e.dataTransfer.files;
        if (!files.length)
            return;

        let formData = new FormData();
        formData.append("file", files[0]);

        let vm = this;
        var config = {
            onUploadProgress: function (progressEvent) {
                var percentCompleted = Math.round((progressEvent.loaded * 100) / progressEvent.total);
                vm.uploadProgress = percentCompleted;                
            }
        };

        axios.post(`/api/vehicles/${this.vehicleId}/photos`, formData, config)
            .then(photo => {
                this.photos.push(photo.data)
                this.uploadProgress = null;
                e.target.value = '';
            })
            .catch(error => {                
                alert("File too big or invalid file type!");
            })

    }






}

