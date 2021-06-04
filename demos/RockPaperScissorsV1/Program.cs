using System;

namespace RockPaperScissorsV1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // Create new Rock Paper Scissors game
            RpsGame currentGame = new RpsGame();

            // Start the RPS game
            currentGame.startGame();
        }

    }
}
