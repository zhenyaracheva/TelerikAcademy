namespace DecoratorPattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SmallPizza : Pizza
    {
        private const double SmallPizzaPrice = 5.00;

        public SmallPizza()
            : base(SmallPizza.SmallPizzaPrice)
        {
        }
    }
}
