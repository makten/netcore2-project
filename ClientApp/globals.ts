'use strict';
import Vue from 'vue';
import AuthService from './services/AuthService';

export const eventBroadcaster = new Vue();
export const home = '/';
// export const auth = new AuthService();



const  authObj = new AuthService();


export const  { login, logout, authenticated, authNotifier } = authObj;

export const auth = authObj;