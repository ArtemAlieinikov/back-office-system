import axios from 'axios'
import apiMixins from '../mixins/ApiMixins.js'

var constants = new apiMixins();

class InventoryService {
    async getInventorySummary(res, err) {
        axios
            .get(constants.INVENTORY_SUMMARY_ROUTE)
            .then(res)
            .catch(err)
    }
}
  
export default InventoryService