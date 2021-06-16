using System;

namespace DelegateSimple
{
    public class MethodsClass
    {
        #region This region is for void testing methods
        public void method1()
        {
            Console.WriteLine($"This is method 1.");
        }
        public void method2()
        {
            Console.WriteLine($"This is method 2.");
        }
        public void method3()
        {
            Console.WriteLine($"This is method 3.");
        }    
        #endregion


        public int method4(ref string message)
        {
            Console.WriteLine($"Method 4. Add something to the message.");
            string m = Console.ReadLine();
            message += m;
            return 4;
        }     
        public int method5(ref string message)
        {
            Console.WriteLine($"Method 5. Add something to the message.");
            string m = Console.ReadLine();
            message += m;
            return 5;
        }  
        public int method6(ref string message)
        {
            Console.WriteLine($"Method 6. Add something to the message.");
            string m = Console.ReadLine();
            message += m;
            return 6;
        }     

        #region This region is for void testing action methods
        public void method7(int x)
        {
            Console.WriteLine($"This is method 7. int passed: {x}");
        }
        public void method8(int x)
        {
            Console.WriteLine($"This is method 8. int passed: {x}");
        }
        public void method9(int x)
        {
            Console.WriteLine($"This is method 9. int passed: {x}");
        }    
        #endregion
    
        public int method10()
        {
            Console.WriteLine($"This is method 10.");
            return 10;
        }
    }
}