namespace AbstractFactoryPattern.BeerFactory
{
    using AbstractFactoryPattern.Products;

    public class StolichanskoBeerFactory : BeerFactory
    {
        private const double DarkBeerAlcohol = 5.2;
        private const double LightBeerAlcohol = 4.6;
        private const double WeisskBeerAlcohol = 4.3;
        private const double NoAlcoholBeerAlcohol = 0.0;
        private const string MadeBy = "Stolichansko";
        
        public override DarkBeer CreateDarkBeer()
        {
            return new DarkBeer(StolichanskoBeerFactory.DarkBeerAlcohol, StolichanskoBeerFactory.MadeBy);
        }

        public override LightBeer CreateLightBeer()
        {
            return new LightBeer(StolichanskoBeerFactory.LightBeerAlcohol, StolichanskoBeerFactory.MadeBy);
        }

        public override WeissBeer CreateWeissBeer()
        {
            return new WeissBeer(StolichanskoBeerFactory.WeisskBeerAlcohol, StolichanskoBeerFactory.MadeBy);
        }

        public override NoAlcoholBeer CreateNoAlcoholBeer()
        {
            return new NoAlcoholBeer(StolichanskoBeerFactory.NoAlcoholBeerAlcohol, StolichanskoBeerFactory.MadeBy);
        }
    }
}
