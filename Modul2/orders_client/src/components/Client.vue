

<template>
  <div>
  <table id="app" class="display table" width="100%">
  <tbody>
    <tr v-for="item of items" :key="item.id">
      <td> {{ item }}</td>
    </tr>
  </tbody>
</table>
  <ul v-if="items && items.length">
    <li v-for="item of items" :key="item.id">
      <p><strong>{{item.name}}</strong></p>
      <p>{{item.prize}}</p>
    </li>
  </ul>

  <ul v-if="errors && errors.length" >
    <li v-for="error of errors" :key="error.message">
      {{error.message}}
    </li>
  </ul>
  </div>
</template>

<script>
import axios from 'axios';
export default {
  data() {
    return {
      items: [],
      errors: []
    }
  },

  created() {
    axios.get(`https://apiorders.azurewebsites.net/api/items`)
    .then(response => {
      this.items = response.data
    })
    .catch(e => {
      this.errors.push(e)
    })
   
  }
}

</script>

<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
