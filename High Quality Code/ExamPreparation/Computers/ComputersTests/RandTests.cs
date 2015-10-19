namespace ComputersTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ComputersLogic;
    using ComputersLogic.Cpus;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class RandTests
    {
        [TestMethod]
        public void MethodSholdReturnMinValue()
        {
            var cpu = new Cpu32(2);
            var motherboard = new Mock<IMotherboard>();
            cpu.AttachTo(motherboard.Object);
            var minNumber = int.MaxValue;
            motherboard.Setup(x => x.SaveRamValue(It.IsAny<int>())).Callback<int>(param => minNumber = Math.Min(minNumber, param));

            for (int i = 0; i < 100000; i++)
            {
                cpu.Rand(1, 10);
            }

            Assert.AreEqual(1, minNumber);
        }

        [TestMethod]
        public void RandShouldReturnsOnlyNumbersBiggerThanZero()
        {
            var cpu = new Cpu128(4);
            var motherboard = new Mock<IMotherboard>();
            cpu.AttachTo(motherboard.Object);
            var numbers = new SortedSet<int>();
            motherboard.Setup(x => x.SaveRamValue(It.IsAny<int>())).Callback<int>(x => numbers.Add(x));


            for (int i = 0; i < 100000; i++)
            {
                cpu.Rand(1, 10);
            }

            var numbersBitterThanNine = numbers.Count(x => (x > 10));

            Assert.AreEqual(0, numbersBitterThanNine);
        }

        [TestMethod]
        public void RandShouldReturnOnlyNumbersInRanheOneZero()
        {
            var cpu64 = new Cpu64(4);
            var motherboard = new Mock<IMotherboard>();
            cpu64.AttachTo(motherboard.Object);
            var numbers = new SortedSet<int>();
            motherboard.Setup(x => x.SaveRamValue(It.IsAny<int>())).Callback<int>(param => numbers.Add(param));

            for (int i = 0; i < 100000; i++)
            {
                cpu64.Rand(1, 10);
            }

            var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            CollectionAssert.AreEqual(expected, numbers.ToArray());
        }
    }
}
