namespace StudentClass
{
    using System;

    public class StudentClassMain
    {
        static void Main()
        {
            var firstStudent = new Student("Pesho", "Malinov", "Suharov", "123456789", "Some address", "Phone number", "email@gmail.com", 2,
                                            Specialty.ComputerScience, University.TechnicalUniversity, Faculty.IT);

            var secondStudent = new Student("Ivan", "Ivanov", "Ivanov", "145626789", "Some address2", "Phone number2", "email2@gmail.com", 2,
                                            Specialty.ComputerScience, University.TechnicalUniversity, Faculty.IT);

            Console.WriteLine("Test: .ToString():");
            Console.WriteLine(firstStudent.ToString());
            Console.WriteLine(secondStudent.ToString());
            Console.WriteLine();

            Console.WriteLine("Test: .GetHashCode()");
            Console.WriteLine(firstStudent.GetHashCode());
            Console.WriteLine(secondStudent.GetHashCode());

            Console.WriteLine("Test: .Equals()");
            Console.WriteLine(firstStudent.Equals(secondStudent));
            Console.WriteLine();

            Console.WriteLine("Test: == operator");
            Console.WriteLine(firstStudent==secondStudent);
            Console.WriteLine();

            Console.WriteLine("Test: != operator");
            Console.WriteLine(firstStudent != secondStudent);
        }
    }
}
