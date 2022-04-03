using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMovie.Models
{
    public partial class TheLoai
    {
        public TheLoai()
        {
            Phims = new HashSet<Phim>();
        }

        public int IdTheLoai { get; set; }
        public string TenTheLoai { get; set; }

        public virtual ICollection<Phim> Phims { get; set; }
        public virtual ICollection<PhimLive> PhimLives { get; set; }

    }
}
