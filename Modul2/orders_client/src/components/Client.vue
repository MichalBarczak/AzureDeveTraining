

<template>
<div class="d-flex justify-content-center">
  <div class="col-md-2">
    <table class="table text-center table-striped table-responsive table-dark">
            <thead>
                <tr>
                    <th>#</th>
                    <th>Name</th>
                    <th>Prize</th>
                  </tr>
            </thead>
            <tbody>
                <tr v-for="item of items" :key="item.id">
                    <td>{{ item.id }}</td>
                    <td>{{ item.name }}</td>
                    <td>{{ item.prize }}</td>               
                </tr>
            </tbody>
        </table>
  

  <ul v-if="errors && errors.length" >
    <li v-for="error of errors" :key="error.message">
      {{error.message}}
    </li>
  </ul>
  </div>
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
