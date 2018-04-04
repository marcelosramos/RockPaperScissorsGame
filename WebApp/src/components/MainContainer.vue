<template>
  <div>
    <h2>Player ID: {{ playerId }}</h2>
    <strong>Choose an opponent type:</strong>
    <div class="radio-button-group">
      <div class="radio-button-container" v-for="playerType in playerTypes" :key="playerType.intValue">
        <input type="radio" :id="playerType.intValue" :value="playerType.value" v-model="opponentType">
        <label :for="playerType.intValue">{{ playerType.name }}</label>
      </div>
    </div>
    <button class="btn-new-match" v-on:click="createNewMatch">NEW MATCH</button>
    <div v-if="match">
      <hr  />
      <MatchInfo v-bind="match" :playerId="playerId" :moves="moves" />
      <div v-if="match.complete && !match.over">
        <hr />
        <GameControls 
          :match-id="match.id" 
          :player-id="playerId" 
          :moves="moves" 
          :waitingPlayer="waitingPlayer"
        />
      </div>
    </div>
  </div>
</template>

<script>
const signalR = require("@aspnet/signalr");
import MatchInfo from "./MatchInfo.vue";
import GameControls from "./GameControls.vue";

export default {
  name: "MainContainer",
  components: {
    MatchInfo,
    GameControls
  },
  created() {
    this.connection = new signalR.HubConnection(this.$HUB_URL);
    this.$http
      .post(this.$NEW_PLAYER_URL)
      .then(({ data }) => (this.playerId = data.id));
    this.$http.get(this.$GET_MOVES_URL).then(({ data }) => (this.moves = data));
    this.$http
      .get(this.$GET_PLAYER_TYPES_URL)
      .then(({ data }) => (this.playerTypes = data));
  },
  data() {
    return {
      match: null,
      moves: [],
      playerId: "",
      waitingPlayer: "",
      playerTypes: [],
      opponentType: "human"
    };
  },
  methods: {
    createNewMatch() {
      this.connection.stop();
      this.$http
        .post(this.$NEW_MATCH_URL, {
          playerId: this.playerId,
          opponentType: this.opponentType
        })
        .then(({ data }) => {
          this.match = data;
          this.connection.on(data.id, (message, waitingPlayer) => {
            this.match = message;
            this.waitingPlayer = waitingPlayer;
          });
          this.connection.start().then(() => this.connection.send("NewMatch", data.id));
        });
    }
  }
};
</script>

<style scoped>
.radio-button-group {
  padding-left: 50px;
  margin-top: 5px;
  margin-bottom: 10px;
}
.radio-button-group,
.radio-button-container,
.btn-new-match {
  display: block;
}
</style>

