import { Component, Prop } from 'vue-property-decorator';
import Vue from 'vue';
import axios from 'axios';
import * as globals from '../../globals';
import VueSpotify from 'vue-spotify';
import Spotify from './../../services/spotify-service';
import { HubConnection } from '@aspnet/signalr-client';

interface SpotifyUser { }
interface Player { }
interface CurrentlyPlaying { }

@Component({
})

export default class SpotifyComponent extends Vue {
    spotifyUser: any = { country: '', display_Name: '', email: '', href: '', id: '', images: [], product: '', type: '', uri: '' };
    player: any = {};
    currentlyPlaying: any = {
        is_playing: false,
        item: {
            duration: 0, name: '', album: {
                images: [], name: '',
            }, artists: []
        },
        progress_ms: 0, timestamp: 0,
    };
    authURL: string = "";
    serverMessage: string = "";

    mounted() {

        const conn = new HubConnection('http://localhost:9000/PlayerUpdate');
        let vm = this;
        conn.on('PlayerUpdate', (data) => {
            vm.serverMessage += "\n" + data;
        })

        conn.start()
            .then(() => console.log("Connected To PlayerHub"));

        this.authURL = Spotify.authrizeUrl

        if(this.authURL != null){
            this.fetchSpotifyUser();
            this.fetchPlayer();
            this.fetchCurrentlyPlaying();
        }

    }


    async fetchSpotifyUser() {
        const query = `spotifyuser`;
        this.spotifyUser = await Spotify.spotifyUser(query);
    }

    async fetchPlayer() {
        const query = `player`;
        this.player = await Spotify.player(query);
    }

    async fetchCurrentlyPlaying() {
        const query = `currentlyplaying`;
        this.currentlyPlaying = await Spotify.currentlyPlaying(query);
    }

    get classObject() {
        return "gooood";
      }

}