namespace DecoratorPattern
{
    public class ChiliSauce : PizzaDecorator
    {
        private const double ChiliSauseInitialPrice = 1.5;

        public ChiliSauce(Pizza pizza)
            : base(pizza, ChiliSauce.ChiliSauseInitialPrice)
        {
        }
    }
}
