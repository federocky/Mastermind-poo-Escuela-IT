using Mastermind.Utils;
using System;

namespace Mastermind
{
    class MadeCombination : Combination
    {
        public override void Make()
        {
            var myEnum = Color.X;
            var usedColors = new Color[4];

            for (int i = 0; i < this.combination.Length; i++)
            {
                Console.WriteLine($"inserta el color: {i}");

                var validValue = false;
                do
                {
                    var inserted = Console.ReadLine();
                    Utils.Color.TryParse(inserted, out myEnum);

                    validValue = IsValidColor(myEnum, usedColors);
                    if (!validValue)
                    {
                        Console.WriteLine("Color no válido, intenta de nuevo");
                    }
                } while (!validValue);

                combination[i] = myEnum;
                usedColors[i] = myEnum;
            }
        }

        private bool IsValidColor(Color myEnum, Color[] usedColors)
        {            
            return !(myEnum == Color.X) && !Array.Exists(usedColors, x => x == myEnum) && Enum.IsDefined(typeof(Color), myEnum);
        }

        public void Check(RandomCombination targetCombination)
        {
            for (int i = 0; i < NUMBER_OF_COINS; i++)
            {
                for (int j = 0; j < NUMBER_OF_COINS; j++)
                {
                    if (this.combination[i] == targetCombination.GetHideCombination()[j])
                    {
                        if (i == j) this.black++;
                        else this.white++;
                    }
                }
            }
        }

        public override void Print()
        {
            var result = "";
            var showCorrection = combination[0] != Color.X;

            for (int i = 0; i < combination.Length; i++)
            { 
                    result += combination[i].ToString() + " - ";          
            }

            if (showCorrection) result +=  $"result: black: {this.black}, white: {this.white}";

            Console.WriteLine(result);
        }
    }
}