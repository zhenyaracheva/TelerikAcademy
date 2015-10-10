namespace DecoratorPattern
{
    public class Ham : PizzaDecorator
    {
        private const double HamInitialPrice = 2;

        public Ham(Pizza pizza)
            : base(pizza, Ham.HamInitialPrice)
        {   
        }
    }
}
