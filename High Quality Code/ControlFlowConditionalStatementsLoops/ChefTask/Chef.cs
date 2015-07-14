namespace ChefTask
{
    using System;

    using ChefTask.Products;

    public class Chef
    {
        public Bowl GetBowl()
        {
            return new Bowl();
        }

        public Carrot GetCarrot()
        {
            return new Carrot();
        }

        public Potato GetPotato()
        {
            return new Potato();
        }

        public void Cook()
        {
            Console.WriteLine("Cooking!");
        }
        public void Cook(Vegetable vegetable)
        {
            Console.WriteLine("Cooking vegetable!");
        }

        public void Cut(Vegetable vegetable)
        {
            Console.WriteLine("CUT VEGETABLE! ");
        }

        public void Peel(Vegetable vegetable)
        {
            Console.WriteLine("PEEL VEGETABLE! ");
        }
    }
}
