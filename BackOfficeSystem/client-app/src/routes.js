import CreateBrandComponent from './components/CreateBrandComponent.vue'
import InventorySummaryComponent from './components/InventorySummaryComponent.vue'
import StartPageComponent from './components/StartPageComponent.vue'

const routes = [
    { path: '/summary', component: InventorySummaryComponent }, 
    { path: '/create-brand', component: CreateBrandComponent }, 
    { path: '/', component: StartPageComponent }
  ]
  
export default routes