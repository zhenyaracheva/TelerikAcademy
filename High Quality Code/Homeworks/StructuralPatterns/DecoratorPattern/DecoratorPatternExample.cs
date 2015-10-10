namespace DecoratorPattern
{
    using System;

    public class DecoratorPatternExample
    {
        public static void Main(string[] args)
        {
            var pizza = new LargePizza();
            Console.WriteLine("Just pizza price: " + pizza.GetPrice());

            var hamPizza = new Ham(pizza);
            Console.WriteLine("Pizza with ham: " + hamPizza.GetPrice());

            var hamCheesePizza = new Cheese(hamPizza);
            Console.WriteLine("Pizza with ham and cheese: " + hamCheesePizza.GetPrice());

            var hamCheesePizzaPlusChili = new ChiliSauce(hamCheesePizza);
            Console.WriteLine("Pizza with ham, cheese and chili: " + hamCheesePizzaPlusChili.GetPrice());
        }
    }
}
