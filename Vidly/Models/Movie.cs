using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleasedDate { get; set; }
        public DateTime AddedDate { get; set; }
        public int NumberStock { get; set; }
        public GenreTypes GenreTypes { get; set; }
        public int GenreTypesId { get; set; }
    }
}