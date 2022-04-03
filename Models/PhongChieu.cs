using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMovie.Models
{
    public partial class PhongChieu
    {
        public PhongChieu()
        {
            ChiTietChieuPhims = new HashSet<ChiTietChieuPhim>();
            ChiTietChoNgois = new HashSet<ChiTietChoNgoi>();
        }

        public int IdPhong { get; set; }
        public string TenPhong { get; set; }

        public virtual ICollection<ChiTietChieuPhim> ChiTietChieuPhims { get; set; }
        public virtual ICollection<ChiTietChoNgoi> ChiTietChoNgois { get; set; }
    }
}
