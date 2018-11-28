import Vue from 'vue';
import Notify from './components/Notify.vue';
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.use(BootstrapVue);

let v = new Vue({
    el: "#app",
    template: `
        <div>
            <h1>Notify Service</h1>
            <Notify />
        </div>
    `,
    components: {
        Notify,
    }
});