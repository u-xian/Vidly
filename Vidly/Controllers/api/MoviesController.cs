using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.Include(m => m.GenreTypes).ToList();
        }

        //GET /api/movies/1

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return BadRequest();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }


        //POST /api/movie
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto moviedto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(moviedto);

            movie.AddedDate = DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();

            moviedto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" +movie.Id),moviedto);
        }

        //PUT /api/movie/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto moviedto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(moviedto, movieInDb);

            _context.SaveChanges();
        }
        

        //DELETE /api/movie/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
