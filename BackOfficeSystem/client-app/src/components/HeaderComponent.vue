<template>
    <div class="common-block">
        <b-nav tabs align="center">
            <b-nav-item>
                <router-link to="/">
                    <span>Home</span>
                </router-link>
            </b-nav-item>
            <b-nav-item>
                <router-link to="/summary">
                    <span>Summary</span>
                </router-link>
            </b-nav-item>
            <b-nav-item>        
                <router-link to="/create-brand">
                    <span>Create new brand</span>
                </router-link>
            </b-nav-item>
        </b-nav>
    </div>
</template>

<script>
export default {
  name: 'HeaderComponent',
  props: { },
  methods: { }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
