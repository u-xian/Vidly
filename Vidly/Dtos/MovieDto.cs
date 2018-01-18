using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Released Date")]
        public DateTime ReleasedDate { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public int NumberStock { get; set; }

        public GenreDto Genres { get; set; }


        [Required]
        [Display(Name = "Genre")]
        public int GenreTypesId { get; set; }
    }
}