using System;

namespace SnakesAndLadders
{
    public class GameLogic
    {
        private static readonly Random Dice = new Random();

        public int TokenPosition { get; private set; }
        public bool GameWon { get; set; }

        public void Start()
        {
            this.TokenPosition = 1;
        }

        public void MoveToken(int number)
        {
            this.TokenPosition += number;

            if (this.TokenPosition > 100)
            {
                this.TokenPosition -= number;
            }
            
            this.GameWon = this.TokenPosition == 100;
        }

        public int ThrowDice(int number = 0)
        {
            if (number > 0)
            {
                return number;
            }
            return this.TokenPosition >= 1 ? Dice.Next(1, 6) : 0;
        }
    }
}