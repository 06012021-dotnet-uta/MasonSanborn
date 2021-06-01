using System;

namespace my_first_hello_world {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Hello World!");
            /*     Commented code from following along with lesson
            string myString = Console.ReadLine();
            Console.WriteLine(myString);
            int myNum = 3;
            Console.Write("\t{0} {1}\n", myNum, myNum);
            String Interpolation
            Console.WriteLine($"This is string interpolation! The number is {myNum}");
            */

            Console.Write("Please enter your age: ");
            string userAge = Console.ReadLine();

            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();

            Console.WriteLine($"Name Entered: {userName}\nAge Entered: {userAge}");

        }
    }
}
