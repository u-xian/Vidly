using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<GenreTypes> GenreTypes { get; set; }


        public int? Id { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Released Date")]
        public DateTime? ReleasedDate { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in Stock")]
        public int? NumberStock { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int? GenreTypesId { get; set; }



        public string Title 
        {  
            get 
            {
                return (Id != 0) ? "Edit Movie" : "New Movie";
            } 
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleasedDate = movie.ReleasedDate;
            NumberStock = movie.NumberStock;
            GenreTypesId = movie.GenreTypesId;
        }
    }
}