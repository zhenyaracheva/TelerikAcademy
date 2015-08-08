namespace SantaseGameEngine.Interfaces
{
    using SantaseGameEngine.Cards;

    public interface IDeck
    {
        Card GetNextCard();

        Card GetTrumpCard { get; }

        void ChangeTrumpCard(Card newCard);

        int CardsLeft { get; }
    }
}
