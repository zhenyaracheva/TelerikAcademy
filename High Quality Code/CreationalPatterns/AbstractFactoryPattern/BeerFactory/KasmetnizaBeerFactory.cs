namespace AbstractFactoryPattern.BeerFactory
{
    using AbstractFactoryPattern.Products;

    public class KasmetnizaBeerFactory : BeerFactory
    {
        private const double DarkBeerAlcohol = 5.1;
        private const double LightBeerAlcohol = 4.8;
        private const double WeisskBeerAlcohol = 4.3;
        private const double NoAlcoholBeerAlcohol = 0.0;
        private const string MadeBy = "Kasmetniza";

        public override DarkBeer CreateDarkBeer()
        {
            return new DarkBeer(KasmetnizaBeerFactory.DarkBeerAlcohol, KasmetnizaBeerFactory.MadeBy);
        }

        public override LightBeer CreateLightBeer()
        {
            return new LightBeer(KasmetnizaBeerFactory.LightBeerAlcohol, KasmetnizaBeerFactory.MadeBy);
        }

        public override WeissBeer CreateWeissBeer()
        {
            return new WeissBeer(KasmetnizaBeerFactory.WeisskBeerAlcohol, KasmetnizaBeerFactory.MadeBy);
        }

        public override NoAlcoholBeer CreateNoAlcoholBeer()
        {
            return new NoAlcoholBeer(KasmetnizaBeerFactory.NoAlcoholBeerAlcohol, KasmetnizaBeerFactory.MadeBy);
        }
    }
}
