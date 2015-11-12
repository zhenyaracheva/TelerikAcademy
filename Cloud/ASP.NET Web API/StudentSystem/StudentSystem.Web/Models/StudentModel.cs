namespace StudentSystem.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class StudentModel
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public int Level { get; set; }
               
        public StudentInfoModel AdditionalInformation { get; set; }
    }
}