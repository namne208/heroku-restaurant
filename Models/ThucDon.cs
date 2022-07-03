using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant.Models
{
    public partial class ThucDon
    {
        public ThucDon()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int MaThucDon { get; set; }
        public int? TenThucDon { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
