namespace StudentSystem.Serveces
{
    using System;
    using System.Linq;
    using Models;
    using Contracts;
    using Data.Repositories;

    public class CourseService : ICourseService
    {
        private IGenericRepository<Course> courses;

        public CourseService(IGenericRepository<Course> coursesRepo)
        {
            this.courses = coursesRepo;
        }


        public string Add(string name, string description)
        {
            var course = new Course
            {
                Name = name,
                Description = description
            };

            this.courses.Add(course);
            this.courses.SaveChanges();

            return course.Name;
        }

        public IQueryable<Course> All()
        {
            var res = this.courses
                                 .All()
                                 .AsQueryable();

            return res;
        }

        public IQueryable<Course> ById(string id)
        {
            var res = this.courses.All()
                                  .Where(x => x.Id.ToString() == id)
                                  .AsQueryable();

            return res;
        }

        public void Delete(Course course)
        {
            this.courses.Delete(course);
            this.courses.SaveChanges();
        }
    }
}

