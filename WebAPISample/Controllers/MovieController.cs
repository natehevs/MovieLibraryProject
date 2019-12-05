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
        public void Put(int id, [FromBody]string value)
        {
            // Update movie in db logic
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            // Delete movie from db logic
        }
    }

}