namespace StudentSystem.Serveces
{
    using Models;
    using Contracts;
    using System;
    using System.Linq;
    using Data.Repositories;

    public class HomeworkService : IHomeworkService
    {
        private IGenericRepository<Homework> homeworks;
        private IGenericRepository<Course> courses;
        private IGenericRepository<Student> students;

        public HomeworkService(IGenericRepository<Homework> homeworksRepo, IGenericRepository<Student> studentRepo, IGenericRepository<Course> courseRepo)
        {
            this.homeworks = homeworksRepo;
            this.courses = courseRepo;
            this.students = studentRepo;
        }

        public string Add(string url, string firstName, string lastName, int level, string email, string address, string courseName, string courseDescription)
        {
            var homework = this.homeworks.All()
                                         .Where(x => (x.FileUrl == url))
                                         .FirstOrDefault();
            if (homework == null)
            {
                var student = this.students.All()
                                           .Where(x => (x.AdditionalInformation.Email == email))
                                           .FirstOrDefault();

                if (student == null)
                {
                    student = new Student
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Level = level,
                        AdditionalInformation = new StudentInfo
                        {
                            Email = email,
                            Address = address
                        }
                    };

                    this.students.Add(student);
                    this.students.SaveChanges();
                }

                var course = this.courses.All()
                                    .Where(x => (x.Name == courseName) &&
                                               (x.Description == courseDescription))
                                    .FirstOrDefault();

                if (course == null)
                {
                    course = new Course
                    {
                        Name = courseName,
                        Description = courseDescription
                    };

                    this.courses.Add(course);
                    this.courses.SaveChanges();
                }

                homework = new Homework
                {
                    FileUrl = url,
                    TimeSent = DateTime.Now,
                    CourseId = course.Id,
                    StudentIdentification = student.StudentIdentification
                };

                this.homeworks.Add(homework);
                this.homeworks.SaveChanges();
            }

            return url;
        }

        public IQueryable<Homework> All()
        {
            var res = this.homeworks
                                 .All()
                                 .AsQueryable();

            return res;
        }
        
        public void Delete(string url)
        {
            var homeworkToBeDeleted = this.homeworks.All()
                                                    .Where(x => x.FileUrl == url)
                                                    .FirstOrDefault();
            this.homeworks.Delete(homeworkToBeDeleted);
            this.homeworks.SaveChanges();
        }
    }
}
