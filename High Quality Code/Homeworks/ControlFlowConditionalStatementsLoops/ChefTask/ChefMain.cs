namespace ChefTask
{
    using ChefTask.Products;

    public class ChefMain
    {
        public static void Main(string[] args)
        {
            var chef = new Chef();

            var potato = chef.GetPotato();
            chef.Peel(potato);
            chef.Cut(potato);

            var carrot = chef.GetCarrot();
            chef.Peel(carrot);
            chef.Cut(carrot);

            var bowl = chef.GetBowl();
            bowl.Add(potato);
            bowl.Add(carrot);
        }
    }
}
