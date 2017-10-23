import { relativeDate, formatDuration, formatDate } from './../../core/helper-util';
import weather from './../../services/weather-service';
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import * as _ from 'lodash';
import axios from 'axios';
import * as moment from 'moment-timezone';


@Component({
    methods: {
        relativeDate,
        formatDuration,
        formatDate
    }

})

export default class WeatherComponent extends Vue {
    @Prop({type: String, default: 'DD/MM'})
    dateFormat;
    @Prop({ type: String, default: 'Europe/Amsterdam' })
    timeZone;
    @Prop({type: String, default: 'HH:mm:ss'})
    timeFormat: string;
    @Prop({ type: String })
    weatherCity: any;

    date = '';
    time = '';
    weather: any = {
        temperature: '',
        iconClass: '',
    }

    created() {

        alert(encodeURI("Stabilisatie-teststraat-ING"));
        
        this.refreshTime();
        setInterval(this.refreshTime, 1000);

        this.fetchWeather();
        setInterval(this.fetchWeather, 15 * 60 * 1000);

    }

    refreshTime() {
        this.date = moment().tz(this.timeZone).format(this.dateFormat);
        this.time = moment().tz(this.timeZone).format(this.timeFormat);
    }

    async fetchWeather() {
        const conditions = await weather.conditions(this.weatherCity);

        this.weather.temperature = conditions.temp;
        this.weather.iconClass = `wi-yahoo-${conditions.code}`;
    }


    getEnvironments() {
        axios.get('/api/environments').then(response => {
            // this.environments = response.data;
        }).catch(err => { })
    }

}
