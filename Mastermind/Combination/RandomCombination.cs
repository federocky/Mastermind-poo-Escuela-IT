using Mastermind.Utils;
using System;

namespace Mastermind
{
    class RandomCombination : Combination
    {

        public override void Make()
        {
            var usedNumber = new int[4];
            int randomNumber = 0;

            for (int i = 0; i < NUMBER_OF_COINS; i++)
            {
                do
                {
                    randomNumber = new Random().Next(0, Enum.GetNames(typeof(Color)).Length);

                } while (Array.Exists(usedNumber, x => x == randomNumber));
                    
                this.combination[i] = (Color) randomNumber;
                usedNumber[i] = randomNumber;
            }
        }

        public Color[] GetHideCombination()
        {
            return this.combination;
        }

        public override void Print()
        {
            var result = "";

            for (int i = 0; i < combination.Length; i++)
            {                
                    result += "X";                
            }

            Console.WriteLine(result);
        }

        public void PrintDiscover()
        {
            var result = "";

            for (int i = 0; i < combination.Length; i++)
            {                
                result += combination[i].ToString() + " - ";
            }

            Console.WriteLine(result);
        }
    }
}
