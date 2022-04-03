using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMovie.Models
{
    public partial class Ghe
    {
        public Ghe()
        {
            ChiTietChoNgois = new HashSet<ChiTietChoNgoi>();
        }

        public int IdGhe { get; set; }
        public string TenGhe { get; set; }

        public virtual ICollection<ChiTietChoNgoi> ChiTietChoNgois { get; set; }
    }
}
