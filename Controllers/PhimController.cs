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
    public class PhimController : ControllerBase
    {
        VeXemPhimContext veXemPhimContext;
        public PhimController(VeXemPhimContext _veXemPhimContextt)
        {
            veXemPhimContext = _veXemPhimContextt;
        }
        // GET: api/<PhimController>
        [HttpGet]
        public IEnumerable<Phim> Get()
        {
            return veXemPhimContext.Phims.Include(x => x.IdTheLoaiNavigation).OrderByDescending(x=>x.IdPhim).AsNoTracking().ToList();
        }

        // GET api/<PhimController>/5
        [HttpGet("{id}")]
        public Phim Get(int id)
        {
            return veXemPhimContext.Phims.Include(x => x.IdTheLoaiNavigation).AsNoTracking().SingleOrDefault(x => x.IdPhim == id);
        }
        // POST api/<PhimController>
        [HttpPost]
        public void Post([FromBody] Phim phim)
        {
            veXemPhimContext.Phims.Add(phim);
            veXemPhimContext.SaveChanges();
        }

        // PUT api/<PhimController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Phim phim)
        {
            phim.IdPhim = id;
            veXemPhimContext.Phims.Update(phim);
            veXemPhimContext.SaveChanges();
        }

        // DELETE api/<PhimController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = veXemPhimContext.Phims.FirstOrDefault(x => x.IdPhim == id);
            if (item != null)
            {
                veXemPhimContext.Phims.Remove(item);
                veXemPhimContext.SaveChanges();
            }
        }
    }
}
