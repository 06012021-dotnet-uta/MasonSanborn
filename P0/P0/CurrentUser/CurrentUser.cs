using System;
using P0DbContext.Models;
using System.Collections.Generic;
using System.Text;

namespace CurrentUserNamespace
{
    public class CurrentUser : ICurrentUser
    {
        public Customer currentCustomer { get; set; }
        public Location currentLocation { get; set; }
        public Dictionary<Product, int> shoppingCart = new Dictionary<Product, int>(); 

        public int getUserInputInt(int minVal, int maxVal)
        {
            bool succesfulConversion = false;
            int intInput;

            do
            {
                string userInput = Console.ReadLine();

                // create an int variable to catch the converted choice
                // try to convert the user choice to int, if succesful it will output the result as true and set the value
                // to playerChoiceInt. If false it will not do anything
                succesfulConversion = Int32.TryParse(userInput, out intInput);

                // checks to see that the user entered a number and that the number is in range
                // if invalid input, succesfulConversion is false
                if (succesfulConversion != true || intInput < minVal || intInput > maxVal)
                {
                    Console.WriteLine("Invalid User Input");
                    succesfulConversion = false;
                }
            } while (succesfulConversion == false);

            return intInput;
        }

        public bool getUserInputYN(string questionMessage)
        {
            do
            {
                Console.WriteLine(questionMessage);
                string playAgainInput = Console.ReadLine().ToLower().Trim();

                if (String.Equals(playAgainInput, "n"))
                {
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
            } while (true);
        }

        public string getUserInputString(string displayMessage)
        {
            StringBuilder sb = new StringBuilder();

            Console.Write(displayMessage);
            string userInput = Console.ReadLine().Trim();

            foreach (char c in userInput)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }






    }// end class
}// end namespace
