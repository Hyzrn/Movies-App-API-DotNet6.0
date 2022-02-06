using MoviesApp.API.Validations;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.API.Dtos
{
    public class GenreCreationDto
    {
        [Required(ErrorMessage = "{0} field is required")]
        [StringLength(5)]
        [FirstLetterUpperCase]
        public string Name { get; set; }
    }
}
