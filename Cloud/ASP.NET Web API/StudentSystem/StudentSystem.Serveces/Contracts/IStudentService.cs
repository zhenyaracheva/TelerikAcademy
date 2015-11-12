namespace StudentSystem.Serveces
{
    using Models;
    using System.Linq;

    public interface IStudentService
    {
        IQueryable<Student> All();

        void Add(string firstName, string lastName, int level, string email, string  address);
        
        void Delete(Student student);
    }
}
