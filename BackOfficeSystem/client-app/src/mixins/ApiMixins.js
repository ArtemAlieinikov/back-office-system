const PORT = "60672"
const DOMAIN = "localhost"

class RouteConstants {
    BRAND_ROUTE = `http://${DOMAIN}:${PORT}/api/brands`
    INVENTORY_SUMMARY_ROUTE = `http://${DOMAIN}:${PORT}/api/inventories?agg=sum&column=quantity`
}

export default RouteConstants;