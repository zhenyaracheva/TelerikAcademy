namespace ObserverPattern
{
    public class ObserverPatternExample
    {
        public static void Main(string[] args)
        {
            var client1 = new Client("Jane");

            var bike = new Bike("Cube");
            bike.Attach(client1);
            bike.Price = 5000;

            var client2 = new Client("John");
            bike.Attach(client2);
            bike.Price = 7000;

            var client3 = new Client("John Doe");
            bike.Attach(client3);
            bike.Detach(client2);
            bike.Price = 5500;
        }
    }
}
