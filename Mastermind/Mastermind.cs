using System;

namespace Mastermind
{
    class Mastermind
    {
        private Game game;

        public Mastermind()
        {
            this.game = new Game();
        }

        private void play()
        {
            do
            {
                this.game.Play();
            } while (this.isResumed());
        }

        private bool isResumed()
        {
            String answer;
            do
            {
                Console.WriteLine("¿Quieres continuar? (s/n): ");
                answer = Console.ReadLine();
            } while (!String.Equals(answer, "s", StringComparison.OrdinalIgnoreCase) && !String.Equals(answer, "n", StringComparison.OrdinalIgnoreCase));
            return String.Equals(answer, "s", StringComparison.OrdinalIgnoreCase);
        }

        public static void Main(String[] args)
        {
            new Mastermind().play();
        }

    }
}
