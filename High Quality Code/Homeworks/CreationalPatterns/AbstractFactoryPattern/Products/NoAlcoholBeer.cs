namespace AbstractFactoryPattern.Products
{
    public class NoAlcoholBeer : Beer
    {
        public NoAlcoholBeer(double alcohol, string madeBy)
            : base(alcohol, madeBy)
        {
        }
    }
}
