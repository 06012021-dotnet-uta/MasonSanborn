using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    public class AsyncMethodsClass
    {
        public async Task<string> Method1()
        {
            System.Console.WriteLine("Method 1 Before Task");
            Task task = Task.Delay(1000);
            System.Console.WriteLine("Method 1 After Task");

            // System.Console.WriteLine("Please enter a sentance");
            // string userInput = Console.ReadLine();
            await task;
            System.Console.WriteLine("Method 1 After Awaiting Task");
            return "test method 1";
        }

        public async Task<int> Method2()
        {
            Task task = Task.Delay(2000);

            // System.Console.WriteLine("Please enter a sentance");
            // string userInput = Console.ReadLine();
            await task;
            return 1;
        }

        public async Task<int> Method3()
        {
            Task task = Task.Delay(3000);

            // System.Console.WriteLine("Please enter a sentance");
            // string userInput = Console.ReadLine();
            await task;
            return 1;
        }

        public async Task<string> Method4()
        {
            Task task = Task.Delay(4000);

            // System.Console.WriteLine("Please enter a sentance");
            // string userInput = Console.ReadLine();
            await task;
            return "test method 1";
        }
    }
}