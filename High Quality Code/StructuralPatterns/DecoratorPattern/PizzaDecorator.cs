namespace DecoratorPattern
{
    public abstract class PizzaDecorator : Pizza
    {
        private Pizza currentPizza;

        public PizzaDecorator(Pizza pizza, double price)
            : base(price)
        {
            this.currentPizza = pizza;
            this.Price = price;
        }
        
        public override double GetPrice()
        {
            return this.currentPizza.GetPrice() + this.Price;
        }
    }
}
