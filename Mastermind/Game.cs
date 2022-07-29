using System;

namespace Mastermind
{
    class Game
    {
        private RandomCombination hideCombination;
        private MadeCombination[] attemptCombination;
        private int currentTry;
        private const int NUMBER_OF_TRIES = 10;

        public Game()
        {
            this.attemptCombination = new MadeCombination[NUMBER_OF_TRIES];
            for (int i = 0; i < attemptCombination.Length; i++)
            {
                attemptCombination[i] = new MadeCombination();
            }
            this.hideCombination = new RandomCombination();
            this.hideCombination.Make();
            this.currentTry = 0;
        }

        internal void Play()
        {
            do
            {
                this.ShowMenu();
                attemptCombination[this.currentTry].Make();
                this.attemptCombination[this.currentTry].Check(hideCombination);
                this.currentTry++;

            } while (!this.GameFinished());

            this.ShowResult();
        }

        private void ShowMenu()
        {
            this.hideCombination.Print();
            foreach (var combination in attemptCombination)
            {
                combination.Print();
            }
            Console.WriteLine("Give it a try: red, blue, yellow, green, purple, orange, black");
        }

        private bool GameFinished()
        {
            if (this.attemptCombination[this.currentTry-1].HasWon()) return true;
            if (this.currentTry == NUMBER_OF_TRIES) return true;
            return false;
        }

        private void ShowResult()
        {
            if (this.attemptCombination[this.currentTry - 1].HasWon()) Console.WriteLine($"Congratulations! you guess all colors and positions. YOU WIN \n Secret: ");
            if (this.currentTry == NUMBER_OF_TRIES) Console.WriteLine("You do not have more turns. YOU LOOSE :( \n Secret: ");
            this.hideCombination.PrintDiscover();
        }        

    }
}