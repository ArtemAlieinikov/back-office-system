<template>
  <div class="common-block">
    <div>
        <h3>Create new brand</h3>
    </div>
    <b-form @submit="onSubmit" @reset="onReset" v-if="show">
      <b-form-group id="input-group-2" label="Brand name:">
        <b-form-input
          id="input-2"
          v-model="form.brandName"
          required
          placeholder="Brand name"
        ></b-form-input>
      </b-form-group>
      <b-button type="submit" variant="light">Create</b-button>
      <b-button type="reset" variant="light">Reset</b-button>
    </b-form>
    <div v-if="createOperationResultMessage" class="common-block">Creation message: {{ createOperationResultMessage }}</div>
  </div>
</template>

<script>
export default {
    name: 'CreateBrandComponent',
    data() {
      return {
        form: {
          brandName: '',
        },
        show: true,
      }
    },
    computed: {
        createOperationResultMessage() {
            if (this.$store.state.brandCreationStatus.response?.data) {
                return this.$store.state.brandCreationStatus.response.data
            }
            else if (this.$store.state.brandCreationStatus?.status == 204) {
                return `Brand "${this.form.brandName}" was created`
            }

            return ""
        }
    },
    methods: {
      onSubmit(evt) {
        evt.preventDefault()
        this.$store.dispatch("CreateBrand", this.form.brandName)
      },
      onReset(evt) {
        evt.preventDefault()
        this.form.brandName = ''
        this.$store.dispatch("ResetBrandCreationStatus");
        // Trick to reset/clear native browser form validation state
        this.show = false
        this.$nextTick(() => {
          this.show = true
        })
      }
    },
    beforeMount() {
        this.$store.dispatch("ResetBrandCreationStatus");
    }
}
</script>

<style scoped>
</style>
