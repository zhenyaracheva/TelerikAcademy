namespace ChefTask
{
    using System.Collections.Generic;

    using ChefTask.Products;

    public class Bowl
    {
        private List<Vegetable> vegetables;

        public Bowl()
        {
            this.vegetables = new List<Vegetable>();
        }
        public void Add(Vegetable vegetable)
        {
            this.vegetables.Add(vegetable);
        }
    }
}
