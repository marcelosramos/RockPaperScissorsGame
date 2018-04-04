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

        public enum MOVE_TYPES { Default };

        
    }
}
