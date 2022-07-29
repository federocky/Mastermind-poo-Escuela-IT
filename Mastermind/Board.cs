using System;

namespace Mastermind
{
    class Board
    {
        private RandomCombination hideCombination;
        private MadeCombination[] tries;
        private int currentTry;
        private const int NUMBER_OF_TRIES = 10;

        public Board()
        {
            this.tries = new MadeCombination[NUMBER_OF_TRIES];
            for (int i = 0; i < tries.Length; i++)
            {
                tries[i] = new MadeCombination();
            }
            this.hideCombination = new RandomCombination();
            this.hideCombination.Make();
            this.currentTry = 0;
        }

        public void showResult()
        {
            if (this.tries[this.currentTry - 1].hasWon()) Console.WriteLine("Congratulations! you guess all colors and positions. YOU WIN ");
            if (this.currentTry == NUMBER_OF_TRIES) Console.WriteLine("You do not have more turns. YOU LOOSE :(");
        }

        public void MakePattern()
        {
            tries[this.currentTry].Make();
        }

        public void ChangeTurn()
        {
            this.currentTry++;
        }

        public bool GameFinished()
        {
            if (this.tries[this.currentTry-1].hasWon()) return true;
            if (this.currentTry == NUMBER_OF_TRIES) return true;
            return false;
        }

        public string GetRandomCombination()
        {
            return this.hideCombination.GetCombination();
        }

        public string GetTries()
        {
            var result = "";
            foreach (var combination in tries)
            {
                result += combination.GetCombination();
                result += combination.GetCorrection();
            }
            return result;
        }

        public void CheckCombination()
        {
            this.tries[this.currentTry].Check(hideCombination);
        }
    }
}