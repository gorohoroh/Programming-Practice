<template>
  <div>
    <p>Completed tasks: {{ todos.filter(todo => todo.done).length }}</p>
    <p>Pending tasks: {{ todos.filter(todo => !todo.done).length }}</p>

    <todo v-for="todo in todos" v-bind:todo="todo"></todo>

  </div>
</template>

<script type="text/javascript">

import Todo from "./Todo";

export default {
  props: ['todos'],
  components: {Todo}
};
</script>

