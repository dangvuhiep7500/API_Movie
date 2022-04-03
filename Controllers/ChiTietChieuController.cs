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
    public class ChiTietChieuController : ControllerBase
    {
        private readonly VeXemPhimContext veXemPhimContext;
        public ChiTietChieuController(VeXemPhimContext veXemPhimContextt)
        {
            veXemPhimContext = veXemPhimContextt;
        }
        // GET: api/<ChiTietChieuController>
        [HttpGet]
        public IEnumerable<ChiTietChieuPhim> Get()
        {
            return veXemPhimContext.ChiTietChieuPhims.Include(x => x.IdPhimNavigation).Include(x => x.IdPhongNavigation).AsNoTracking().OrderByDescending(x=>x.IdChiTietChieu);
        }

        // GET api/<ChiTietChieuController>/5
        [HttpGet("{id}")]
        public ChiTietChieuPhim Get(int id)
        {
            return veXemPhimContext.ChiTietChieuPhims.Include(x => x.IdPhimNavigation).Include(x => x.IdPhongNavigation).AsNoTracking().SingleOrDefault(x => x.IdChiTietChieu == id);
        }
        // POST api/<ChiTietChieuController>
        [HttpPost]
        public void Post([FromBody] ChiTietChieuPhim chiTietChieu)
        {
            veXemPhimContext.ChiTietChieuPhims.Add(chiTietChieu);
            veXemPhimContext.SaveChanges();
        }

        // PUT api/<ChiTietChieuController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ChiTietChieuPhim chiTietChieu)
        {
            chiTietChieu.IdChiTietChieu = id;
            veXemPhimContext.ChiTietChieuPhims.Update(chiTietChieu);
            veXemPhimContext.SaveChanges();
        }

        // DELETE api/<ChiTietChieuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = veXemPhimContext.ChiTietChieuPhims.FirstOrDefault(x => x.IdChiTietChieu == id);
            if (item != null)
            {
                veXemPhimContext.ChiTietChieuPhims.Remove(item);
                veXemPhimContext.SaveChanges();
            }
        }
    }
}
