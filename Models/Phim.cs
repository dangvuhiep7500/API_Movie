using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMovie.Models
{
    public partial class Phim
    {
        public Phim()
        {
            ChiTietChieuPhims = new HashSet<ChiTietChieuPhim>();
        }

        public int IdPhim { get; set; }
        public int IdTheLoai { get; set; }
        public string TenPhim { get; set; }
        public string ThoiLuong { get; set; }
        public string Image { get; set; }
        public string Trailer { get; set; }

        public virtual TheLoai IdTheLoaiNavigation { get; set; }
        public virtual ICollection<ChiTietChieuPhim> ChiTietChieuPhims { get; set; }
    }
}
