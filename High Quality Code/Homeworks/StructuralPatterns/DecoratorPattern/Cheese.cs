namespace DecoratorPattern
{
    public class Cheese : PizzaDecorator
    {
        private const double CheeseInitialPrice = 3;

        public Cheese(Pizza pizza)
            : base(pizza, Cheese.CheeseInitialPrice)
        {
        }
    }
}
