namespace Poker
{
    using System;
    using System.Collections.Generic;

    public interface IHand
    {
        ISet<ICard> Cards { get; }

        string ToString();
    }
}
