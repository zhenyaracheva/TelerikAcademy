using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Web.Models
{
    public class CourseModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}