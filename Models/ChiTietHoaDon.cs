using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant.Models
{
    public partial class ChiTietHoaDon
    {
        public int MaHoaDon { get; set; }
        public int MaSanPham { get; set; }
        public int? TongTien { get; set; }
        public int? SoLuong { get; set; }

        public virtual HoaDon MaHoaDonNavigation { get; set; }
        public virtual SanPham MaSanPhamNavigation { get; set; }
    }
}
