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
    public class PhongController : ControllerBase
    {
        private readonly VeXemPhimContext veXemPhimContext;
        public PhongController(VeXemPhimContext veXemPhimContextt)
        {
            veXemPhimContext = veXemPhimContextt;
        }
        // GET: api/<PhongController>
        [HttpGet]
        public IEnumerable<PhongChieu> Get()
        {
            return veXemPhimContext.PhongChieus.OrderByDescending(x=>x.IdPhong);
        }

        // GET api/<PhimController>/5
        [HttpGet("{id}")]
        public PhongChieu Get(int id)
        {
            return veXemPhimContext.PhongChieus.SingleOrDefault(x => x.IdPhong == id);

        }

        // POST api/<PhimController>
        [HttpPost]
        public void Post([FromBody] PhongChieu phong)
        {
            veXemPhimContext.PhongChieus.Add(phong);
            veXemPhimContext.SaveChanges();
        }
        // PUT api/<PhimController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PhongChieu phong)
        {
            phong.IdPhong = id;
            veXemPhimContext.PhongChieus.Update(phong);
            veXemPhimContext.SaveChanges();
        }

        // DELETE api/<PhimController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = veXemPhimContext.PhongChieus.FirstOrDefault(x => x.IdPhong == id);
            if (item != null)
            {
                veXemPhimContext.PhongChieus.Remove(item);
                veXemPhimContext.SaveChanges();
            }
        }
    }
}
