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
    public class AdminController : ControllerBase
    {
        private readonly VeXemPhimContext veXemPhimContext;
        public AdminController(VeXemPhimContext veXemPhimContextt)
        {
            veXemPhimContext = veXemPhimContextt;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<Admin> Get()
        {
            return veXemPhimContext.Admins;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public Admin Get(int id)
        {
            return veXemPhimContext.Admins.SingleOrDefault(x => x.IdAdmin == id);
        }
        [HttpGet("{username}/{password}")]
        public Admin login(string username, string password)
        {
            return veXemPhimContext.Admins.SingleOrDefault(x => x.UserName == username && x.Password == password);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] Admin admin)
        {
            veXemPhimContext.Admins.Add(admin);
            veXemPhimContext.SaveChanges();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Admin admin)
        {
            admin.IdAdmin = id;
            veXemPhimContext.Admins.Update(admin);
            veXemPhimContext.SaveChanges();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = veXemPhimContext.Admins.FirstOrDefault(x => x.IdAdmin == id);
            if (item != null)
            {
                veXemPhimContext.Admins.Remove(item);
                veXemPhimContext.SaveChanges();
            }
        }
    }
}
