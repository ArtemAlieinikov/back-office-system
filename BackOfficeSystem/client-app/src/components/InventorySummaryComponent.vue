<template>
    <div class="common-block">
        <div>
            <h3>Inventory summary of brands</h3>
        </div>
        <div v-if="isLoading">
            <b-spinner type="grow" label="Loading..."></b-spinner>
        </div>
        <b-table v-else
            :items="inventorySummary"
            :fields="fields"
            :sort-by.sync="sortBy"
            :sort-desc.sync="sortDesc"
            responsive="sm"
        ></b-table>
    </div>
</template>

<script>
export default {
    name: 'InventorySummaryComponent',
    props: { },
    computed: {
        isLoading() {
            return this.$store.state.inverntorySummary.isLoadingInProgress
        },
        sortBy: {
            get() {
                return 'brandId'
            },
            set(newValue) {
            }
        },
        sortDesc: {
            get() {
                return false
            },
            set(newValue) {
            }
        },
        inventorySummary() {
            return this.$store.state.inverntorySummary.data
        },
        fields() {
            return [
                { key: 'brandId', sortable: true },
                { key: 'quantity', sortable: true },
                { key: 'brandName', sortable: true }
            ]
        }
    },
    beforeMount() {
        return this.$store.dispatch("RefreshInventorySummary")
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
