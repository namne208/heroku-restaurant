using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public int MaHoaDon { get; set; }
        public int? MaKhachHang { get; set; }
        public DateTime? NgayLap { get; set; }
        public decimal? TongTien { get; set; }
        public int? SoLuong { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public int? MaThanhToan { get; set; }
        public int? MaVanChuyen { get; set; }

        public virtual KhachHang MaKhachHangNavigation { get; set; }
        public virtual ThanhToan MaThanhToanNavigation { get; set; }
        public virtual VanChuyen MaVanChuyenNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
