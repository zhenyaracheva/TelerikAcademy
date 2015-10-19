namespace ComputersTests
{
    using System;
    using System.Linq;
    using ComputersLogic;
    using ComputersLogic.Cpus;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class SquareNumberTests
    {
        [TestMethod]
        public void MethodShouldReturnValidNumberTestingCpu32()
        {
            var cpu = new Cpu32(4);
            var motherboard = new Mock<IMotherboard>();
            motherboard.Setup(x => x.LoadRamValue()).Returns(6);
            cpu.AttachTo(motherboard.Object);
            cpu.SquareNumber();
            motherboard.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y.Contains("36"))));
        }

        [TestMethod]
        public void MethodShouldReturnValidNumberTestingCpu64()
        {
            var cpu = new Cpu64(4);
            var motherboard = new Mock<IMotherboard>();
            motherboard.Setup(x => x.LoadRamValue()).Returns(999);
            cpu.AttachTo(motherboard.Object);
            cpu.SquareNumber();
            motherboard.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y.Contains("998001"))));
        }

        [TestMethod]
        public void MethodShouldReturnValidNumberTestingCpu128()
        {
            var cpu = new Cpu128(4);
            var motherboard = new Mock<IMotherboard>();
            motherboard.Setup(x => x.LoadRamValue()).Returns(2000);
            cpu.AttachTo(motherboard.Object);
            cpu.SquareNumber();
            motherboard.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y.Contains("4000000"))));
        }

        [TestMethod]
        public void MethodShouldReturnReturnNumberTooHighTestingCpu32()
        {
            var cpu = new Cpu32(4);
            var motherboard = new Mock<IMotherboard>();
            motherboard.Setup(x => x.LoadRamValue()).Returns(501);
            cpu.AttachTo(motherboard.Object);
            cpu.SquareNumber();
            motherboard.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y.Contains("Number too high"))));
        }

        [TestMethod]
        public void MethodShouldReturnNumberTooHightTestingCpu64()
        {
            var cpu = new Cpu64(4);
            var motherboard = new Mock<IMotherboard>();
            motherboard.Setup(x => x.LoadRamValue()).Returns(1001);
            cpu.AttachTo(motherboard.Object);
            cpu.SquareNumber();
            motherboard.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y.Contains("Number too high"))));
        }

        [TestMethod]
        public void MethodShouldReturnNumberTooHighTestingCpu128()
        {
            var cpu = new Cpu128(4);
            var motherboard = new Mock<IMotherboard>();
            motherboard.Setup(x => x.LoadRamValue()).Returns(2200);
            cpu.AttachTo(motherboard.Object);
            cpu.SquareNumber();
            motherboard.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y.Contains("Number too high"))));
        }

        [TestMethod]
        public void MethodShouldReturnReturnNumberTooLowTestingCpu32()
        {
            var cpu = new Cpu32(4);
            var motherboard = new Mock<IMotherboard>();
            motherboard.Setup(x => x.LoadRamValue()).Returns(-5);
            cpu.AttachTo(motherboard.Object);
            cpu.SquareNumber();
            motherboard.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y.Contains("Number too low"))));
        }

        [TestMethod]
        public void MethodShouldReturnReturnNumberTooLowTestingCpu64()
        {
            var cpu = new Cpu32(4);
            var motherboard = new Mock<IMotherboard>();
            motherboard.Setup(x => x.LoadRamValue()).Returns(-5);
            cpu.AttachTo(motherboard.Object);
            cpu.SquareNumber();
            motherboard.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y.Contains("Number too low"))));
        }

        [TestMethod]
        public void MethodShouldReturnReturnNumberTooLowTestingCpu128()
        {
            var cpu = new Cpu32(4);
            var motherboard = new Mock<IMotherboard>();
            motherboard.Setup(x => x.LoadRamValue()).Returns(-5);
            cpu.AttachTo(motherboard.Object);
            cpu.SquareNumber();
            motherboard.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y.Contains("Number too low"))));
        }
    }
}
