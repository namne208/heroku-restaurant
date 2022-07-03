using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            Gopies = new HashSet<GopY>();
            HoaDons = new HashSet<HoaDon>();
        }

        public int MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DiaChi { get; set; }
        public int? MaChucVu { get; set; }

        public virtual ChucVu MaChucVuNavigation { get; set; }
        public virtual ICollection<GopY> Gopies { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
