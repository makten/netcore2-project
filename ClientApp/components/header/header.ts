import { auth0 } from 'auth0-js';
import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import * as _ from 'lodash';
import * as $ from 'jquery';




@Component
export default class HeaderComponent extends Vue {

  @Prop({})
  auth: any;

  @Prop({})
  authenticated: boolean;

  userProfile: any = {};

  mounted() {
    
    let profile = localStorage.getItem('profile');
    if (typeof profile !== 'undefined' && profile !== null)
      this.userProfile = JSON.parse(profile);

  }



}

