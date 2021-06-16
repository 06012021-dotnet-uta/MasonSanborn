using System;

namespace EventHandlerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            EventHandlerClass eventHandlerClass = new EventHandlerClass();
            MethodsClass methodsClass = new MethodsClass();

            eventHandlerClass.myMessageHandler += methodsClass.OnMessageSend1;
            eventHandlerClass.myMessageHandler += methodsClass.OnMessageSend2;

            System.Console.Write("Enter a word: ");
            string message = Console.ReadLine();
            eventHandlerClass.MessageSend(message);
        }
    }
}
