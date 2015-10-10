namespace DecoratorPattern
{
    using System;
    using System.Collections.Generic;

    public abstract class Pizza
    {
        private double price;

        public Pizza(double price)
        {
            this.Price = price;
        }
        
        public double Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0.00)
                {
                    throw new ArgumentOutOfRangeException("Pizza price cannot be less or equal to 0");
                }

                this.price = value;
            }
        }
              
        public virtual double GetPrice()
        {
            return this.Price;
        }
    }
}
