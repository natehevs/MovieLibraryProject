using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    public class MovieController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IHttpActionResult Get()
        {
            //LINQ
            var movieList = db.Movies;
            return Ok(movieList);
}
        public IHttpActionResult Get(int id)
        {
            return Ok(db.Movies.Where(m => m.MovieId == id).SingleOrDefault());
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
            List<Movie> movieList = db.Movies.ToList();
            return Ok(movieList);
        }

        // PUT api/values/5
        public IHttpActionResult Put(int? id, [FromBody]Movie movie)
        {
            Movie moviesEdit = db.Movies.Where(s => s.MovieId == id).FirstOrDefault();
            moviesEdit.Title = movie.Title;
            moviesEdit.Genre = movie.Genre;
            moviesEdit.Director = movie.Director;
            db.SaveChanges();
            return Ok(movie);

            // Update movie in db logic
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            Movie movie = db.Movies.Where(m => m.MovieId == id).FirstOrDefault();
            db.Movies.Remove(movie);
            db.SaveChanges();
            List<Movie> movieList = db.Movies.ToList();
            return Ok(movieList);
            // Delete movie from db logic
        }
    }

}