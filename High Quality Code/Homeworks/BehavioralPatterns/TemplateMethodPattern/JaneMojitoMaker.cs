namespace TemplateMethodPattern
{
    using System;

    public class JaneMojitoMaker : MojitoMaker
    {
        protected override void AddGreenSpices()
        {
            Console.WriteLine("Kopar added");
        }

        protected override void AddSugar()
        {
            Console.WriteLine("White sugar added");
        }

        protected override void AddLime()
        {
            Console.WriteLine("Lemon added");
        }
               
        protected override void AddRum()
        {
            Console.WriteLine("Bad rum added");
        }

        protected override void AddSoda()
        {
            Console.WriteLine("Not fresh soda added");
        }

        protected override void AddIce()
        {
            Console.WriteLine("Ice added");
        }         
    }
}
