namespace StudentSystem.Web.Controllers
{
    using Data.Repositories;
    using StudentSystem.Models;
    using System.Web.Http;
    using System.Linq;
    using Models;
    using Serveces;

    public class StudentsController : ApiController
    {
        private IStudentService students;

        public StudentsController(IStudentService studentsRepo)
        {
            this.students = studentsRepo;
        }


        public IHttpActionResult Get()
        {
            var students = this.students.All()
                               .Select(x => new
                               {
                                   FirstName = x.FirstName,
                                   LastName = x.LastName,
                                   Email = x.AdditionalInformation.Email,
                                   Addres = x.AdditionalInformation.Address,
                                   Courses = x.Courses
                               })
                               .ToList();

            return this.Ok(students);
        }

        public IHttpActionResult Post(StudentModel studentModel)
        {
            var isAddedStudent = this.students.All().Any(x =>
                                                        (x.FirstName == studentModel.FirstName) &&
                                                        (x.LastName == studentModel.LastName) &&
                                                        (x.AdditionalInformation.Email == studentModel.AdditionalInformation.Email) &&
                                                        (x.AdditionalInformation.Address == studentModel.AdditionalInformation.Address));

            if (isAddedStudent)
            {
                return this.BadRequest("Student " + studentModel.FirstName + " " + studentModel.LastName + " is already added.");
            }

            this.students.Add(studentModel.FirstName, studentModel.LastName, studentModel.Level, studentModel.AdditionalInformation.Email, studentModel.AdditionalInformation.Address);

            return this.Ok("Added studen " + studentModel.FirstName + " " + studentModel.LastName);
        }

        public IHttpActionResult Delete(StudentModel studentModel)
        {
            var studentToDelete = this.students.All().Where(x =>
                                                        (x.FirstName == studentModel.FirstName) &&
                                                        (x.LastName == studentModel.LastName) &&
                                                        (x.AdditionalInformation.Email == studentModel.AdditionalInformation.Email) &&
                                                        (x.AdditionalInformation.Address == studentModel.AdditionalInformation.Address))
                                                        .FirstOrDefault();
            if (studentToDelete == null)
            {
                return this.BadRequest("No student to be deleted");
            }

            this.students.Delete(studentToDelete);

            return this.Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var studentToDelete = this.students.All().Where(x => x.StudentIdentification == id)
                                                        .FirstOrDefault();
            if (studentToDelete == null)
            {
                return this.BadRequest("No student to be deleted");
            }

            this.students.Delete(studentToDelete);

            return this.Ok();
        }
    }
}
