namespace ComputersTests
{
    using ComputersLogic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LaptopBatteryTests
    {
        [TestMethod]
        public void BatteryShouldChargeCorrectWhenAdding10()
        {
            var battery = new LaptopBattery();
            battery.Charge(10);
            Assert.AreEqual(60, battery.Percentage);
        }

        [TestMethod]
        public void BatteryShouldChargeCorrectWhenRemoving10()
        {
            var battery = new LaptopBattery();
            battery.Charge(-10);
            Assert.AreEqual(40, battery.Percentage);
        }

        [TestMethod]
        public void BatteryPercentageMustBe100WhenAddingPercantageIsBiggerThan100()
        {
            var battery = new LaptopBattery();
            battery.Charge(105);
            Assert.AreEqual(100, battery.Percentage);
        }

        [TestMethod]
        public void BatteryPercentageMustBeZeroWhenAddingPercantageIsMinus105()
        {
            var battery = new LaptopBattery();
            battery.Charge(-105);
            Assert.AreEqual(0, battery.Percentage);
        }
    }
}
