namespace AbstractFactoryPattern.BeerFactory
{
    using AbstractFactoryPattern.BeerFactory.Contracts;
    using AbstractFactoryPattern.Products;

    public abstract class BeerFactory : IBeerFactory
    {
        public abstract DarkBeer CreateDarkBeer();

        public abstract LightBeer CreateLightBeer();

        public abstract WeissBeer CreateWeissBeer();

        public abstract NoAlcoholBeer CreateNoAlcoholBeer();
    }
}
