<script setup lang="ts">
    import KnightFormList from './components/KnightFormList.vue'
</script>

<template>
  <!--<header style="border: 1px solid blue">-->
    <!--<img alt="Vue logo" class="logo" src="./assets/logo.svg" width="125" height="125" />-->

    <!--<div class="wrapper">
      <HelloWorld msg="You did it!" />
    </div>-->
  <!--</header>-->

  <main style="border: 1px solid black; width:auto">
      <!--<TheWelcome />-->
      <knight-form-list></knight-form-list>
  </main>
</template>

<style scoped>
header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

/*  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }*/
}
</style>
