using System;

namespace EventHandlerDemo
{
    public class MethodsClass
    {
        public void OnMessageSend1(object source, MessageEventArgsClass args)
        {
            Console.Write("Add a word to the message: ");
            string userMessage = Console.ReadLine();        // Get a word from the user
            //args.usersMessage += userMessage;               // Append the new word to the existing message
            args.MyString += userMessage;
        }

        public void OnMessageSend2(object source, MessageEventArgsClass args)
        {
            Console.Write("Add a word to the message: ");
            string userMessage = Console.ReadLine();        // Get a word from the user
            //args.usersMessage += userMessage;               // Append the new word to the existing message
            args.MyString += userMessage;
        }

    }
}