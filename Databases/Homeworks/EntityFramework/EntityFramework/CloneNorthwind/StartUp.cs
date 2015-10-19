namespace CloneNorthwind
{
    using System;
    using System.Linq;
    using System.Data.Entity.Infrastructure;

    public class StartUp
    {
        public static void Main()
        {
            /// 06. Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext.
            Console.WriteLine("TEST TASK 6");
            string sqlSchema;
            using (var northwindContext = new NorthwindEntities())
            {
                var adapter = (IObjectContextAdapter)northwindContext;
                sqlSchema = adapter.ObjectContext.CreateDatabaseScript();
            }

            using (var northwindTwinContext = new NorthwindTwinEntities())
            {
                try
                {
                    northwindTwinContext.Database.ExecuteSqlCommand(sqlSchema);
                    Console.WriteLine("Done...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Tables are already created!");
                }
            }

            /// 07.Try to open two different data contexts and perform concurrent changes on the same records.
            Console.WriteLine();
            Console.WriteLine("TEST TASK 7");
            TestConcurentChanges();
        }

        private static void TestConcurentChanges()
        {
            using (var firstContext = new NorthwindEntities())
            {
                var productToChange = firstContext
                                        .Products
                                        .FirstOrDefault();

                productToChange.ProductName = "I am changed!";
                Console.WriteLine("Product name after first context change: " + productToChange.ProductName);
                firstContext.SaveChanges();

                using (var secondContext = new NorthwindEntities())
                {
                    var productToChange2 = secondContext
                                               .Products
                                               .FirstOrDefault();

                    productToChange2.ProductName = "I am changed again!";
                    Console.WriteLine("Same product name after second context change: " + productToChange2.ProductName);
                    secondContext.SaveChanges();
                }


                var product = firstContext
                                        .Products
                                        .FirstOrDefault();

                Console.WriteLine("Product name in first context after second context change: " + product.ProductName);
            }

            using (var result = new NorthwindEntities())
            {
                var resultProduct = result
                                        .Products
                                        .FirstOrDefault();

                Console.Write("Real result: ");
                Console.WriteLine(resultProduct.ProductName);
            }
        }
    }
}
