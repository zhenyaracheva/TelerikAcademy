namespace GSMTaskMain
{
    using System;
    using System.Collections.Generic;

    public class GSMTest
    {
        private IList<GSM> testList;

        public GSMTest()
        {
            this.TestList = new List<GSM>();
        }

        public IList<GSM> TestList
        {
            get
            {
                return this.testList;
            }

            set
            {
                this.testList = new List<GSM>();
            }
        }

        public void TestingTestList()
        {
            this.TestList.Add(new GSM("Model", "Manufacturer"));
            this.TestList.Add(new GSM("Model", "Manufacturer", 12.05));
            this.TestList.Add(new GSM("Model", "Manufacturer", 150.25, new Battery("Battery model", BatteryType.NiMH), new Display(3.5)));
            this.TestList.Add(new GSM("Model", "Manufacturer", 1000.50, new Owner("Owner first name", "Owner last name", 150), new Battery("Battery model", BatteryType.NiCd), new Display(3.5, ConsoleColor.Green)));

            int testIndex = 1;

            foreach (var test in this.TestList)
            {
                Console.WriteLine("Test {0}", testIndex);
                Console.WriteLine(test.ToString());
                testIndex++;
            }
        }

        public void TestStaticProperty()
        {
            Console.WriteLine(new GSM("Model", "Manufacturer").IPhone.ToString());
        }
    }
}
