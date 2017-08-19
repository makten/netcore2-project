import Vue from 'vue'
import { Component } from 'vue-property-decorator';
import Velocity from 'velocity-animate'


@Component
export default class NotificationComponent extends Vue {

    types: any = {
        info: { itemClass: 'alert-info', iconClass: 'fa fa-lg fa-info-circle' },
        error: { itemClass: 'alert-danger', iconClass: 'fa fa-lg fa-exclamation-triangle' },
        warning: { itemClass: 'alert-warning', iconClass: 'fa fa-lg fa-exclamation-circle' },
        success: { itemClass: 'alert-success', iconClass: 'fa fa-lg fa-check-circle' }
    };

    options: any = {
        itemClass: 'alert col-12',
        duration: 500,
        visibility: 2000,
        position: 'top-left'
    };

    items: any = {}

    constructor (){
        super();
    }


    setTypes(types) {
        this.types = types
    }

    addItem(type, msg, options) {
        let itemOptions = Object.assign({}, { iconClass: this.types[type].iconClass, itemClass: [this.options.itemClass, this.types[type].itemClass], visibility: this.options.visibility }, options)
        // generate unique index
        let idx = new Date().getTime()
        // add it to the queue
        Vue.set(this.items, idx, { type: type, text: msg, options: itemOptions })
        // remove item from array
        setTimeout(() => { this.removeItem(idx) }, this.options.duration + itemOptions.visibility)
    }

    slideDown(el) {
        Velocity(el, 'slideDown', { duration: this.options.duration })
    }

    slideUp(el, done) {
        Velocity(el, 'slideUp', { duration: this.options.duration, complete: done })
    }

    removeItem(index) {
        Vue.delete(this.items, index)
    }

}
