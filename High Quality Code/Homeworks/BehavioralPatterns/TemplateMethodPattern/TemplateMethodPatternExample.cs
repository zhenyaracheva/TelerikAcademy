namespace TemplateMethodPattern
{
    using System;

    public class TemplateMethodPatternExample
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("First variant:");
            Console.WriteLine("----------------------------------");
            var johnMojito = new JohnMojitoMaker();
            johnMojito.MakeMojito();

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Second variant");
            Console.WriteLine("----------------------------------");
            var cheapMojito = new JaneMojitoMaker();
            cheapMojito.MakeMojito();
        }
    }
}
