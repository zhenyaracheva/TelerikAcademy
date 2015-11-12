namespace StudentSystem.Serveces.Contracts
{
    using StudentSystem.Models;
    using System.Linq;

    public interface IHomeworkService
    {
        IQueryable<Homework> All();

        string Add(string url, string firstName, string lastName, int level, string email, string address, string name, string description);
        
        void Delete(string url);
    }
}
