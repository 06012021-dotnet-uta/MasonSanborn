using System;

namespace DelegateSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            DelegateClass myDelegateClass = new DelegateClass();
            MethodsClass myMethodsClass = new MethodsClass();

            // Assigns the delegate method(s) to point to
            // Assignment of a method is different than invoking the method
            myDelegateClass.mySimpleDelegate += myMethodsClass.method1;
            myDelegateClass.mySimpleDelegate += myMethodsClass.method2;
            myDelegateClass.mySimpleDelegate += myMethodsClass.method3;

            // Methods can be stacked to execute multiple times
            myDelegateClass.mySimpleDelegate += myMethodsClass.method1;

            // removes a method from the invocation list
            myDelegateClass.mySimpleDelegate -= myMethodsClass.method2;
            
            // calls the delegate object executing all of the methods attatched
            //myDelegateClass.mySimpleDelegate();

            // add some appropriate methods to the other delegates
            // that have string parameters
            myDelegateClass.myNotSimpleDelegate += myMethodsClass.method4;
            myDelegateClass.myNotSimpleDelegate += myMethodsClass.method5;
            myDelegateClass.myNotSimpleDelegate += myMethodsClass.method6;

            string myString = "Adding: ";
            int result = myDelegateClass.myNotSimpleDelegate(ref myString);
            Console.WriteLine($"The result is => {result}");
            Console.WriteLine($"The string is => {myString}");




            myDelegateClass.myAction = myMethodsClass.method1;

            myDelegateClass.myActionWithOneParameter = myMethodsClass.method7;
            myDelegateClass.myActionWithOneParameter(7);

            myDelegateClass.myFuncDelegate = myMethodsClass.method10;
            int method10Test = myDelegateClass.myFuncDelegate();
            Console.WriteLine($"Method 10 int returned: {method10Test}");


            // Lambda expressions: use for methods you only intent to call once
            myDelegateClass.myFuncDelegate = (/*int x, string y*/) => {
                return 11;
            };
            
            int lambdaMethodTest = myDelegateClass.myFuncDelegate();
            Console.WriteLine($"Lambda Method int returned: {lambdaMethodTest}");

            myDelegateClass.myFuncDelegate = () => 12;
            int lambdaMethodTestTwo = myDelegateClass.myFuncDelegate();
            Console.WriteLine($"Lambda Method 2 int returned: {lambdaMethodTestTwo}");
        
            // multi-line lambda expression
            myDelegateClass.myFuncDelegate = () => {
                Console.Write("Please Input a Number: ");
                int lambdaIntInput = Int32.Parse(Console.ReadLine());
                return lambdaIntInput;
            };
            int lambdaMethodTestThree = myDelegateClass.myFuncDelegate();
            Console.WriteLine($"Lambda Method 3 int returned: {lambdaMethodTestThree}");

        }
    }
}
