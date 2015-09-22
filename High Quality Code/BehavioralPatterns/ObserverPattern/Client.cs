namespace ObserverPattern
{
    using System;

    public class Client : IClient
    {
        public Client(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void Update(Product product)
        {
            Console.WriteLine(this.Name + " - " + product.Model + " has new price: " + product.Price);
        }
    }
}
