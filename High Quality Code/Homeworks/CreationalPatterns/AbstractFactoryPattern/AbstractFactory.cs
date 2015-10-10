namespace AbstractFactoryPattern
{
    using System;

    using AbstractFactoryPattern.BeerFactory;

    public class AbstractFactory
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("First beer fun place:");
            var stolichanskoFactory = new StolichanskoBeerFactory();
            var firstBeerFunPlace = new BeerFunPlace(stolichanskoFactory);
            Console.WriteLine(firstBeerFunPlace.SellDarkBeer().ToString());
            Console.WriteLine(firstBeerFunPlace.SellLightkBeer().ToString());
            Console.WriteLine(firstBeerFunPlace.SellWeisskBeer().ToString());
            Console.WriteLine(firstBeerFunPlace.SellNoAlcoholBeer().ToString());
            Console.WriteLine();
            Console.WriteLine("Second beer fun place:");
            var kastetnizaFactory = new KasmetnizaBeerFactory();
            var secondBeerFunPlace = new BeerFunPlace(kastetnizaFactory);
            Console.WriteLine(secondBeerFunPlace.SellDarkBeer().ToString());
            Console.WriteLine(secondBeerFunPlace.SellLightkBeer().ToString());
            Console.WriteLine(secondBeerFunPlace.SellWeisskBeer().ToString());
            Console.WriteLine(secondBeerFunPlace.SellNoAlcoholBeer().ToString());
        }
    }
}
