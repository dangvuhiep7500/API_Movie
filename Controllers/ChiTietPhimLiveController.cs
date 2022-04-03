using BookingMovie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietPhimLiveController : ControllerBase
    {
        public DateTime thirtyAgo = DateTime.Now.AddMinutes(120);
        private readonly VeXemPhimContext veXemPhimContext;
        public ChiTietPhimLiveController(VeXemPhimContext veXemPhimContextt)
        {
            veXemPhimContext = veXemPhimContextt;
        }
        // GET: api/<ChiTietPhimLiveController>
        [HttpGet("{id}")]
        public IEnumerable<ChiTietPhimLive> Get(int id)
        {
            return veXemPhimContext.ChiTietPhimLives.Include(x => x.IdPhimLiveNavigation).Include(x => x.IdUserNavigation).Where(x => x.IdUser == id && x.IdPhimLiveNavigation.GioBatDau.AddMinutes(180)>DateTime.Now).AsNoTracking().ToList();

        }

        // GET api/<ChiTietPhimLiveController>/5
        [HttpGet]
        public IEnumerable<ChiTietPhimLive> Get()
        {
            return veXemPhimContext.ChiTietPhimLives.Include(x => x.IdPhimLiveNavigation).Include(x => x.IdUserNavigation).OrderByDescending(x=>x.IdPhimLive).AsNoTracking().ToList();
        }

        // POST api/<ChiTietPhimLiveController>
        [HttpPost]
        public void Post([FromBody] ChiTietPhimLive chiTietPhimLive)
        {
            veXemPhimContext.ChiTietPhimLives.Add(chiTietPhimLive);
            veXemPhimContext.SaveChanges();
        }

        // PUT api/<ChiTietPhimLiveController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ChiTietPhimLive chiTietPhimLive)
        {
                chiTietPhimLive.IdPhimLive = id;
                veXemPhimContext.ChiTietPhimLives.Update(chiTietPhimLive);
                veXemPhimContext.SaveChanges();
           
        }

        // DELETE api/<ChiTietPhimLiveController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = veXemPhimContext.ChiTietPhimLives.FirstOrDefault(x => x.IdPhimLive == id);
            if (item != null)
            {
                veXemPhimContext.ChiTietPhimLives.Remove(item);
                veXemPhimContext.SaveChanges();
            }
        }
    }
}
