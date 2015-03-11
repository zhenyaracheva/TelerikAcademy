namespace GSMTaskMain
{
    using System;
    using System.Linq;

    public class ProblemGSM
    {
        public static void Main()
        {
            Console.WriteLine("Print list of mobile phones:");
            Console.WriteLine("----------------------------");
            GSMTest test = new GSMTest();
            test.TestingTestList();
            Console.WriteLine();
            Console.WriteLine("Print static field Iphone4S");
            Console.WriteLine("----------------------------");
            test.TestStaticProperty();
            Console.WriteLine();

            GSMCallHistoryTest testCallHistory = new GSMCallHistoryTest();
            Console.WriteLine("Print all call history:");
            Console.WriteLine("-----------------------");
            testCallHistory.AddTestingCalls();
            testCallHistory.Print();
            Console.WriteLine();
            Console.WriteLine("Price of all calls:");
            Console.WriteLine("-------------------");
            testCallHistory.SumCallsTesting();
            Console.WriteLine();

            Console.WriteLine("After removed max duration call:");
            Console.WriteLine("--------------------------------");
            testCallHistory.RemoveMaxDurationCall();
            testCallHistory.Print();
            Console.WriteLine();

            Console.WriteLine("Price after removed max duration call:");
            Console.WriteLine("--------------------------------------");
            testCallHistory.SumCallsTesting();
            Console.WriteLine();

            Console.WriteLine("Clear history:");
            Console.WriteLine("--------------");
            testCallHistory.ClearTestingCalls();
            testCallHistory.Print();
        }
    }
}
