using BookingMovie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietChoNgoiController : ControllerBase
    {
        private readonly VeXemPhimContext veXemPhimContext;
        public ChiTietChoNgoiController(VeXemPhimContext veXemPhimContextt)
        {
            veXemPhimContext = veXemPhimContextt;
        }
        // GET: api/<ChiTietChieuController>
        [HttpGet]
        public IEnumerable<ChiTietChoNgoi> Get()
        {
            return veXemPhimContext.ChiTietChoNgois.Include(x => x.IdGheNavigation).Include(x => x.IdPhongNavigation);
        }

        // GET api/<ChiTietChieuController>/5
        [HttpGet("{id}")]
        public ChiTietChoNgoi Get(int id)
        {
            return veXemPhimContext.ChiTietChoNgois.Include(x => x.IdGheNavigation).Include(x => x.IdPhongNavigation).AsNoTracking().SingleOrDefault(x => x.IdChoNgoi == id);
        }

        [HttpGet("/phong/{idPhong}")]
        public IEnumerable<ChiTietChoNgoi> GetPhong(int idPhong)
        {
            return veXemPhimContext.ChiTietChoNgois.Include(x => x.IdGheNavigation).Include(x => x.IdPhongNavigation).Where(x => x.IdPhong == idPhong).AsNoTracking().ToList();
        }
        // POST api/<ChiTietChieuController>
        [HttpPost]
        public void Post([FromBody] ChiTietChoNgoi chiTietChoNgoi)
        {
            veXemPhimContext.ChiTietChoNgois.Add(chiTietChoNgoi);
            veXemPhimContext.SaveChanges();
        }
        [HttpPost("/PostGhe")]
        public async Task PostFull(int idPhong, int soGhe)
        {
            
             for (int i = 1; i <=soGhe; i++)
            {
                ChiTietChoNgoi s = new ChiTietChoNgoi();
                s.IdPhong = idPhong;
                s.IdGhe = i;
                Post(s);
                Thread.Sleep(1000);
            }
        }
        // PUT api/<ChiTietChieuController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ChiTietChoNgoi chiTietChoNgoi)
        {
            chiTietChoNgoi.IdChoNgoi = id;
            veXemPhimContext.ChiTietChoNgois.Update(chiTietChoNgoi);
            veXemPhimContext.SaveChanges();
        }

        // DELETE api/<ChiTietChieuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = veXemPhimContext.ChiTietChoNgois.FirstOrDefault(x => x.IdChoNgoi == id);
            if (item != null)
            {
                veXemPhimContext.ChiTietChoNgois.Remove(item);
                veXemPhimContext.SaveChanges();
            }
        }
    }
}
