namespace GSMTaskMain
{
    using System;
    using System.Linq;

    public class GSMCallHistoryTest
    {
        public const decimal Price = 0.37m;
        private GSM testGSM;

        public GSMCallHistoryTest()
        {
            this.testGSM = new GSM("Model", "Manufacturer");
        }

        public GSM TestGSM
        {
            get
            {
                return this.testGSM;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Testing GSM cannot be null!");
                }

                this.testGSM = value;
            }
        }

        public void AddTestingCalls()
        {
            this.TestGSM.AddCall(new Call(DateTime.Now, new Contact("0123123456"), 15.26));
            this.TestGSM.AddCall(new Call(new DateTime(2002, 9, 25, 19, 56, 12), new Contact("John Doe", "+359812345678"), 59.42));
            this.TestGSM.AddCall(new Call(new DateTime(2015, 3, 10, 15, 30, 45), new Contact("Caller name", "+359812123456"), 16.35));
        }

        public void ClearTestingCalls()
        {
            this.testGSM.ClearHistory();
        }

        public void SumCallsTesting()
        {
            Console.WriteLine("Total price: {0:F2}", this.TestGSM.CalculateCallHistoryPrice(Price));
        }

        public void RemoveMaxDurationCall()
        {
            var sorted = this.testGSM.CallHistory.OrderBy(d => d.Duration);
            this.testGSM.DeleteCall(sorted.Last());
        }

        public void Print()
        {
            int testIndex = 1;

            if (this.TestGSM.CallHistory.Count == 0)
            {
                Console.WriteLine("No calls!");
            }
            else
            {
                foreach (var call in this.TestGSM.CallHistory)
                {
                    Console.WriteLine("Test: {0}", testIndex);
                    Console.WriteLine(call.ToString());

                    testIndex++;
                }
            }
        }
    }
}
