import { eventBroadcaster } from './../../globals';
import { auth0 } from 'auth0-js';
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import * as _ from 'lodash';
import * as $ from 'jquery';
import * as globals from '../../globals';




@Component
export default class HeaderComponent extends Vue {

  @Prop({})
  auth: any;

  @Prop({})
  authenticated: boolean;

  userProfile: any = {};

  themes: any[] = [
    { color: '#35475e', name: 'Default'},
    { color: '#9b37ff', name: 'Purple'},
    { color: '#00b900', name: 'Green'},
    { color: '#ff1717', name: 'Red'},
    { color: '#0079f2', name: 'Blue'},
    { color: '#c7c7c7', name: 'Light Grey'}
  ]
  
  themeColor: string = '#35475e';

  mounted() {
    
    let profile = localStorage.getItem('profile');
    if (typeof profile !== 'undefined' && profile !== null)
      this.userProfile = JSON.parse(profile);

  }

  setTheme(theme)
  {
    this.themeColor = theme;
    globals.eventBroadcaster.$emit('themeChanged', theme)
  }



}

