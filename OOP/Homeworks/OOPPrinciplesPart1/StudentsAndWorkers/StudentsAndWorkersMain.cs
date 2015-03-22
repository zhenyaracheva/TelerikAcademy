// Problem 2. Students and workers

// Define abstract class Human with first name and last name. Define new class Student which is derived
// from Human and has new field – grade. Define class Worker derived from Human with new property WeekSalary 
// and WorkHoursPerDay and method MoneyPerHour() that returns money earned by hour by the worker. Define the
// proper constructors and properties for this hierarchy.
// Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
// Initialize a list of 10 workers and sort them by money per hour in descending order.
// Merge the lists and sort them by first name and last name.
namespace StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using StudentsAndWorkers.Interfaces;

    public class StudentsAndWorkersMain
    {
        public static void Main()
        {
            var students = new List<IStudent>();
            students.Add(new Student("Ivan", "Lilov", 1));
            students.Add(new Student("Pesho", "Ivanov", 3));
            students.Add(new Student("Gosho", "Goshov", 2));
            students.Add(new Student("Mitko", "Petrov", 5));
            students.Add(new Student("Lila", "Stamatova", 5));
            students.Add(new Student("Magi", "Stoilova", 4));
            students.Add(new Student("Stamat", "Grigorova", 1));
            students.Add(new Student("Svetla", "Ivanova", 3));
            students.Add(new Student("John", "Atanasov", 5));
            students.Add(new Student("Misho", "Ivanov", 3));

            Console.WriteLine("Ordered students by grade:");
            var orderedStudentsByGrade = students.OrderBy(x => x.Grade)
                                                 .ThenBy(x => x.FirstName)
                                                 .ThenBy(x => x.LastName);

            int index = 1;
            foreach (var student in orderedStudentsByGrade)
            {
                Console.WriteLine("{0}. {1} - {2}", index, student.ToString(), student.Grade);
                index++;
            }

            Console.WriteLine();
            var workers = new List<IWorker>();

            Console.WriteLine("Ordered workers by money per hour:");
            workers.Add(new Worker("Ivan", "Ivanov", 125.50m, 8));
            workers.Add(new Worker("Lubo", "Kirov", 100.00m, 5));
            workers.Add(new Worker("Stefan", "Perchemliev", 250.50m, 8));
            workers.Add(new Worker("Rumen", "Rumenov", 90.00m, 3));
            workers.Add(new Worker("Zhana", "Baeva", 100.50m, 8));
            workers.Add(new Worker("Polina", "Gecova", 150.50m, 8));
            workers.Add(new Worker("Margarita", "Ivanova", 175.55m, 6));
            workers.Add(new Worker("Deso", "Georgiev", 130.80m, 8));
            workers.Add(new Worker("Evgeny", "Enchev", 180.50m, 4));
            workers.Add(new Worker("Hristo", "Ikonomov", 600.00m, 7));

            var orederedWorkers = workers.OrderByDescending(x => x.MoneyPerHour());
            index = 1;
            foreach (var worker in orederedWorkers)
            {
                Console.WriteLine("{0}. {1} - {2:F2}", index, worker.ToString(), worker.MoneyPerHour());
                index++;
            }

            var merge = students.Concat<IHuman>(workers)
                                .OrderBy(x => x.FirstName)
                                .ThenBy(x => x.LastName);

            Console.WriteLine();
            Console.WriteLine("Merge and sort students and workers:");

            index = 1;
            foreach (var human in merge)
            {
                Console.WriteLine("{0}. {1} {2}", index, human.FirstName, human.LastName);
                index++;
            }
        }
    }
}
