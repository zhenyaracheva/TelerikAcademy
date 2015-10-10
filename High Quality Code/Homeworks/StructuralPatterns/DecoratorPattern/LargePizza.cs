namespace DecoratorPattern
{
    public class LargePizza : Pizza
    {
        private const double LargePizzaPrice = 8.5;

        public LargePizza()
            : base(LargePizza.LargePizzaPrice)
        {
        }
    }
}