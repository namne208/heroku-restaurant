using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant.Models
{
    public partial class GopY
    {
        public int MaGopY { get; set; }
        public string NoiDung { get; set; }
        public int? TinhTrang { get; set; }
        public int? MaKhachHang { get; set; }

        public virtual KhachHang MaKhachHangNavigation { get; set; }
    }
}
