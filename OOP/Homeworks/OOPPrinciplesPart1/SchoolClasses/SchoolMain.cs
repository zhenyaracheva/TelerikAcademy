// Problem 1. School classes
// 
// We are given a school. In the school there are classes of students. Each class has a set of teachers. 
// Each teacher teaches a set of disciplines. Students have name and unique class number. 
// Classes have unique text identifier. Teachers have name. Disciplines have name, number of lectures and
// number of exercises. Both teachers and students are people. Students, classes, teachers and disciplines 
// could have optional comments (free text block).
// Your task is to identify the classes (in terms of OOP) and their attributes and operations, encapsulate 
// their fields, define the class hierarchy and create a class diagram with Visual Studio.
namespace SchoolClasses
{
    using System;

    public class SchoolMain
    {
        public static void Main()
        {
            // test creating students:
            Student st = new Student("Student John", 1);
            Console.WriteLine(st.ToString());
            Console.WriteLine();

            // test creating teachers:
            Teacher teach = new Teacher("First Teacher");
            teach.AddDicipline(new Dicipline("First dicipline", 2, 2));
            teach.AddDicipline(new Dicipline("Second dicipline", 1, 1));
            Console.WriteLine(teach.ToString());
            Console.WriteLine();

            // test creating classes: 
            Class cl = new Class("Some class");
            cl.AddTeacher(teach);
            cl.AddTeacher(new Teacher("Second Teacher"));
            cl.AddStudent(st);
            cl.AddStudent(new Student("Second Student", 2));
            Console.WriteLine(cl.ToString());
            Console.WriteLine();

            // test cteating school:
            School school = new School();
            school.AddClass(cl);
            school.AddClass(new Class("Second Class"));
            Console.WriteLine(school.ToString());
        }
    }
}
