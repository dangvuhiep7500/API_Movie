using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMovie.Models
{
    public partial class PhimLive
    {
        public PhimLive()
        {
            ChiTietPhimLives = new HashSet<ChiTietPhimLive>();
            
        }

        public int IdPhimLive { get; set; }
        public string TenPhim { get; set; }
        public int IdTheLoai { get; set; }
        public string KeyPhim { get; set; }
        public DateTime GioBatDau { get; set; }
        public string MoTa { get; set; }

        public virtual TheLoai IdTheLoaiNavigation { get; set; }
        public virtual ICollection<ChiTietPhimLive> ChiTietPhimLives { get; set; }
    }
}
