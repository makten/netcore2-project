import { relativeDate, formatDuration, formatDate } from './../../core/helper-util';
// import weather from './../../services/weather-service';
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import * as _ from 'lodash';
import axios from 'axios';
import moment from 'moment';


@Component({
    methods: {
        relativeDate,
        formatDuration,
        formatDate
    }, 
    props: {
        weatherCity: {
            type: String,
        },
        dateFormat: {
            type: String,
            default: 'DD-MM-YYYY',
        },
        timeFormat: {
            type: String,
            default: 'HH:mm',
        },
        timeZone: {
            type: String,
        }
    },
})

@Component
export default class WeatherComponent extends Vue {
   
    date: string = "";
    time: string = "";
    weather: any = { temperature: '', iconClass: '' };


    environments: any[] = [];

    // created() {

    //     this.refreshTime();
    //     setInterval(this.refreshTime, 1000);

    //     this.fetchWeather();
    //     setInterval(this.fetchWeather, 15 * 60 * 1000);

    // }

    // refreshTime() {
    //     this.date = moment().tz(this.timeZone).format(this.dateFormat);
    //     this.time = moment().tz(this.timeZone).format(this.timeFormat);
    // }

    // async fetchWeather() {
    //     const conditions = await weather.conditions(this.weatherCity);

    //     this.weather.temperature = conditions.temp;
    //     this.weather.iconClass = `wi-yahoo-${conditions.code}`;
    // }


    // getEnvironments() {
    //     axios.get('/api/environments').then(response => {
    //         this.environments = response.data;
    //     }).catch(err => { })
    // }

}
