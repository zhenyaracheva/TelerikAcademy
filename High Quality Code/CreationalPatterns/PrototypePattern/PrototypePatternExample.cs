namespace PrototypePattern
{
    using System;

    public class PrototypePatternExample
    {
        public static void Main(string[] args)
        {
            var robby = new Robot("Robby");
            Console.WriteLine(robby.ToString());
            var wolly = robby.CloneAnimal();
            wolly.Name = "Wolly";
            Console.WriteLine(wolly.ToString());
        }
    }
}
