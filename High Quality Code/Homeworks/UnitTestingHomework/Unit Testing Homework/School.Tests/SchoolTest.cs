namespace School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTest
    {
        private School school;

        [TestInitialize]
        public void InitializeShool()
        {
            this.school = new School();
        }

        [TestMethod]
        public void GetStudentSchoolIdFirstId()
        {
            var expected = 10000;
            var id = this.school.GetStudentSchoolId();
            Assert.AreEqual(expected, id);
        }

        [TestMethod]
        public void Test5StudentId()
        {
            var expected = 10004;
            var id = 0;

            for (int i = 0; i < 5; i++)
            {
                id = this.school.GetStudentSchoolId();
            }

            Assert.AreEqual(expected, id);
        }

        [TestMethod]
        public void GetStudentSchoolIdLastId()
        {
            var id = 0;
            var countToEnd = 89999;
            var expectedId = 99999;

            for (int i = 0; i <= countToEnd; i++)
            {
                id = this.school.GetStudentSchoolId();
            }

            Assert.AreEqual(expectedId, id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetStudentSchoolThrowId()
        {
            var id = 0;
            var outOfRangeCount = 90000;

            for (int i = 0; i <= outOfRangeCount; i++)
            {
                id = this.school.GetStudentSchoolId();
            }
        }
    }
}
