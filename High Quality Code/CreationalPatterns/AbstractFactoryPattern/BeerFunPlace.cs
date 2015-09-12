namespace AbstractFactoryPattern
{
    using AbstractFactoryPattern.BeerFactory;
    using AbstractFactoryPattern.BeerFactory.Contracts;
using AbstractFactoryPattern.Products;

    public class BeerFunPlace
    {
        private readonly IBeerFactory beerDeliveryFactory;

        public BeerFunPlace(IBeerFactory factory)
        {
            this.beerDeliveryFactory = factory;
        }

        public DarkBeer SellDarkBeer()
        {
            return this.beerDeliveryFactory.CreateDarkBeer();
        }

        public LightBeer SellLightkBeer()
        {
            return this.beerDeliveryFactory.CreateLightBeer();
        }

        public WeissBeer SellWeisskBeer()
        {
            return this.beerDeliveryFactory.CreateWeissBeer();
        }

        public NoAlcoholBeer SellNoAlcoholBeer()
        {
            return this.beerDeliveryFactory.CreateNoAlcoholBeer();
        }
    }
}
