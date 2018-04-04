using System;
using GameCore.Interfaces;

namespace GameCore.Players
{
    public class HumanPlayer : IHumanPlayer
    {
        private string _id;

        public string Id { get => _id; }
        public Types.PLAYER_TYPES Type { get => Types.PLAYER_TYPES.Human; }
        public bool AutoPlay { get => false; }

        public HumanPlayer()
        {
            _id = Guid.NewGuid().ToString();
        }

        public HumanPlayer(string id)
        {
            _id = id;
        }


    }
}
