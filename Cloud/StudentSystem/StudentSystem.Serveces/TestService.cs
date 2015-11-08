namespace StudentSystem.Serveces
{
    using Contracts;
    using System.Linq;
    using Models;
    using System;
    using Data.Repositories;

    public class TestService : ITestService
    {
        private IGenericRepository<Test> tests;
        private IGenericRepository<Course> courses;

        public TestService(IGenericRepository<Test> testsRepo, IGenericRepository<Course> courses)
        {
            this.tests = testsRepo;
            this.courses = courses;
        }

        public int Add(Test test)
        {
            if (!this.courses.All().Any(x => x.Name == test.Course.Name))
            {
                var course = new Course
                {
                    Name = test.Course.Name,
                    Description = test.Course.Description
                };

                this.courses.Add(course);
                this.courses.SaveChanges();
            }


            var testCourse = this.courses.All().Where(x => x.Name == test.Course.Name).FirstOrDefault();

            var currentTest = new Test
            {
                CourseId = testCourse.Id
            };

            this.tests.Add(currentTest);
            this.tests.SaveChanges();

            return test.Id;
        }

        public IQueryable<Test> All()
        {
            var res = this.tests
                                .All()
                                .AsQueryable();

            return res;
        }
        
        public void Delete(Test test)
        {
            this.tests.Delete(test);
            this.tests.SaveChanges();
        }
    }
}
