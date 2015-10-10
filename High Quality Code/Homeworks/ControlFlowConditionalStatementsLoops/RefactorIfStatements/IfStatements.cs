namespace RefactorIfStatements
{
    using System;

    using ChefTask;
    using ChefTask.Products;

    public class IfStatements
    {
        private const int MIN_X = 0;
        private const int MIN_Y = 0;
        private const int MAX_X = 100;
        private const int MAX_Y = 100;

        public static void Main(string[] args)
        {
            // Potato potato;
            // //... 
            // if (potato != null)
            //     if (!potato.HasNotBeenPeeled && !potato.IsRotten)
            //         Cook(potato);

            var potato = new Potato();
            var chef = new Chef();

            if (potato != null)
            {
                if (!potato.IsPeeled && !potato.IsRotten)
                {
                    chef.Cook(potato);
                }
            }

            // if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
            // {
            //    VisitCell();
            // }

            var x = 5;
            var y = 1;
            var isVisited = false;

            bool isXInRange = MIN_X <= x && x <= MAX_X;
            bool isYInRange = MIN_Y <= y && y <= MAX_Y;

            if (isXInRange && isYInRange && !isVisited)
            {
                VisitCell();
            }
        }

        private static void VisitCell()
        {
            throw new NotImplementedException();
        }
    }
}
