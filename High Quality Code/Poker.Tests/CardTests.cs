using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void ToStringTest()
        {
            var card = new Card(CardFace.Queen, CardSuit.Hearts);
            var expected = "Queen Hearts";
            Assert.AreEqual(expected, card.ToString(), "Result to be " + expected);
        }
    }
}
