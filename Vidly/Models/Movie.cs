using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Movie Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Released Date")]
        public DateTime ReleasedDate { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        public int NumberStock { get; set; }


        public GenreTypes GenreTypes { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreTypesId { get; set; }
    }
}