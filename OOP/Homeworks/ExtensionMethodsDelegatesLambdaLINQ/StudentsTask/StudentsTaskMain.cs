namespace StudentsTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsTaskMain
    {
        public static void Main()
        {
            var students = new List<Student>();
            students.Add(new Student("John", "Doe", 16));
            students.Add(new Student("Ivan", "Ivanov", 24));
            students.Add(new Student("Ivan", "Ivanov", 21));
            students.Add(new Student("Pesho", "Peshev", 38));
            students.Add(new Student("Atanas", "Boev", 18));
            students.Add(new Student("Johnnie", "Walker", 21));
            students.Add(new Student("Jack", "Daniels", 30));

            Console.WriteLine("Test -> Print first name before last name:");
            var selected = FirstBeforeLastName(students);
            PrintStudents(selected);
            Console.WriteLine();

            Console.WriteLine("Test -> Find the first name and last name of all students with age between 18 and 24.");
            var ageOrdered = AgeRange(students, 18, 24);
            PrintStudents(ageOrdered);
            Console.WriteLine();

            Console.WriteLine("Test -> Sort the students by first name and last name in descending order.");
            var ordered = OrderByDescending(students);
            PrintStudents(ordered);
            Console.WriteLine();

            Console.WriteLine("Test -> Sort the students by first name and last name in descending order second variant.");
            var secondPOrderedMethod = OrderStudentsByDescending(students);
            PrintStudents(secondPOrderedMethod);
        }

        public static IEnumerable<Student> FirstBeforeLastName(IEnumerable<Student> students)
        {
            var ordered = students.Where(s => s.FirstName.First() < s.LastName.First())
                                  .OrderBy(x => x.FirstName)
                                  .ThenBy(s => s.LastName);

            return ordered.ToList();
        }

        public static IEnumerable<Student> AgeRange(IEnumerable<Student> students, int minAge, int maxAge)
        {
            var ordered =
                 from student in students
                 where student.Age >= minAge && student.Age <= maxAge
                 orderby student.FirstName, student.LastName, student.Age
                 select student;

            return ordered;
        }

        public static IEnumerable<Student> OrderByDescending(IEnumerable<Student> students)
        {
            var ordered = students.OrderByDescending(s => s.FirstName)
                                  .ThenBy(s => s.LastName);
            return ordered.ToList();
        }

        public static IEnumerable<Student> OrderStudentsByDescending(IEnumerable<Student> students)
        {
            var ordered = from student in students
                          orderby student.FirstName descending, student.LastName
                          select student;
            return ordered;
        }

        public static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine("{0} {1} - {2}", student.FirstName, student.LastName, student.Age);
            }
        }
    }
}
