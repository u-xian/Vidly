﻿using System;
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
        public string Name { get; set; }
        [Required]
        public DateTime ReleasedDate { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        [Required]
        public int NumberStock { get; set; }
        [Required]
        public GenreTypes GenreTypes { get; set; }
        [Required]
        public int GenreTypesId { get; set; }
    }
}