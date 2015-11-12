using System.ComponentModel.DataAnnotations;

namespace MusicArtists.Models
{
    public class Country 
    {
        public int CountryId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
