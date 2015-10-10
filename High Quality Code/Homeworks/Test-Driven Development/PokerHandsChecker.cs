namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int FiveRepeaat = 5;
        private const int FourRepeat = 4;
        private const int PairRepeat = 2;
        private const int ThreeRepeat = 3;
       
        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                return false;
            }

            if (hand.Cards == null)
            {
                return false;
            }

            if (hand.Cards.Count != PokerHandsChecker.FiveRepeaat)
            {
                return false;
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            var suit = hand.Cards.First().Suit;
            var sameSuitCout = hand.Cards.Count(card => card.Suit == suit);
            if (this.IsStraightHand(hand) && sameSuitCout == PokerHandsChecker.FiveRepeaat)
            {
                return true;
            }

            return false;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            return this.RepeatedCountCardsOfKind(hand, PokerHandsChecker.FourRepeat);
        }

        public bool IsFullHouse(IHand hand)
        {
            var sortedCards = hand.Cards.OrderBy(card => card.Face).ToList();

            var firstCard = sortedCards[0];
            var second = sortedCards[sortedCards.Count - 1];
            var firstCardOccurence = sortedCards.Count(card => (card.Face == firstCard.Face));
            var secondCardsOccurence = sortedCards.Count(card => (card.Face == second.Face));

            if (firstCardOccurence == PokerHandsChecker.ThreeRepeat && secondCardsOccurence == PokerHandsChecker.PairRepeat)
            {
                return true;
            }

            if (firstCardOccurence == PokerHandsChecker.PairRepeat && secondCardsOccurence == PokerHandsChecker.ThreeRepeat)
            {
                return true;
            }

            return false;
        }

        public bool IsFlush(IHand hand)
        {
            var cardSuit = hand.Cards.First().Suit;
            foreach (var card in hand.Cards)
            {
                if (cardSuit != card.Suit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            if (this.IsStraightHand(hand))
            {
                return true;
            }

            return false;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            return this.RepeatedCountCardsOfKind(hand, PokerHandsChecker.ThreeRepeat);
        }

        public bool IsTwoPair(IHand hand)
        {
            var sortedCards = hand.Cards.OrderBy(card => card.Face).ToList();
            var pairs = 0;
            var occurences = new List<CardFace>();
            for (int i = 0; i < sortedCards.Count; i++)
            {
                var currentCard = sortedCards[i];

                if (!occurences.Contains(currentCard.Face))
                {
                    var currenrOccurence = sortedCards.Count(card => card.Face == currentCard.Face);
                    if (currenrOccurence >= 2)
                    {
                        pairs++;

                        if (pairs == 2)
                        {
                            return true;
                        }

                        occurences.Add(currentCard.Face);
                    }
                }
            }

            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            return this.RepeatedCountCardsOfKind(hand, PokerHandsChecker.PairRepeat);
        }

        public bool IsHighCard(IHand hand)
        {
            return true;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            var firstHandType = this.GetHandType(firstHand);
            var secondHandType = this.GetHandType(secondHand);

            if (firstHandType == HandType.HighCard && secondHandType == HandType.HighCard)
            {
                var maxFirstHandCard = this.GetMaxCard(firstHand) as Card;
                var maxSecondHAndCArd = this.GetMaxCard(secondHand) as Card;

                if (maxFirstHandCard > maxSecondHAndCArd)
                {
                    return 1;
                }
                else if (maxFirstHandCard < maxSecondHAndCArd)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                var firstPower = Hand.HandPowers.IndexOf(firstHandType);
                var secondPower = Hand.HandPowers.IndexOf(secondHandType);
                if (firstPower < secondPower)
                {
                    return -1;
                }
                else if (firstPower > secondPower)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private ICard GetMaxCard(IHand hand)
        {
            return hand.Cards.OrderBy(card => card.Face)
                              .ThenBy(card => card.Suit)
                              .Last();
        }

        private bool RepeatedCountCardsOfKind(IHand hand, int repeats)
        {
            var cards = hand.Cards.ToList();

            for (int i = 0; i < cards.Count; i++)
            {
                var count = 1;
                var currentCard = cards[i].Face;
                for (int j = i + 1; j < cards.Count; j++)
                {
                    if (currentCard == cards[j].Face)
                    {
                        count++;
                        if (count == repeats)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private HandType GetHandType(IHand hand)
        {
            if (this.IsStraightFlush(hand))
            {
                return HandType.StraightFlush;
            }
            else if (this.IsFourOfAKind(hand))
            {
                return HandType.FourOfAKind;
            }
            else if (this.IsFullHouse(hand))
            {
                return HandType.FullHouse;
            }
            else if (this.IsFlush(hand))
            {
                return HandType.Flush;
            }
            else if (this.IsStraight(hand))
            {
                return HandType.Straight;
            }
            else if (this.IsThreeOfAKind(hand))
            {
                return HandType.ThreeOfAKind;
            }
            else if (this.IsTwoPair(hand))
            {
                return HandType.TwoPair;
            }
            else if (this.IsOnePair(hand))
            {
                return HandType.OnePair;
            }
            else if (this.IsHighCard(hand))
            {
                return HandType.HighCard;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Inavalid hand");
            }
        }

        private bool IsStraightHand(IHand hand)
        {
            var sortedCard = hand.Cards.OrderBy(card => card.Face).ToList();
            var currentCard = sortedCard[0];
            var currentIndex = Card.CardFacePowers.IndexOf(currentCard.Face);

            for (int i = 1; i < sortedCard.Count; i++)
            {
                var nextIndex = Card.CardFacePowers.IndexOf(sortedCard[i].Face);
                if (currentIndex + 1 != nextIndex)
                {
                    return false;
                }

                currentIndex = nextIndex;
            }

            return true;
        }
    }
}
