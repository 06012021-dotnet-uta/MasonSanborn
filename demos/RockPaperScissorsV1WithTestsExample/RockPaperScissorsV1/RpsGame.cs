using System;

namespace RockPaperScissorsV1
{
    public class RpsGame
    {
        // Store Players names in player objects.
        // The Second Player is set to be a Computer by default
        public Player playerOne = new Player();
        public Player playerTwo = new Player("Computer");

        // Store players score
        public int PlayerOneScore {get; set;} = 0;
        public int PlayerTwoScore {get; set;} = 0;

        private enum RpsChoice
        {
            // without specifying the number equivalent of the enum type, the numbers default to start at 0.
            // By setting corresponding values we can typecast the user's input number to the corresponding RpsChoice type
            Rock = 1,       //equivalent to 1
            Paper = 2,      //equivalent to 2
            Scissors = 3    //equivalent to 3
        }

        /// <summary>
        /// Displays game rules to the user and gets input for the users player name
        /// </summary>
        protected void GameSetup() 
        {
            /// Display game Startup information / rules
            Console.WriteLine("To play this game you try to choose the object that beats your opponenets object:");
            Console.WriteLine("\t> Rock beats Scissors");
            Console.WriteLine("\t> Scissors beats Paper");
            Console.WriteLine("\t> Paper beats Rock\n");

            // Gets the users name as part of the setup process
            GetPlayerName();
        }

        /// <summary>
        /// Asks the user to input their name and assigns it to Player One
        /// </summary>
        private void GetPlayerName() {
            
            Console.Write("Please enter your name: ");
            playerOne.Name = Console.ReadLine().Trim();
        }

        /// <summary>
        /// Plays a round of RPS
        ///     > displays choices to the user
        ///     > gets players choices
        ///     > decides winner
        /// </summary>
        private void PlayRound() 
        {
            bool succesfulConversion = false;
            int playerChoiceInt;
            int agentChoiceInt;
            do 
            {
                Console.WriteLine("Please make your choise: ");
                Console.WriteLine("1\t:\tRock\n2\t:\tPaper\n3\t:\tScissors\n");
                string playerChoice = Console.ReadLine();

                // create an int variable to catch the converted choice
                // try to convert the user choice to int, if succesful it will output the result as true and set the value
                // to playerChoiceInt. If false it will not do anything
                succesfulConversion = Int32.TryParse(playerChoice, out playerChoiceInt);

                // checks to see that the user entered a number and that the number is in range
                // if invalid input, succesfulConversion is false
                if(succesfulConversion != true || playerChoiceInt < 1 || playerChoiceInt > 3) 
                {
                    Console.WriteLine("\nInvalid User Input");
                    succesfulConversion = false;
                }
            } while (succesfulConversion == false);

            // Create a random choice for the Computer Player
            Random rand = new Random();
            agentChoiceInt = rand.Next(1, 4);

            // Display Computer and Players selected choices
            Console.WriteLine($"\n{playerOne.Name}'s Choice: {(RpsChoice)playerChoiceInt}, {playerTwo.Name}'s Choice: {(RpsChoice)agentChoiceInt}");

            // Decide who won the game
            // If the choices were the same tie
            if(playerChoiceInt == agentChoiceInt) 
            {
                Console.WriteLine("Tie Game!");
            } 
            // Check all conditions where the Player One would lose and update Player Two's score
            else if((playerChoiceInt == 1 && agentChoiceInt == 2) ||
                    (playerChoiceInt == 2 && agentChoiceInt == 3) ||
                    (playerChoiceInt == 3 && agentChoiceInt == 1)) 
            {
                Console.WriteLine("Computer Wins!");
                PlayerTwoScore++;
            }
            // otherwise update Player One's score
            else 
            {
                Console.WriteLine("You Win!");
                PlayerOneScore++;
            }
        }

        /// <summary>
        /// Gets user input to decide whether to play agian
        /// </summary>
        /// <returns>bool</returns>
        private bool CheckPlayAgain() 
        {
            do 
            {
                Console.WriteLine($"\nCurrent Score: {playerOne.Name} = {PlayerOneScore}, {playerTwo.Name} = {PlayerTwoScore}");
                Console.WriteLine("Would you like to play again? (y/n)");
                string playAgainInput = Console.ReadLine().ToLower().Trim();


                if(String.Equals(playAgainInput, "n") )
                {
                    Console.WriteLine("\nThanks for playing!");
                    Console.WriteLine($"Final Score: {playerOne.Name} = {PlayerOneScore}, {playerTwo.Name} = {PlayerTwoScore}");
                    return false;
                } 
                else if (String.Equals(playAgainInput, "y"))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid Input, expected input 'y' or 'n'");
                }
            } while(true);
        }

        /// <summary>
        /// Main game loop, continues running rounds while the user wants to continue playing
        /// </summary>
        private void RunGame()
        {
            do 
            {
                PlayRound();
            } while (CheckPlayAgain());
        }

        /// <summary>
        /// Runs setup functionality for the RPS game and begins game loop
        /// </summary>
        public void StartGame()
        {
            GameSetup();
            RunGame();
        }


        private int privateMethodTest()
        {
            return 5;
        }

        //internal void testMethod()
        //{

        //}

    }
}