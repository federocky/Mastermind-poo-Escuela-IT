using Mastermind.Utils;

namespace Mastermind
{
    abstract class Combination
    {
        protected Color[] combination;

        protected int black = 0; //same color and position
        protected int white = 0; //same color

        protected const int NUMBER_OF_COINS = 4;

        public Combination()
        {
            this.combination = new Color[NUMBER_OF_COINS];
            for (int i = 0; i < combination.Length; i++)
            {
                combination[i] = Color.X;
            }
        }

        public abstract void Make();
        public abstract void Print();

        public bool HasWon()
        {
            return black == NUMBER_OF_COINS;
        }
    }
}