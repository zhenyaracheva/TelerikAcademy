namespace StudentSystem.Web.Controllers
{
    using Serveces.Contracts;
    using Models;
    using System.Linq;
    using System.Web.Http;

    public class HomeworksController : ApiController
    {
        private IHomeworkService homeworkService;

        public HomeworksController(IHomeworkService homeworkService)
        {
            this.homeworkService = homeworkService;
        }

        public IHttpActionResult Get()
        {
            var res = this.homeworkService.All()
                                        .ToList();

            return this.Ok(res);
        }

        public IHttpActionResult Post(HomeworkModel homeworkModel)
        {
            var isAddedStudent = this.homeworkService.All().Any(x =>
                                                        (x.Course.Name == homeworkModel.Course.Name) &&
                                                        (x.FileUrl == homeworkModel.FileUrl) &&
                                                        (x.Student.AdditionalInformation.Email == homeworkModel.Student.AdditionalInformation.Email));

            if (isAddedStudent)
            {
                return this.BadRequest("Homework with file url:" + homeworkModel.FileUrl + " is already added.");
            };

            this.homeworkService.Add(homeworkModel.FileUrl,
                homeworkModel.Student.FirstName, homeworkModel.Student.LastName, homeworkModel.Student.Level,
                homeworkModel.Student.AdditionalInformation.Email, homeworkModel.Student.AdditionalInformation.Address,
                homeworkModel.Course.Name, homeworkModel.Course.Description);

            return this.Ok("Added homework: " + homeworkModel.FileUrl);
        }

        public IHttpActionResult Delete(HomeworkModel homeworkModel)
        {
            var homeworkToDelete = this.homeworkService.All().Where(x =>
                                                        (x.FileUrl == homeworkModel.FileUrl))
                                                        .FirstOrDefault();
            if (homeworkToDelete == null)
            {
                return this.BadRequest("No homework to delete");
            }

            this.homeworkService.Delete(homeworkModel.FileUrl);

            return this.Ok("Homework Deleted");
        }

        public IHttpActionResult Delete(int id)
        {
            var studentToDelete = this.homeworkService.All().Where(x => x.Id == id)
                                                        .FirstOrDefault();
            if (studentToDelete == null)
            {
                return this.BadRequest("No homework to delete");
            }

            this.homeworkService.Delete(studentToDelete.FileUrl);

            return this.Ok("Homework Deleted");
        }
    }
}
