using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void ToStringTest()
        {
            var firstHand = new Card(CardFace.Ten, CardSuit.Diamonds);
            var secondHard = new Card(CardFace.Nine, CardSuit.Spades);

            var hand = new Hand(new HashSet<ICard>() { firstHand, secondHard });
            var expected = "Ten Diamonds, Nine Spades";
            Assert.AreEqual(expected, hand.ToString(), "Expected result to be: " + expected);
        }
    }
}
