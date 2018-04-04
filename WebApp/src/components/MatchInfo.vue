<template>
  <div v-bind:class="over && (winner === playerId ? 'win' : winner === opponentId ? 'lose' : 'tie')">
    <h2>Match: <small v-if="complete">(you) <strong>{{ scores[playerId] }}</strong> vs <strong>{{ scores[opponentId] }}</strong> (your opponent)</small></h2>
    <p v-if="complete">
      <strong>Match ID:</strong> {{ id }}<br />
      <strong>Your opponent ID:</strong> {{ opponentId }}<br />
      <table v-if="games && games.length>0">
        <tr>
          <th>Game</th>
          <th>You</th>
          <th>Opponent</th>
          <th>Result</th>
        </tr>
        <tr 
          v-for="(game, index) in games" 
          v-bind:key="index"
          v-bind:class="game.winner === playerId ? 'win' : game.winner === opponentId ? 'lose' : 'tie'">
          <td>{{ index + 1 }}</td>
          <td>
            {{ 
              game.player1.id === playerId 
                ? game.player1Move.move.name
                : game.player2Move.move.name 
            }}
          </td>
          <td>
            {{ 
              game.player1.id === opponentId 
                ? game.player1Move.move.name 
                : game.player2Move.move.name 
            }}
          </td>
          <td>
            <strong>
              {{
                game.winner === playerId 
                  ? 'WIN'
                  : game.winner === opponentId
                    ? 'LOSE'
                    : 'TIE'
              }}
            </strong>
          </td>
        </tr>
      </table>
    </p>
    <p v-else>
      Waiting for an opponent...
    </p>
    <h1 v-if="over">
      {{
        winner === playerId 
          ? 'WIN'
          : winner === opponentId
            ? 'LOSE'
            : 'TIE'
      }}
    </h1>
  </div>
</template>

<script>

export default {
  name: "MatchInfo",
  data() {
    return {
      opponentId: ""
    };
  },
  props: {
    id: String,
    player1: Object,
    player2: Object,
    scores: Object,
    games: Array,
    complete: Boolean,
    over: Boolean,
    winner: String,
    playerId: String,
    moves: Array
  },
  updated() {
    if (this.complete) {
      this.opponentId =
        this.playerId === this.player1.id ? this.player2.id : this.player1.id;
    }
  }
};
</script>

<style scoped>
table, tr {
  background-color: #fff; 
  border: 1px solid #666;
  margin: 0;
  text-align: center;
}
table {
  width: 100%;
  max-width: 400px;
}
.win {
  background-color: lightgreen;
}
.lose {
  background-color: lightcoral;
}
.tie {
  background-color: lightgoldenrodyellow;
}
</style>

