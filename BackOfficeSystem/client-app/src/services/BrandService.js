import axios from 'axios'
import apiMixins from '../mixins/ApiMixins.js'

var constants = new apiMixins();

class BrandService {
    async createBrand(name, res, err) {
        let data = {
            name: name
        }

        axios
            .post(constants.BRAND_ROUTE, data)
            .then(res)
            .catch(err)
    }
}
  
export default BrandService