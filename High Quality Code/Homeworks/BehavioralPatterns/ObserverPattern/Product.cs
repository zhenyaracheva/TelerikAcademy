namespace ObserverPattern
{
    using System.Collections.Generic;

    public abstract class Product
    {
        private readonly IList<IClient> clients = new List<IClient>();
        private int price;

        public Product(string model)
        {
            this.Model = model;
        }

        public string Model { get; set; }

        public int Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
                this.Notify();
            }
        }

        public void Attach(IClient client)
        {
            this.clients.Add(client);
        }

        public void Detach(IClient client)
        {
            if (this.clients.Contains(client))
            {
                this.clients.Remove(client);
            }
        }

        public void Notify()
        {
            foreach (var client in this.clients)
            {
                client.Update(this);
            }
        }
    }
}
