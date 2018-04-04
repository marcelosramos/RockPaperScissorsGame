using System;
using System.Collections.Generic;
using GameCore.Interfaces;

namespace GameCore.Moves
{
    public class DefaultMoves : IMoves
    {
        private MoveSet _move;

        public MoveSet Move { get => _move; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Possible values are "rock", "paper", and "scissors".</param>
        public void SetValue(string value)
        {
            _move = GetMove(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Possible values are 0,1 and 2.</param>
        public void SetValue(int value)
        {
            _move = GetMove(value);
        }
        /*
        public void SetValue(MoveTypes.MOVES value)
        {
            _value = value;
        }*/

        /// <summary>
        /// Check if the current move beats the move passed as parameter.
        /// </summary>
        /// <param name="move">Move to be compared with</param>
        /// <returns>1 if it wins, 2 if it loses and 0 if there is a tide.</returns>
        public int Beats(IMoves move)
        {
            if (Move == move.Move)
            {
                return 0;
            }
            else if (Move.Value == "rock" && move.Move.Value == "scissors")
            {
                return 1;
            }
            else if (Move.Value == "scissors" && move.Move.Value == "rock")
            {
                return 2;
            }
            else if (Move.IntValue > move.Move.IntValue)
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
            IMoves move = new DefaultMoves();
            move.SetValue(value);
            return Beats(move);
        }

        public MoveSet GetMove(int value)
        {
            MoveSet rock = new MoveSet
            {
                Name = "Rock",
                Value = "rock",
                Beats = "Scissors",
                IntValue = 0
            };
            MoveSet paper = new MoveSet
            {
                Name = "Paper",
                Value = "paper",
                IntValue = 1,
                Beats = "Rock"
            };
            MoveSet scissors = new MoveSet
            {
                Name = "Scissors",
                Value = "scissors",
                IntValue = 2,
                Beats = "Paper"
            };
            switch (value)
            {
                case 0:
                    return rock;
                case 1:
                    return paper;
                case 2:
                    return scissors;
                default:
                    return null;
            }
        }

        public MoveSet GetMove(string value)
        {
            int intValue;
            switch (value)
            {
                case "rock":
                    intValue = 0;
                    break;
                case "paper":
                    intValue = 1;
                    break;
                case "scissors":
                    intValue = 2;
                    break;
                default:
                    return null;
            }
            return GetMove(intValue);
        }

        /// <summary>
        /// Exports the possible moves and its descriptions in order to let other application layers
        /// know what those moves are
        /// </summary>
        /// <returns></returns>
        public List<MoveSet> GetAllowedMoves()
        {
            List<MoveSet> allowedMoves = new List<MoveSet> { GetMove(0), GetMove(1), GetMove(2) };
            return allowedMoves;
        }

    }
}
