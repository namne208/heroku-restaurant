using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant.Models
{
    public partial class ThanhToan
    {
        public ThanhToan()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public int MaThanhToan { get; set; }
        public string TrangThaiThanhToan { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
