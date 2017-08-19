
import Vue from 'vue';
import { Component, Watch } from 'vue-property-decorator';
import vSelect from 'vue-select';
import * as _ from 'lodash';


@Component
export default class DashboardComponent extends Vue {

  userProfile: any = {};
  linkList: any[] = [
    { icon: '<i class="material-icons md-24" aria-hidden="true">dashboard</i>', title: 'Dashboard', link: '/', active: true },
    { icon: '<i class="material-icons md-24" aria-hidden="true">local_mall</i>', title: 'My Purchases', link: '/vehicles', active: false },
    { icon: '<i class="material-icons md-24" aria-hidden="true">help</i>', title: 'Help', link: '/vehicles', active: false },
    { icon: '<i class="material-icons md-24" aria-hidden="true">directions_car</i>', title: 'Vehicles', link: '/vehicles', active: false },
    { icon: '<i class="material-icons md-24" aria-hidden="true">list</i>', title: 'Test Data', link: '/fetchdata', active: false },
    { icon: '<i class="material-icons md-24" aria-hidden="true">note_add</i>', title: 'Create Vehicle', link: '/vehicle/new', active: false },
    { icon: '<i class="material-icons md-24" aria-hidden="true">info</i>', title: 'About', link: '/vehicle/new', active: false },
  ];

  forAdmin: any[] = [
    { icon: '<i class="material-icons" aria-hidden="true">dashboard</i>', title: 'Departments', link: '/#', active: false },
    { icon: '<i class="material-icons" aria-hidden="true">people</i>', title: 'Employees', link: '/buildModel', active: false },
    { icon: '<i class="material-icons" aria-hidden="true">note_add</i>', title: 'Roles ', link: '/#', active: false }

  ];

  logo: string = 'VueJS .NET Core';


  windowHeight: number = 0;


  mounted() {
    this.$nextTick(function () {
      this.resizeSidebar();
      // window.addEventListener('resize', this.resizeSidebar);
      let profile = localStorage.getItem('profile');
      if (typeof profile !== 'undefined' && profile !== null)
        this.userProfile = JSON.parse(localStorage.getItem('profile'));

      this.changeActive(window.location.pathname);

    })
  }

  resizeSidebar() {
    this.windowHeight = this.$root.$el.offsetHeight > this.$el.offsetHeight ? this.$root.$el.offsetHeight + 10 : this.$el.offsetHeight;
  }


  changeActive(title) {

    this.linkList = _.map(this.linkList, link => {

      if (link.link == title) {

        link.active = true;
      }
      else {
        link.active = false;
      }

      this.resizeSidebar();

      return link;

    });
  }


  get sidebarSize() {
    return this.$root.$el.offsetHeight;
  }

  @Watch('sideSize')
  onSidebarSize(sidebarZise, oldval) { alert('red') }

}

