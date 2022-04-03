using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMovie.Models
{
    public partial class ChiTietPhimLive
    {
        public int IdChiTietPhimLive { get; set; }
        public int? IdUser { get; set; }
        public int? IdPhimLive { get; set; }

        public virtual PhimLive IdPhimLiveNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
