using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMovie.Models
{
    public partial class User
    {
        public User()
        {
            ChiTietPhimLives = new HashSet<ChiTietPhimLive>();
            Ves = new HashSet<Ve>();
        }

        public int IdUser { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }

        public virtual ICollection<ChiTietPhimLive> ChiTietPhimLives { get; set; }
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
