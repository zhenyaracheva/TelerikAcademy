namespace StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentGroupsMain
    {
        public static void Main()
        {
            var students = new List<Student>();
            students.Add(new Student("Pesho", "Peshov", "103684", "0898123123", "pesho.reshov@abv.bg", 2));
            students[0].AddStudentMark(6);
            students[0].AddStudentMark(4);
            students[0].AddStudentMark(3);
            students.Add(new Student("Gosho", "Peshov", "158484", "02/123 456", "gebesh@gmail.com", 1));
            students[1].AddStudentMark(2);
            students[1].AddStudentMark(4);
            students.Add(new Student("Petrana", "Stamatova", "007364", "0897456456", "petranova@abv.bg", 2));
            students[2].AddStudentMark(6);
            students[2].AddStudentMark(6);
            students[2].AddStudentMark(5);
            students.Add(new Student("Silana", "Asova", "705481", "(02)123456", "bad_kitty@yahoo.com", 1));
            students[3].AddStudentMark(5);
            students[3].AddStudentMark(4);
            students.Add(new Student("Katq", "Gigova", "103685", "0884159357", "kattina@abv.bg", 2));
            students[4].AddStudentMark(6);
            students.Add(new Student("Grigor", "Shumaherov", "123684", "02-456789", "mashine@abv.bg", 3));
            students[0].AddStudentMark(4);
            students[0].AddStudentMark(4);
            students[0].AddStudentMark(4);

            Console.WriteLine("Students ordered by name using LINQ query:");
            var orderedByName = OrderByNameLinqQuery(students);
            PrintStudents(orderedByName);
            Console.WriteLine();

            Console.WriteLine("Students selected by group 2 using LINQ query:");
            var orderedByGroup = GroupByGroupNumberLinq(students);
            PrintStudents(orderedByGroup);
            Console.WriteLine();

            Console.WriteLine("Students ordered by name using LINQ query:");
            var orderedByNameExtensionLinqQuery = OrderByNameLinqQuery(students);
            PrintStudents(orderedByNameExtensionLinqQuery);
            Console.WriteLine();

            Console.WriteLine("Students ordered by group using extension methods:");
            var orderedByGroupExtension = GroupByGroupNumber(students);
            PrintStudents(orderedByGroupExtension);
            Console.WriteLine();

            Console.WriteLine("Students ordered by name using extension methods:");
            var orderedByNameExtension = OrderByName(students);
            PrintStudents(orderedByNameExtension);
            Console.WriteLine();

            Console.WriteLine("Group students by e-mail in abv.bg using LINQ query:");
            var orderedByEmail = GroupByEmail(students, "abv.bg");
            PrintStudents(orderedByEmail);
            Console.WriteLine();

            Console.WriteLine("Group students by phone numbers in Sofia using LINQ query:");
            var orderedByPhoneNumbers = GroupByPhoneNumber(students);
            PrintStudents(orderedByPhoneNumbers);
            Console.WriteLine();

            Console.WriteLine("Group students by mark 6:");
            var orderedByMark =
                                from student in students
                                where student.Marks.Contains(6)
                                orderby student.FirstName, student.LastName
                                select new
                                        {
                                            FullName = student.FirstName + " " + student.LastName,
                                            Marks = student.Marks
                                        };

            int index = 1;
            foreach (var student in orderedByMark)
            {
                Console.WriteLine("{0} | {1,-20}| {2}", index, student.FullName, string.Join(", ", student.Marks));
                index++;
            }

            Console.WriteLine();

            Console.WriteLine("Group students by 2 marks:");
            var groupedBy2Marks = from student in students
                                  where student.Marks.Count == 2
                                  orderby student.FirstName, student.LastName
                                  select new
                                  {
                                      FullName = student.FirstName + " " + student.LastName,
                                      Marks = student.Marks
                                  };
            index = 1;
            foreach (var student in groupedBy2Marks)
            {
                Console.WriteLine("{0} | {1,-20}| {2}", index, student.FullName, string.Join(", ", student.Marks));
                index++;
            }

            Console.WriteLine();

            var groups = new List<Group>();
            groups.Add(new Group(1, "Computer sience"));
            groups.Add(new Group(2, "Mathematics"));
            groups.Add(new Group(3, "Music"));

            var studentsFromMathDepartment = from mathGroup in groups
                                             where mathGroup.GroupNumber == 2
                                             join student in students on mathGroup.GroupNumber equals student.GroupNumber
                                             orderby student.FirstName, student.LastName
                                             select new
                                             {
                                                 FullName = student.FirstName + " " + student.LastName,
                                                 Department = mathGroup.DepartmentName
                                             };
            Console.WriteLine("Students from math department:");
            index = 1;
            foreach (var student in studentsFromMathDepartment)
            {
                Console.WriteLine("{0} |{1,-20}|{2} ", index, student.FullName, student.Department);
                index++;
            }
        }

        public static IEnumerable<Student> GroupByGroupNumberLinq(List<Student> students)
        {
            var ordered = from student in students
                          where student.GroupNumber == 2
                          orderby student.FirstName, student.LastName
                          select student;

            return ordered;
        }

        public static IEnumerable<Student> OrderByNameLinqQuery(IEnumerable<Student> students)
        {
            var ordered = from student in students
                          orderby student.FirstName, student.LastName
                          select student;

            return ordered;
        }

        public static IEnumerable<Student> GroupByGroupNumber(List<Student> students)
        {
            var ordered = students.Where(st => st.GroupNumber == 2)
                                  .OrderBy(st => st.FirstName)
                                  .ThenBy(st => st.LastName);

            return ordered.ToList();
        }

        public static IEnumerable<Student> GroupByGroupNumberLinqQuery(List<Student> students)
        {
            var ordered = from student in students
                          where student.GroupNumber == 2
                          orderby student.FirstName, student.LastName
                          select student;

            return ordered.ToList();
        }

        public static IEnumerable<Student> OrderByName(IEnumerable<Student> students)
        {
            var ordered = students.OrderBy(st => st.FirstName)
                                  .ThenBy(st => st.LastName);

            return ordered.ToList();
        }

        public static IEnumerable<Student> GroupByEmail(IEnumerable<Student> students, string domain)
        {
            var ordered = students.Where(st => st.Email.EndsWith(domain))
                                  .OrderBy(st => st.FirstName)
                                  .ThenBy(st => st.LastName);
            return ordered;
        }

        public static IEnumerable<Student> GroupByPhoneNumber(IEnumerable<Student> students)
        {
            var ordered = students.Where(st => st.PhoneNumber.StartsWith("02") || st.PhoneNumber.StartsWith("(02"))
                                  .OrderBy(st => st.FirstName)
                                  .ThenBy(st => st.LastName);
            return ordered;
        }

        public static void PrintStudents(IEnumerable<Student> students)
        {
            int index = 1;
            foreach (var student in students)
            {
                string name = student.FirstName + " " + student.LastName;
                Console.WriteLine("{0,-3}| {1,-20} | {2,-6} | {3,-10} | {4,-20} | {5,-2}", index, name, student.FN, student.PhoneNumber, student.Email, student.GroupNumber);
                index++;
            }
        }
    }
}
