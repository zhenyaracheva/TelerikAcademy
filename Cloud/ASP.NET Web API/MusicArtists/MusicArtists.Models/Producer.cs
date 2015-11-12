using System.ComponentModel.DataAnnotations;

namespace MusicArtists.Models
{
    public class Producer 
    {
        public int ProducerId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
