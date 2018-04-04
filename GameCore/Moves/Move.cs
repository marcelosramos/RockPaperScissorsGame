using System;
using GameCore.Interfaces;

namespace GameCore.Moves
{
    public class Move : IMove
    {
        private Types.MOVES _value;

        public Types.MOVES Value { get => _value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Possible values are "rock", "paper", and "scissors".</param>
        public Move(string value)
        {
            switch (value)
            {
                case "rock":
                    _value = Types.MOVES.Rock;
                    break;
                case "paper":
                    _value = Types.MOVES.Paper;
                    break;
                case "scissors":
                    _value = Types.MOVES.Scissors;
                    break;
                default:
                    throw new Exception("Invalid move value!");
            }
        }

        public Move(Types.MOVES value)
        {
            _value = value;
        }

        /// <summary>
        /// Check if the current move beats the move passed as parameter.
        /// </summary>
        /// <param name="_move">Move to be compared with</param>
        /// <returns>1 if it wins, 2 if it loses and 0 if there is a tide.</returns>
        public int Beats(IMove move)
        {
            if (Value == move.Value)
            {
                return 0;
            }
            else if (Value == Types.MOVES.Rock && move.Value == Types.MOVES.Scissors)
            {
                return 1;
            }
            else if (Value == Types.MOVES.Scissors && move.Value == Types.MOVES.Rock)
            {
                return 2;
            }
            else if (Value > move.Value)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        /// <summary>
        /// Check if the current move beats the move passed as parameter.
        /// </summary>
        /// <param name="_value">Move to be compared with. Possible values are "rock", "paper", and "scissors".</param>
        /// <returns>1 if it wins, 2 if it loses and 0 if there is a tide.</returns>
        public int Beats(string value)
        {
            IMove move = new Move(value);
            return Beats(move);
        }

        /// <summary>
        /// Check if the current move beats the move passed as parameter.
        /// </summary>
        /// <param name="_value">Move to be compared with</param>
        /// <returns>1 if it wins, 2 if it loses and 0 if there is a tide.</returns>
        public int Beats(Types.MOVES value)
        {
            IMove move = new Move(value);
            return Beats(move);
        }

    }
}
