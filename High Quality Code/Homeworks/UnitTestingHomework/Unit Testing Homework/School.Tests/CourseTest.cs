namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTest
    {
        private Course course;
        private School school;
        private Student firstTestStudent;
        private Student secondTestStudent;
        private Student thirdTestStudent;

        [TestInitialize]
        public void InitializeDataTest()
        {
            this.course = new Course();
            this.school = new School();
            this.firstTestStudent = new Student("John", this.school);
            this.secondTestStudent = new Student("Johnana", this.school);
            this.thirdTestStudent = new Student("Jahne", this.school);

        }

        [TestMethod]
        public void CreateCourseInitialeStudentsLengthTest()
        {
            var expected = 0;
            Assert.AreEqual(expected, this.course.Students.Count);
        }

        [TestMethod]
        public void AddStudentsTest()
        {
            this.course.AddStudent(this.firstTestStudent);
            this.course.AddStudent(this.secondTestStudent);
            this.course.AddStudent(this.thirdTestStudent);
            var expected = 3;
            Assert.AreEqual(expected, this.course.Students.Count);
        }

        [TestMethod]
        public void RemoveStudentTest()
        {
            this.course.AddStudent(this.firstTestStudent);
            this.course.AddStudent(this.secondTestStudent);
            this.course.RemoveStudent(this.firstTestStudent);
            var expected = 1;
            Assert.AreEqual(expected, this.course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNotExistingStudentTest()
        {
            this.course.AddStudent(this.firstTestStudent);
            this.course.AddStudent(this.secondTestStudent);
            this.course.RemoveStudent(this.thirdTestStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddMoreTham30Students()
        {
            for (int i = 0; i < 31; i++)
            {
                var student = new Student(i.ToString(), this.school);
                this.course.AddStudent(student);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullStudents()
        {
            this.course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReamoveNullStudentTest()
        {
            this.course.AddStudent(this.firstTestStudent);
            this.course.RemoveStudent(null);
        }
    }
}
