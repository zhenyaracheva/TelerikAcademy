namespace AbstractFactoryPattern.BeerFactory.Contracts
{
    using AbstractFactoryPattern.Products;

    public interface IBeerFactory
    {
        DarkBeer CreateDarkBeer();

        LightBeer CreateLightBeer();

        WeissBeer CreateWeissBeer();

        NoAlcoholBeer CreateNoAlcoholBeer();
    }
}
