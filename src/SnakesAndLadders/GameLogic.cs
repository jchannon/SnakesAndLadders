using System;

namespace SnakesAndLadders
{
    using System.Collections.Generic;

    public class GameLogic
    {
        private static readonly Random Dice = new Random();

        private Dictionary<int, int> Snakes = new Dictionary<int, int>();

        private Dictionary<int, int> Ladders = new Dictionary<int, int>();

        public int TokenPosition { get; private set; }

        public bool GameWon { get; set; }

        public void Start()
        {
            this.TokenPosition = 1;
        }

        public void SetupSnakes()
        {
            this.Snakes.Add(12, 2);
        }

        public void SetupLadders()
        {
            this.Ladders.Add(2, 12);
        }

        public void MoveToken(int number)
        {
            this.TokenPosition += number;

            if (this.TokenPosition > 100)
            {
                this.TokenPosition -= number;
            }

            if (this.Snakes.ContainsKey(this.TokenPosition))
            {
                this.TokenPosition = this.Snakes[this.TokenPosition];
            }
            
            if (this.Ladders.ContainsKey(this.TokenPosition))
            {
                this.TokenPosition = this.Ladders[this.TokenPosition];
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
