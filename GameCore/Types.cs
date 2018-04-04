using System.Collections.Generic;

namespace GameCore
{
    public class Types
    {
        public enum PLAYER_TYPES { Human, Random, Tactic };
        public struct PLAYER_TYPE
        {
            public string name;
            public string value;
            public int intValue;
            public bool autoPlay;
        }
        
        public static List<PLAYER_TYPE> GetPlayerTypes()
        {
            List<PLAYER_TYPE> playerTypes = new List<PLAYER_TYPE>();

            PLAYER_TYPE human;
            human.name = "Human";
            human.value = "human";
            human.intValue = (int)PLAYER_TYPES.Human;
            human.autoPlay = false;
            playerTypes.Add(human);

            PLAYER_TYPE random;
            random.name = "Computer (random)";
            random.value = "random";
            random.intValue = (int)PLAYER_TYPES.Random;
            random.autoPlay = true;
            playerTypes.Add(random);

            PLAYER_TYPE tactic;
            tactic.name = "Computer (tactic)";
            tactic.value = "tactic";
            tactic.intValue = (int)PLAYER_TYPES.Tactic;
            tactic.autoPlay = true;
            playerTypes.Add(tactic);

            return playerTypes;
        }

        public enum MOVES { Rock, Paper, Scissors };
        public struct MOVE
        {
            public string name;
            public string value;
            public int intValue;
            public string beats;
        }



        /// <summary>
        /// Exports the possible moves and its descriptions in order to let other application layers
        /// know what those moves are
        /// </summary>
        /// <returns></returns>
        public static List<MOVE> GetAllowedMoves()
        {
            List<MOVE> allowedMoves = new List<MOVE>();

            MOVE rock;
            rock.name = "Rock";
            rock.value = "rock";
            rock.beats = "Scissors";
            rock.intValue = (int)MOVES.Rock;
            allowedMoves.Add(rock);

            MOVE paper;
            paper.name = "Paper";
            paper.value = "paper";
            paper.intValue = (int)MOVES.Paper;
            paper.beats = "Rock";
            allowedMoves.Add(paper);

            MOVE scissors;
            scissors.name = "Scissors";
            scissors.value = "scissors";
            scissors.intValue = (int)MOVES.Scissors;
            scissors.beats = "Paper";
            allowedMoves.Add(scissors);

            return allowedMoves;
        }
    }
}
