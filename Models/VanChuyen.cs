using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant.Models
{
    public partial class VanChuyen
    {
        public VanChuyen()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public int MaVanChuyen { get; set; }
        public string TrangThaiVanChuyen { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
