namespace DeckTest
{
    using System;

    using NUnit.Framework;
    using SantaseGameEngine.Cards;
    using SantaseGameEngine.Exceptions;
    using System.Collections.Generic;

    [TestFixture]
    public class DeckTest
    {


        [Test]
        public void GetNextCardPreviousCardDifferentThanNextTest()
        {
            var deck = new Deck();
            var lastCard = deck.GetNextCard();
            Assert.AreNotEqual(deck.GetNextCard(), lastCard);
        }

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(24)]
        public void GetNextCardTest(int count)
        {
            var deck = new Deck();
            var deckCards = new List<Card>();
            for (int i = 0; i < count; i++)
            {
                deckCards.Add(deck.GetNextCard());
            }

            Assert.AreEqual(deckCards.Count, count);
        }


        [TestCase(25)]
        [TestCase(30)]
        [ExpectedException(typeof(InternalGameException))]
        public void GetNextCardThrowsAfterTakeCardFromEmptyDeckTest(int count)
        {
            var deck = new Deck();

            for (int i = 0; i < count; i++)
            {
                deck.GetNextCard();
            }
        }

        [Test]
        public void ChangeTrumpCardTest()
        {
            var deck = new Deck();
            Card testCard = new Card(CardSuit.Spade, CardType.Ace);
            deck.ChangeTrumpCard(testCard);
            Assert.AreEqual(deck.GetTrumpCard, testCard);
        }

        [TestCase(1, 23)]
        [TestCase(24, 0)]
        [TestCase(12, 12)]
        [TestCase(0, 24)]
        public void CardsLeftTest(int removeCardsCount, int expectedCardsCount)
        {
            var deck = new Deck();

            for (int i = 0; i < removeCardsCount; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(deck.CardsLeft, expectedCardsCount);
        }
    }
}
