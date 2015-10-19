namespace EntityFramework
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            /*01. Using the Visual Studio Entity Framework designer create a DbContext for the Northwind database
              02. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting 
              customers. Write a testing class.*/

            var customer = new Customer
            {
                CustomerID = "Test1",
                CompanyName = "Telerik",
                ContactName = "Pesho"
            };

            var newCustomer = new Customer
            {
                CustomerID = "Test1",
                CompanyName = "TelerikNew",
                ContactName = "Pesho",
            };

            Console.WriteLine("Test Problems 2");
            InsertCustomer(customer);
            Console.WriteLine("-----------------------------------------------");
            ModifyCustomer(newCustomer);
            Console.WriteLine("-----------------------------------------------");
            DeleteCustomer(newCustomer);
            Console.WriteLine("-----------------------------------------------");

            /// 03. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
            Console.WriteLine();
            Console.WriteLine("Test Problems 3");
            FindCustomersByYearOrederAndCountry(1997, "Canada");
            Console.WriteLine("-----------------------------------------------");

            /// 04. Implement previous by using native SQL query and executing it through the DbContext.
            Console.WriteLine();
            Console.WriteLine("Test Problems 4");
            FindCustomersByYearOrederAndCountryNativeSql(1997, "Canada");
            Console.WriteLine("-----------------------------------------------");

            /// 05. Write a method that finds all the sales by specified region and period (start / end dates).
            Console.WriteLine();
            Console.WriteLine("Test Problems 5");
            FindSalesBySpecifiedRegionAndPeriod("BC", new DateTime(1998, 1, 1), DateTime.Now);

            /// 08. By inheriting the Employee entity class create a class which allows employees to access their corresponding territories as property of type EntitySet<T>.
            Console.WriteLine();
            Console.WriteLine("Test Problem 8");
            TestEmployeeTask();
        }

        private static void TestEmployeeTask()
        {
            using (var db = new NorthwindEntities())
            {
                var employees = db.Employees;

                foreach (var empl in employees)
                {
                    Console.WriteLine("Employee: " + empl.FirstName + " " + empl.LastName);
                    Console.Write("Teritories: ");

                    foreach (var item in empl.TerritoriesSet)
                    {
                        Console.Write("{0} ", item.TerritoryDescription.Trim());
                    }

                    Console.WriteLine();
                    Console.WriteLine("---------------------------");
                }
            }
        }

        private static void FindSalesBySpecifiedRegionAndPeriod(string region, DateTime startDate, DateTime endDate)
        {
            using (var db = new NorthwindEntities())
            {
                var index = 1;
                db.Orders
                    .Where(o => o.ShippedDate >= startDate && o.OrderDate <= endDate && o.ShipRegion == region)
                    .Select(o => new { o.Customer.ContactName })
                    .ToList()
                    .ForEach(s => Console.WriteLine("{0}. {1}", index++, s.ContactName));
            }
        }

        private static void FindCustomersByYearOrederAndCountryNativeSql(int year, string country)
        {
            using (var db = new NorthwindEntities())
            {
                var query = @"SELECT * " +
                             "FROM [Northwind].[dbo].[Orders] o " +
                             "INNER JOIN [Northwind].[dbo].Customers c " +
                             "ON o.CustomerID = c.CustomerID " +
                             "WHERE o.ShipCountry = '" + country + "' AND YEAR(o.OrderDate)= " + year +
                             "ORDER BY c.ContactName";

                var index = 1;
                db.Database.SqlQuery<Customer>(query)
                    .Select(s => new { s.ContactName })
                    .ToList()
                    .ForEach(c => Console.WriteLine("{0}. {1}", index++, c.ContactName));
            }
        }

        private static void FindCustomersByYearOrederAndCountry(int year, string country)
        {
            using (var db = new NorthwindEntities())
            {
                var index = 1;
                db.Orders
                    .OrderBy(c => c.Customer.ContactName)
                    .Where(o => (o.ShipCountry == country) && o.OrderDate.Value.Year == year)
                    .Select(s => new
                        {
                            s.Customer.ContactName,
                        })
                    .ToList()
                    .ForEach(c => Console.WriteLine("{0}. {1}", index++, c.ContactName));
            }
        }

        private static void DeleteCustomer(Customer customer)
        {
            using (var db = new NorthwindEntities())
            {
                var customerToRemove = db.Customers
                                 .FirstOrDefault(c => c.CustomerID == customer.CustomerID);

                if (customerToRemove != null)
                {
                    db.Customers.Remove(customerToRemove);
                    SaveChanges(db, "Deleted customer " + customerToRemove.ContactName);
                }
                else
                {
                    Console.WriteLine("Not found customer!");
                }
            }
        }

        private static void ModifyCustomer(Customer updated)
        {
            using (var db = new NorthwindEntities())
            {
                var customerToChange = db.Customers
                                          .FirstOrDefault(x => (x.CustomerID == updated.CustomerID));

                if (customerToChange != null)
                {
                    customerToChange.CustomerID = updated.CustomerID;
                    customerToChange.CustomerDemographics = updated.CustomerDemographics;
                    customerToChange.Country = updated.Country;
                    customerToChange.ContactTitle = updated.ContactTitle;
                    customerToChange.ContactName = updated.ContactName;
                    customerToChange.CompanyName = updated.CompanyName;
                    customerToChange.City = updated.City;
                    customerToChange.Address = updated.Address;
                    customerToChange.Fax = updated.Fax;
                    customerToChange.Orders = updated.Orders;
                    customerToChange.Phone = updated.Phone;
                    customerToChange.PostalCode = updated.PostalCode;
                    customerToChange.Region = updated.Region;

                    SaveChanges(db, "Updated customer: " + updated.ContactName);
                }
                else
                {
                    Console.WriteLine("Does not exist in this database!");
                }
            }
        }

        private static void InsertCustomer(Customer customer)
        {
            using (var db = new NorthwindEntities())
            {
                db.Customers.Add(customer);
                SaveChanges(db, "Added customer: " + customer.ContactName);
            }
        }

        private static void SaveChanges(NorthwindEntities db, string message = null)
        {
            try
            {
                db.SaveChanges();

                if (message != null)
                {
                    Console.WriteLine(message);
                }
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.EntityValidationErrors.ToList()[0].ValidationErrors.ToList()[0].ErrorMessage);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException.InnerException.Message);
            }
        }
    }
}
