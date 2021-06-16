using System;

namespace RockPaperScissorsV1
{
    partial class Program
    {
        static void Main(string[] args)
        {

            int i = 9;
            double x = i;
            Console.WriteLine(x);
            // Create new Rock Paper Scissors game
            RpsGame currentGame = new RpsGame();

            // Start the RPS game
            currentGame.StartGame();
            //currentGame.testMethod

        }

    }
}
