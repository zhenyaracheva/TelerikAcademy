namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaxCoursStudentsCount = 30;

        private IList<Student> students;

        public Course()
        {
            this.students = new List<Student>();
        }

        public IList<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public void AddStudent(Student student)
        {
            if (this.students.Count >= Course.MaxCoursStudentsCount)
            {
                throw new ArgumentOutOfRangeException("Students in course must be less than " + Course.MaxCoursStudentsCount);
            }

            if (student == null)
            {
                throw new ArgumentNullException("Student cannot be null");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Student cannot be null");
            }

            if (this.students.IndexOf(student) < 0)
            {
                throw new ArgumentException("Student don't exist in this course");
            }

            this.students.Remove(student);
        }
    }
}
