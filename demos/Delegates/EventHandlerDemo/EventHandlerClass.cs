using System;

namespace EventHandlerDemo
{
    public class EventHandlerClass
    {
        // 1. Create new delegate type
        // Event Args is a container for arguments
        //public delegate void MessageHandler(object source, EventArgs args);
        public delegate void MessageHandler(object source, MessageEventArgsClass args);

        // 2. instantiate the delegate
        // This is no longer a delegate, it is now a handler of the type delegate
        public event MessageHandler myMessageHandler;

        // Raise the event through this preparatory / protector method
        public void MessageSend(string message)
        {
            // Can do some sore of argument checking before raising the event
            // call the method that invokes the delegate
            message += message;
            OnMessageSend(message);

        }

        // create the method that actually raises the event
        private void OnMessageSend(string message)
        {
            // Check if there are any subscribers to the delegate
            // If there are subscribers: 
            if(myMessageHandler != null)
            {

                //myMessageHandler(this, EventArgs.Empty);

                //          This is tightly coupling and should be avoided to prevent issues when making modifications
                /*
                MessageEventArgsClass meac = new MessageEventArgsClass() {MyString = message};
                myMessageHandler(this, meac);
                System.Console.WriteLine(meac.MyString);
                */

                //          This is loose coupling allowing the program to function without strict variable names
                // evoke the event with 'this' which is the current context class
                myMessageHandler(this, new MessageEventArgsClass() {MyString = message});
                
            }
            else
            {
                Console.WriteLine("There were no subscribers");
            }
        }

    }
}