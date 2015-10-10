namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void CreatingStudentsTest()
        {
            var student = new Student("John", new School());
            var expected = "John: 10000";
            Assert.AreEqual(expected, student.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvalidStudentCreatedTest()
        {
            var student = new Student(null, new School());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvalidStudentSchoolTest()
        {
            var student = new Student("John", null);
        }
    }
}
