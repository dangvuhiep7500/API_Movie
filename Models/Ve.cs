using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMovie.Models
{
    public partial class Ve
    {
        public int IdVe { get; set; }
        public int IdUser { get; set; }
        public int IdChoNgoi { get; set; }
        public int IdChiTietChieu { get; set; }

        public virtual ChiTietChieuPhim IdChiTietChieuNavigation { get; set; }
        public virtual ChiTietChoNgoi IdChoNgoiNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
