namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class CoursesExamples
    {
        public static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases", "John Doe", "Enterprise");
            localCourse.AddStudent("Milena");
            localCourse.AddStudent("Todor");
            localCourse.AddStudent("Ivan");
            Console.WriteLine(localCourse);

            var students = new List<string>() { "Thomas", "Ani", "Steve" };
            OffsiteCourse offsiteCourse = new OffsiteCourse("PHP and WordPress Development", "Mario Peshev", students, "Sofia");
            Console.WriteLine(offsiteCourse);
        }
    }
}
