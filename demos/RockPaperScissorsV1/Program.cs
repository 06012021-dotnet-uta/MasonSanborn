using System;

namespace RockPaperScissorsV1
{
    class Program
    {
        public enum RpsChoice {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }
        static void Main(string[] args)
        {
            string playerName = "Default";
            string agentName = "Computer";
            int  playerScore = 0;
            int  agentScore  = 0;
            bool succesfulConversion = false;
            int playerChoiceInt = 0;
            int agentChoiceInt  = 0;
            string playAgain;

            GameIntro();

            Console.Write("Please enter your name: ");
            playerName = Console.ReadLine();


            while(true) {
                // get proper user input
                do {
                    //Console.WriteLine($"\nCurrent Score: {playerName} = {playerScore}, {agentName} = {agentScore}");
                    Console.WriteLine("Please make your choise: ");
                    Console.WriteLine("1\t:\tRock\n2\t:\tPaper\n3\t:\tScissors\n");
                    string playerChoice = Console.ReadLine();

                    // create an int variable to catch the converted choice
                    // try to convert the user choice to int, if succesful it will output the result as true and set the value
                    // to playerChoiceInt. If false it will not do anything
                    succesfulConversion = Int32.TryParse(playerChoice, out playerChoiceInt);

                    // checks to see that the user entered a number and that the number is in range
                    // if invalid input succesfulConversion is false
                    if(succesfulConversion != true || playerChoiceInt < 1 || playerChoiceInt > 3) {
                        Console.WriteLine("\nInvalid User Input");
                        succesfulConversion = false;
                }
                } while (succesfulConversion == false);

                Random rand = new Random();
                agentChoiceInt = rand.Next(1, 4);
    

                Console.WriteLine($"\n{playerName} Choose: {(RpsChoice)playerChoiceInt}, {agentName} Choose: {(RpsChoice)agentChoiceInt}");
                


                if(playerChoiceInt == agentChoiceInt) {
                    Console.WriteLine("Tie Game!");
                } else if((playerChoiceInt == 1 && agentChoiceInt == 2) ||
                        (playerChoiceInt == 2 && agentChoiceInt == 3) ||
                        (playerChoiceInt == 3 && agentChoiceInt == 1)) {
                    Console.WriteLine("Computer Wins!");
                    agentScore++;
                } else {
                    Console.WriteLine("You Win!");
                    playerScore++;
                }

                do {
                    Console.WriteLine($"\nCurrent Score: {playerName} = {playerScore}, {agentName} = {agentScore}");
                    Console.WriteLine("Would you like to play again? (y/n)");
                    playAgain = Console.ReadLine();

                    if(String.Equals(playAgain, "n") || String.Equals(playAgain, "y")) {
                        break;
                    } else {
                        Console.WriteLine("Invalid Input, expected input 'y' or 'n'");
                    }
                    
                } while(true);

                if(String.Equals(playAgain, "n")) {
                    Console.WriteLine("\nThanks for playing!");
                    Console.WriteLine($"Final Score: {playerName} = {playerScore}, {agentName} = {agentScore}");
                    break;
                }
            }
        }

        static void GameIntro() {
            Console.WriteLine("Welcome to Rock Paper Scissors Version 1!\n");
            //Console.WriteLine("This game is best two out of three");
            Console.WriteLine("To play this game you try to choose the object that beats your opponenets object:");
            Console.WriteLine("\t> Rock beats Scissors");
            Console.WriteLine("\t> Scissors beats Paper");
            Console.WriteLine("\t> Paper beats Rock\n");
        }
    }
}
