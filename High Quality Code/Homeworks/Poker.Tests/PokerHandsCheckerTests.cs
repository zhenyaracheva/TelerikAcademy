using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class PokerHandsCheckerTests
    {
        PokerHandsChecker checker;
        Card clubsTen;
        Card clubJack;
        Card clubsQueen;
        Card heartsQueen;
        Card doubleHeartsQueen;
        Card spadeQueen;
        Card diamondQueen;
        Card clubsKing;
        Card heartKing;
        Card clubsAce;
        Hand validFlushHand;
        Hand validFourOfKing;
        Hand validOnePair;
        Hand validThreeOfKing;
        Hand validStraightFlush;
        Hand validFullHouse;
        Hand validStraighth;
        Hand validTwoPair;

        [TestInitialize]
        public void CreateChecker()
        {
            checker = new PokerHandsChecker();
            clubsTen = new Card(CardFace.Ten, CardSuit.Clubs);
            clubJack = new Card(CardFace.Jack, CardSuit.Clubs);
            clubsQueen = new Card(CardFace.Queen, CardSuit.Clubs);
            heartsQueen = new Card(CardFace.Queen, CardSuit.Hearts);
            doubleHeartsQueen = new Card(CardFace.Queen, CardSuit.Hearts);
            spadeQueen = new Card(CardFace.Queen, CardSuit.Spades);
            diamondQueen = new Card(CardFace.Queen, CardSuit.Diamonds);
            clubsKing = new Card(CardFace.King, CardSuit.Clubs);
            heartKing = new Card(CardFace.King, CardSuit.Hearts);
            clubsAce = new Card(CardFace.Ace, CardSuit.Clubs);
            validFlushHand = new Hand(new HashSet<ICard>() { clubsTen, clubJack, clubsQueen, clubsKing, clubsAce });
            validFourOfKing = new Hand(new HashSet<ICard>() { diamondQueen, clubsAce, clubsQueen, heartsQueen, spadeQueen });
            validOnePair = new Hand(new HashSet<ICard>() { diamondQueen, clubsAce, clubsQueen, clubsKing, clubsTen });
            validThreeOfKing = new Hand(new HashSet<ICard>() { diamondQueen, clubsAce, clubsQueen, heartsQueen, clubJack });
            validStraightFlush = new Hand(new HashSet<ICard>() { clubJack, clubsAce, clubsQueen, clubsTen, clubsKing });
            validFullHouse = new Hand(new HashSet<ICard>() { diamondQueen, heartsQueen, clubsQueen, heartKing, clubsKing });
            validStraighth = new Hand(new HashSet<ICard>() { clubJack, clubsAce, diamondQueen, clubsTen, heartKing });
            validTwoPair = new Hand(new HashSet<ICard>() { clubsQueen, clubsAce, diamondQueen, clubsKing, heartKing });
        }

        [TestMethod]
        public void ReturnFalseIfListOfCarsdsIsNullTest()
        {
            var hand = new Hand(null);
            Assert.IsFalse(checker.IsValidHand(hand), "Expected to be false");
        }

        [TestMethod]
        public void ReturnFalseIfHandIsNullTest()
        {
            Assert.IsFalse(checker.IsValidHand(null), "Expected to be false");
        }

        [TestMethod]
        public void ReturnFalseIfHandCardsCountDifferentThan5()
        {
            var hand = new Hand(new HashSet<ICard>());
            Assert.IsFalse(checker.IsValidHand(hand), "Expected to be false");
        }

        [TestMethod]
        public void InvalidHandTest()
        {
            var hand = new Hand(new HashSet<ICard>() { heartsQueen, doubleHeartsQueen, heartsQueen, doubleHeartsQueen, heartsQueen });
            var expected = 1;
            Assert.AreEqual(expected, hand.Cards.Count, "Expected hand cards to be: " + expected);
        }

        [TestMethod]
        public void ValidFlushHandTest()
        {
            Assert.IsTrue(checker.IsFlush(validFlushHand));
        }

        [TestMethod]
        public void InvValidFlushHandTest()
        {
            var hand = new Hand(new HashSet<ICard>() { clubsTen, clubJack, heartsQueen, clubsQueen, clubsAce });
            Assert.IsFalse(checker.IsFlush(hand));
        }

        [TestMethod]
        public void ValidFourOfKing()
        {
            Assert.IsTrue(checker.IsFourOfAKind(validFourOfKing));
        }

        [TestMethod]
        public void InvalidFourOfKing()
        {
            var hand = new Hand(new HashSet<ICard>() { clubJack, clubsAce, clubsQueen, heartsQueen, spadeQueen });
            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void ValidOnePair()
        {
            Assert.IsTrue(checker.IsOnePair(validOnePair));
        }

        [TestMethod]
        public void InvalidOnePair()
        {
            var hand = new Hand(new HashSet<ICard>() { clubJack, clubsAce, clubsQueen, clubsKing, clubsTen });
            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void ValidThreeOfKing()
        {
            Assert.IsTrue(checker.IsThreeOfAKind(validThreeOfKing));
        }

        [TestMethod]
        public void InvalidThreeOfKing()
        {
            var hand = new Hand(new HashSet<ICard>() { clubJack, clubsAce, clubsQueen, heartsQueen, clubsKing });
            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void ValidStraightFlush()
        {
            Assert.IsTrue(checker.IsStraightFlush(validStraightFlush));
        }

        [TestMethod]
        public void InvalidStraightFlush()
        {
            var hand = new Hand(new HashSet<ICard>() { clubJack, clubsAce, clubsQueen, heartsQueen, clubsKing });
            Assert.IsFalse(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void ValidFullHouse()
        {
            Assert.IsTrue(checker.IsFullHouse(validFullHouse));
        }

        [TestMethod]
        public void InvalidFullHouse()
        {
            var hand = new Hand(new HashSet<ICard>() { clubJack, clubsAce, clubsQueen, heartsQueen, clubsKing });
            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void ValidStraighth()
        {
            Assert.IsTrue(checker.IsStraight(validStraighth));
        }

        [TestMethod]
        public void InvalidStraight()
        {
            var hand = new Hand(new HashSet<ICard>() { clubJack, clubsAce, clubsQueen, heartsQueen, clubsKing });
            Assert.IsFalse(checker.IsStraight(hand));
        }

        [TestMethod]
        public void ValidTwoPair()
        {
            Assert.IsTrue(checker.IsTwoPair(validTwoPair));
        }

        [TestMethod]
        public void InvalidTwoPair()
        {
            var hand = new Hand(new HashSet<ICard>() { clubJack, clubsAce, clubsQueen, heartsQueen, clubsKing });
            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void CheckStraigthFlushBiggerHandThanFullHouse()
        {
            var expected = 1;
            Assert.AreEqual(expected, checker.CompareHands(validStraightFlush, validFullHouse));

        }

        [TestMethod]
        public void CheckFullHouseSmallerHandStraigthFlush()
        {
            var expected = -1;
            Assert.AreEqual(expected, checker.CompareHands(validFullHouse, validStraightFlush));
        }

       [TestMethod]
        public void CheckEqualHands()
        {
            var secondPair = new Hand(new HashSet<ICard>() { clubJack, heartsQueen, spadeQueen, clubsKing, clubsTen });
            var expected = 0;
            Assert.AreEqual(expected, checker.CompareHands(validOnePair, secondPair));
        }
    }
}
