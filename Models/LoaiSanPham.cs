using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant.Models
{
    public partial class LoaiSanPham
    {
        public LoaiSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public int MaLoaiSanPham { get; set; }
        public string TenLoaiSanPham { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
