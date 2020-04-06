import Vue from 'vue'
import Vuex from 'vuex'

import InventoryService from './services/InventoryService'
import BrandService from './services/BrandService'

Vue.use(Vuex)

const store = new Vuex.Store({
    state: {
      inverntorySummary: {
        data: {},
        isLoadingInProgress: Boolean
      },
      brandCreationStatus: { }
    },
    mutations: {
      resetInventorySummaryLoadingState(state){
        this.state.inverntorySummary.isLoadingInProgress = true;
      },
      refreshInventorySummary(state, data) {
        this.state.inverntorySummary = {
          data: data,
          isLoadingInProgress: false
        }
      },
      refreshBrandCreationStatus(state, response) {
        this.state.brandCreationStatus = response
      },
      resetBrandCreationStatus(state) {
        this.state.brandCreationStatus = {}
      },
    },
    actions: {
      ResetBrandCreationStatus({ commit }) {
        commit('resetBrandCreationStatus')
      },
      async RefreshInventorySummary({ commit }) {
        commit('resetInventorySummaryLoadingState')
        var service = new InventoryService()
        await service.getInventorySummary(
          res => commit('refreshInventorySummary', res.data),
          err => console.log(err));
      },
      async CreateBrand({ commit }, brandName) {
        var service = new BrandService();
        await service.createBrand(
          brandName,
          res => commit('refreshBrandCreationStatus', res),
          err => commit('refreshBrandCreationStatus', err));
      }
    }
})

export default store