namespace ChefTask.Products
{
    public class Vegetable
    {
        public bool IsPeeled { get; set; }
        public bool IsRotten { get; set; }

        public Vegetable()
        {
            this.IsPeeled = false;
            this.IsRotten = false;
        }
    }
}
