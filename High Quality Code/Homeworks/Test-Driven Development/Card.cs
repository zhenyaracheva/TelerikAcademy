namespace Poker
{
    using System;
    using System.Collections.Generic;

    public class Card : ICard, IComparable
    {
        public static readonly List<CardFace> CardFacePowers = new List<CardFace>()
                                                    {
                                                        CardFace.Two, 
                                                        CardFace.Three, 
                                                        CardFace.Four,
                                                        CardFace.Five,
                                                        CardFace.Six,
                                                        CardFace.Seven,
                                                        CardFace.Eight,
                                                        CardFace.Nine,
                                                        CardFace.Ten,
                                                        CardFace.Jack,
                                                        CardFace.Queen,
                                                        CardFace.King,
                                                        CardFace.Ace 
                                                    };

        public static readonly List<CardSuit> CardSuitowers = new List<CardSuit>()
                                                    {
                                                        CardSuit.Spades, 
                                                        CardSuit.Diamonds, 
                                                        CardSuit.Hearts,
                                                        CardSuit.Clubs,
                                                    };

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public static bool operator ==(Card first, Card second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Card first, Card second)
        {
            return first.Equals(second);
        }

        public static bool operator >(Card first, Card second)
        {
            var firstPower = CardFacePowers.IndexOf(first.Face);
            var secondPower = CardFacePowers.IndexOf(first.Face);

            if (firstPower > secondPower)
            {
                return true;
            }
            else if (firstPower < secondPower)
            {
                return false;
            }
            else
            {
                firstPower = CardSuitowers.IndexOf(first.Suit);
                secondPower = CardSuitowers.IndexOf(second.Suit);

                if (firstPower > secondPower)
                {
                    return true;
                }
                else if (firstPower < secondPower)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool operator <(Card first, Card second)
        {
            return !(first > second);
        }

        public override int GetHashCode()
        {
            return this.Face.ToString().GetHashCode() | this.Suit.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var otherCard = obj as Card;

            if (this.Face == otherCard.Face && this.Suit == otherCard.Suit)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            var result = this.Face + " " + this.Suit;
            return result;
        }

        public int CompareTo(object obj)
        {
            var card = obj as Card;

            if (card == null)
            {
                throw new ArgumentOutOfRangeException("Invavi card!");
            }

            if (this > card)
            {
                return 1;
            }
            else if (this < card)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
