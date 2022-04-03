using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMovie.Models
{
    public partial class ChiTietChoNgoi
    {
        public ChiTietChoNgoi()
        {
            Ves = new HashSet<Ve>();
        }

        public int IdChoNgoi { get; set; }
        public int IdPhong { get; set; }
        public int IdGhe { get; set; }

        public virtual Ghe IdGheNavigation { get; set; }
        public virtual PhongChieu IdPhongNavigation { get; set; }
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
