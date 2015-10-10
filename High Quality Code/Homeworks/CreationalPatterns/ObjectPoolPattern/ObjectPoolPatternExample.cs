namespace ObjectPoolPattern
{
    using System;

    public class ObjectPoolPatternExample
    {
        public static void Main(string[] args)
        {
            var bowlingStore = new BowlingShoesStore<Bowling>();

            var firstPairShoes = bowlingStore.GetShoes();
            firstPairShoes.Player = "John";
            Console.WriteLine("Shoes 1 used by " + firstPairShoes.Player);

            var secondPairShoes = bowlingStore.GetShoes();
            secondPairShoes.Player = "Jane";
            Console.WriteLine("Shoes 2 used by " + secondPairShoes.Player);
        }
    }
}
