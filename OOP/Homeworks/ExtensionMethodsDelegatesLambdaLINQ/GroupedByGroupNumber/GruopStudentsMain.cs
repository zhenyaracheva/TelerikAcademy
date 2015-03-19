// Problem 18. Grouped by GroupNumber
// Create a program that extracts all students grouped by GroupNumber and then prints them to the console.
   
// Use LINQ.
// Problem 19. Grouped by GroupName extensions
// Rewrite the previous using extension methods.
namespace GroupedByGroupNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using StudentGroups;

    public class GruopStudentsMain
    {
        public static void Main()
        {
            var students = new List<Student>();
            students.Add(new Student("Pesho", "Peshov", "103684", new Group(2, "Math")));
            students.Add(new Student("Gosho", "Peshov", "158484", new Group(1, "Sport")));
            students.Add(new Student("Petrana", "Stamatova", "007364", new Group(2, "Math")));
            students.Add(new Student("Silana", "Asova", "705481", new Group(1, "Sport")));
            students.Add(new Student("Katq", "Gigova", "103685", new Group(2, "Math")));
            students.Add(new Student("Grigor", "Shumaherov", "123684", new Group(3, "Music")));

            var groupedByGroupNumber = from student in students
                                       orderby student.Group.GroupNumber
                                       group student by student.Group.GroupNumber;

            foreach (var group in groupedByGroupNumber)
            {
                Console.WriteLine("Students from group {0} {1}", group.First().Group.GroupNumber, group.First().Group.DepartmentName);
                PrintStudents(group);
                Console.WriteLine();
            }

            var groupedByGroupName = students.OrderBy(st => st.Group.DepartmentName)
                                             .GroupBy(st => st.Group.DepartmentName);

            foreach (var group in groupedByGroupName)
            {
                Console.WriteLine("Students from group {0} {1}", group.First().Group.GroupNumber, group.First().Group.DepartmentName);
                PrintStudents(group);
                Console.WriteLine();
            }
        }

        public static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                string fullName = student.FirstName + " " + student.LastName;
                Console.WriteLine("{0,-20} | {1} ", fullName, student.FN);
            }
        }
    }
}
