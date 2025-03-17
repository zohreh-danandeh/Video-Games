using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGame.Entities
{
    [PrimaryKey ("Id")]
    public class VideoGameEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }

        [Range(1950, 2100, ErrorMessage = "Release Year must be between 1950 and 2100")]
        public int ReleaseYear { get; set; }
    }
}
