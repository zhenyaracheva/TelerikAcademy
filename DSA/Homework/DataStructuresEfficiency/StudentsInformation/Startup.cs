namespace StudentsInformation
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            var path = "../../students.txt";
            var studentsReader = File.ReadAllLines(path);
            var students = new SortedDictionary<string, SortedSet<Student>>();

            for (int i = 0; i < studentsReader.Length; i++)
            {
                var studentInfo = studentsReader[i].Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                var student = new Student(studentInfo[0].Trim(), studentInfo[1].Trim(), studentInfo[2].Trim());

                if (!students.ContainsKey(student.Course))
                {
                    students[student.Course] = new SortedSet<Student>();
                }

                students[student.Course].Add(student);
            }

            foreach (var student in students)
            {
                Console.WriteLine("{0}: {1}", student.Key, string.Join(", ", student.Value));
            }
        }
    }
}
