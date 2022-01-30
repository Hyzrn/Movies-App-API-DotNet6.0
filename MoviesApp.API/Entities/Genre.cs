using MoviesApp.API.Validations;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.API.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(50)]
        [FirstLetterUpperCase]
        public string Name { get; set; }
    }
}
