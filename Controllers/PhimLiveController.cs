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
    public class PhimLiveController : ControllerBase
    {
        public DateTime now = DateTime.Now;
        VeXemPhimContext veXemPhimContext;
        public PhimLiveController(VeXemPhimContext _veXemPhimContextt)
        {
            veXemPhimContext = _veXemPhimContextt;
        }
        // GET: api/<PhimLiveController>
        [HttpGet]
        public IEnumerable<PhimLive> Get()
        {
            return veXemPhimContext.PhimLives.Include(x => x.IdTheLoaiNavigation).Where(x => x.GioBatDau > now).AsNoTracking().ToList();
        }
        [HttpGet("/full")]
        public IEnumerable<PhimLive> GetFull()
        {
            return veXemPhimContext.PhimLives.Include(x => x.IdTheLoaiNavigation).OrderByDescending(x=>x.IdPhimLive).AsNoTracking().ToList();
        }
        // GET api/<PhimLiveController>/5
        //[HttpGet("{id}")]
        //public PhimLive Get(int id)
        //{
        //    return veXemPhimContext.PhimLives.Include(x => x.IdTheLoaiNavigation).AsNoTracking().SingleOrDefault(x => x.IdPhimLive == id);
        //}

        // POST api/<PhimLiveController>
        [HttpPost]
        public void Post([FromBody] PhimLive phimLive)
        {
            veXemPhimContext.PhimLives.Add(phimLive);
            veXemPhimContext.SaveChanges();
        }

        // PUT api/<PhimLiveController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PhimLive phimLive)
        {
            phimLive.IdPhimLive = id;
            veXemPhimContext.PhimLives.Update(phimLive);
            veXemPhimContext.SaveChanges();
        }

        // DELETE api/<PhimLiveController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = veXemPhimContext.PhimLives.FirstOrDefault(x => x.IdPhimLive == id);
            if (item != null)
            {
                veXemPhimContext.PhimLives.Remove(item);
                veXemPhimContext.SaveChanges();
            }
        }
    }
}
