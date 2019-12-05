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
        // GET api/values
        public IHttpActionResult Get()
        {
            //LINQ
            List<Movie> movieList = db.Movies.ToList();
            return Ok(movieList);
        }
        public IHttpActionResult Get(int id)
        {
            //LINQ
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
            Movie movieList = db.Movies.Where(h => h.MovieId == id).FirstOrDefault();
            movieList.Title = movie.Title;
            movieList.Genre = movie.Genre;
            movieList.Director = movie.Director;
            db.SaveChanges();
            return Ok(movieList);
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