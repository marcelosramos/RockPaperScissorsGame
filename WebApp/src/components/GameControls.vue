<template>
  <div>
    <h2>Game Controls</h2>
    <div 
      v-if="complete && connectionReady && waitingPlayer !== playerId" 
      class="control-buttons"
      v-for="move in moves" 
      :key="move.intValue" 
    >
      <button v-on:click="onMove(move.value)">
        {{ move.name }}
      </Button>
      &nbsp;<small>Beats: {{ move.beats }}</small>
    </div>
    <p v-if="waitingPlayer === playerId">Waiting for opponent's move...</p>
  </div>
</template>

<script>
const signalR = require("@aspnet/signalr");

export default {
  name: "GameControls",
  data(){
    return {
      connectionReady: false
    }
  },
  props: {
    matchId: String,
    playerId: String,
    moves: Array,
    waitingPlayer: String,
    complete: Boolean
  },
  created(){
    this.connection = new signalR.HubConnection(this.$HUB_URL);
    this.connection.start().then(this.connectionReady=true);
  },
  methods: {
    onMove(value) {
      this.connection.send("NewMove", this.matchId, this.playerId, value);
    }
  }
};
</script>

<style scoped>
div.control-buttons {
  display: block;
}
div.control-buttons button {
  margin-bottom: 5px;
}
</style>

