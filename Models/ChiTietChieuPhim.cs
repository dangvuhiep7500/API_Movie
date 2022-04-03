using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMovie.Models
{
    public partial class ChiTietChieuPhim
    {
        public ChiTietChieuPhim()
        {
            Ves = new HashSet<Ve>();
        }

        public int IdChiTietChieu { get; set; }
        public int IdPhong { get; set; }
        public int IdPhim { get; set; }
        public DateTime NgayChieu { get; set; }
        public DateTime GioBatDau { get; set; }
        public double GiaVe { get; set; }

   //     public virtual PhongChieu IdPhong1 { get; set; }
        public virtual PhongChieu IdPhongNavigation { get; set; }
        public virtual Phim IdPhimNavigation { get; set; }
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
