using BookingMovie.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly VeXemPhimContext veXemPhimContext;
        public UserController(VeXemPhimContext veXemPhimContextt)
        {
            veXemPhimContext = veXemPhimContextt;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return veXemPhimContext.Users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return veXemPhimContext.Users.SingleOrDefault(x => x.IdUser == id);
        }
        [HttpGet("{username}/{password}")]
        public User login(string username, string password)
        {
            return veXemPhimContext.Users.SingleOrDefault(x => x.TaiKhoan == username && x.MatKhau == password);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            veXemPhimContext.Users.Add(user);
            veXemPhimContext.SaveChanges();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            user.IdUser = id;
            veXemPhimContext.Users.Update(user);
            veXemPhimContext.SaveChanges();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = veXemPhimContext.Users.FirstOrDefault(x => x.IdUser == id);
            if (item != null)
            {
                veXemPhimContext.Users.Remove(item);
                veXemPhimContext.SaveChanges();
            }
        }
        [HttpPut("changePassword")]
        public async Task<IActionResult> ChangePassword(int id, string newPass)
        {
            var user = veXemPhimContext.Users.FirstOrDefault(x => x.IdUser== id);
            if (user == null)
            {
                return NotFound();
            }
            user.MatKhau = newPass;
            veXemPhimContext.Update(user);
            veXemPhimContext.SaveChanges();
            if (user.DiaChi != null)
            {
                try
                {
                    SendMail(user.HoTen, user.DiaChi);
                }
                catch { }
            }
            return CreatedAtAction("Get", new { id = user.IdUser }, user);
        }
        void SendMail(string name, string email)
        {
            MimeMessage message = new MimeMessage();
            using (var client = new SmtpClient())
            {
                message.From.Add(new MailboxAddress("MovieTicket", "khoaanhdang11@gmail.com"));
                //message.From.Add(new MailboxAddress("MovieTicket", "longlong11889909@gmail.com"));
                message.To.Add(new MailboxAddress(name, email));
                message.Subject = "PASSWORD CHANGED";

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = "<p>Your password has been changed on " + DateTime.UtcNow.AddHours(7).ToString("dddd, MMMM d, yyyy hh:mm:ss") + "</p>";
                message.Body = bodyBuilder.ToMessageBody();

                client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                //client.Authenticate("longlong11889909@gmail.com", "Longav123@@");
                client.Authenticate("khoaanhdang11@gmail.com", "gmejtlyjhrmdlbhv");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
