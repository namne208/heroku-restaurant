using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public int MaSanPham { get; set; }
        public string AnhSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string NguyenLieu { get; set; }
        public string ChiTiet { get; set; }
        public decimal? Tien { get; set; }
        public int? GiamGia { get; set; }
        public int? KichThuoc { get; set; }
        public int? SoLuongSanPham { get; set; }
        public DateTime? NgayNhap { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public int? MaLoaiSanPham { get; set; }
        public int? MaThucDon { get; set; }

        public virtual LoaiSanPham MaLoaiSanPhamNavigation { get; set; }
        public virtual ThucDon MaThucDonNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
