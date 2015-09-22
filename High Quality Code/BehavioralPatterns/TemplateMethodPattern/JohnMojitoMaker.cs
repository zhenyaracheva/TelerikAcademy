namespace TemplateMethodPattern
{
    using System;

    public class JohnMojitoMaker : MojitoMaker
    {
        protected override void AddGreenSpices()
        {
            Console.WriteLine("Menta added");
        }

        protected override void AddSugar()
        {
            Console.WriteLine("Brown sugar added");
        }

        protected override void AddLime()
        {
            Console.WriteLine("Lime added");
        }

        protected override void AddRum()
        {
            Console.WriteLine("Perferct rum added");
        }

        protected override void AddSoda()
        {
            Console.WriteLine("Fresh soda added");
        }

        protected override void AddIce()
        {
            Console.WriteLine("Smashed ice added");
        }
    }
}
