using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Unity_WebAPI_.Controllers
{
    [RoutePrefix("api/Movies")]
    public class MovieController : ApiController
    {
        // GET: api/Movie
        [HttpGet,Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "First Movie", "Second Movie" };
        }
        [HttpGet,Route("{id:int}/actor/{actorid:int}")]
        // GET: api/Movie/5
        public string Get(int id, int actorid)
        {
            return $"Showing actor {actorid} for movie {id}";
        }
        [HttpPost, Route("")]
        // POST: api/Movie
        public void Post([FromBody]string value)
        {
        }
        [HttpPost,Route("{id}")]
        // PUT: api/Movie/5
        public void Put(int id, [FromBody]string value)
        {
        }
        [HttpDelete, Route("{id}")]
        // DELETE: api/Movie/5
        public void Delete(int id)
        {
        }
    }
}
