using BookingMovie.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GheController : ControllerBase
    {
        private readonly VeXemPhimContext veXemPhimContext;
        public GheController(VeXemPhimContext veXemPhimContextt)
        {
            veXemPhimContext = veXemPhimContextt;
        }
        // GET: api/<GheController>
        [HttpGet]
        public IEnumerable<Ghe> Get()
        {
            return veXemPhimContext.Ghes;
        }

        // GET api/<GheController>/5
        [HttpGet("{id}")]
        public Ghe Get(int id)
        {
            return veXemPhimContext.Ghes.SingleOrDefault(x => x.IdGhe == id);
        }

        // POST api/<GheController>
        [HttpPost]
        public void Post([FromBody] Ghe ghe)
        {
            veXemPhimContext.Ghes.Add(ghe);
            veXemPhimContext.SaveChanges();
        }

        // PUT api/<GheController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Ghe ghe)
        {
            ghe.IdGhe = id;
            veXemPhimContext.Ghes.Update(ghe);
            veXemPhimContext.SaveChanges();
        }

        // DELETE api/<GheController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = veXemPhimContext.Ghes.FirstOrDefault(x => x.IdGhe == id);
            if (item != null)
            {
                veXemPhimContext.Ghes.Remove(item);
                veXemPhimContext.SaveChanges();
            }
        }
    }
}
