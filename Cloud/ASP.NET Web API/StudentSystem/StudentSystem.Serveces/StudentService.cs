namespace StudentSystem.Serveces.Contracts
{
    using System;
    using System.Linq;
    using Data.Repositories;
    using Models;

    public class StudentService : IStudentService
    {
        private IGenericRepository<Student> students;

        public StudentService(IGenericRepository<Student> studentsRepo)
        {
            this.students = studentsRepo;
        }

        public void Add(string firstName, string lastName, int level, string email, string address)
        {
            var student = new Student
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

        public IQueryable<Student> All()
        {
            var res = this.students
                                 .All()
                                 .AsQueryable();

            return res;
        }
        
        public void Delete(Student student)
        {
            this.students.Delete(student);
            this.students.SaveChanges();
        }
    }
}
