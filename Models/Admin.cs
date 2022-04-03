using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMovie.Models
{
    public partial class Admin
    {
        public int IdAdmin { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
