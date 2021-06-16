using System;
// Delegate need the System namespace


namespace DelegateSimple
{
    public class DelegateClass
    {
        // declare a delegate type. This gives the method signature for
        // any method that can be assigned to a delegate of this type
        public delegate void SimpleDelegate();


        // Now create the instance of the delegate
        // type that you can assign methods to.
        public SimpleDelegate mySimpleDelegate;

        // Another function delegate that takes a string parameter by reference
        // value and returns an int
        public delegate int NotSimpleDelegate(ref string message);
        public NotSimpleDelegate myNotSimpleDelegate;


        // Action delegates do NOT return a value, they return void.
        // 'Action delegateName' is used without paramaters
        // 'Action<paramType> delegateName' is used for delegates with paramaters
        // 'Action<int, int, string> delegateName {get; set;}'
        public Action myAction {get; set;}

        public Action<int> myActionWithOneParameter {get; set;}

        public Func<int> myFuncDelegate;
        public Func<string> myStringFuncDelegate;




    }
}