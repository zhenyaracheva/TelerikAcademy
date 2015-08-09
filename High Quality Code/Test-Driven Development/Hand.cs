namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hand : IHand
    {
        public static readonly List<HandType> HandPowers = new List<HandType>()
         {
             HandType.HighCard,
             HandType.OnePair,
             HandType.TwoPair,
             HandType.ThreeOfAKind,
             HandType.Straight,
             HandType.Flush,
             HandType.FullHouse,
             HandType.FourOfAKind,
             HandType.StraightFlush,
         };

        private PokerHandsChecker checker = new PokerHandsChecker();
            
        public Hand(ISet<ICard> cards)
        {
            this.Cards = cards;
        }

        public ISet<ICard> Cards { get; private set; }

        public override string ToString()
        {
            return string.Join(", ", this.Cards);
        }
    }
}