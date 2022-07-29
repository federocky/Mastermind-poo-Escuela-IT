using System;

namespace Mastermind
{
    class Menu
    {
        public Menu()
        {
        }

        internal void Show(Board board)
        {
            Console.WriteLine($"Goal: {board.GetRandomCombination()}");
            Console.WriteLine($"Current: {board.GetTries()}");
            Console.WriteLine("Give it a try: red, blue, yellow, green, purple, orange, black");
        }
    }
}