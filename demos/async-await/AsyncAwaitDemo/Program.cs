using System;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AsyncMethodsClass amc = new AsyncMethodsClass();

            //Task<string> task1 = amc.Method1();

            string method1 = await amc.Method1();
        }
    }
}
