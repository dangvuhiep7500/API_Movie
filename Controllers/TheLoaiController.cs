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
    public class TheLoaiController : ControllerBase
    {
        private readonly VeXemPhimContext veXemPhimContext;
        public TheLoaiController(VeXemPhimContext veXemPhimContextt)
        {
            veXemPhimContext = veXemPhimContextt;
        }
        // GET: api/<TheLoaiController>
        [HttpGet]
        public IEnumerable<TheLoai> Get()
        {
            return veXemPhimContext.TheLoais;
        }

        // GET api/<TheLoaiController>/5
        [HttpGet("{id}")]
        public TheLoai Get(int id)
        {
            return veXemPhimContext.TheLoais.SingleOrDefault(x => x.IdTheLoai == id);
        }

        // POST api/<TheLoaiController>
        [HttpPost]
        public void Post([FromBody] TheLoai theLoai)
        {

            veXemPhimContext.TheLoais.Add(theLoai);
            veXemPhimContext.SaveChanges();
        }

        // PUT api/<TheLoaiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TheLoai theLoai)
        {
            theLoai.IdTheLoai = id;
            veXemPhimContext.TheLoais.Update(theLoai);
            veXemPhimContext.SaveChanges();
        }

        // DELETE api/<TheLoaiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = veXemPhimContext.TheLoais.FirstOrDefault(x => x.IdTheLoai == id);
            if (item != null)
            {
                veXemPhimContext.TheLoais.Remove(item);
                veXemPhimContext.SaveChanges();
            }
        }
    }
}
