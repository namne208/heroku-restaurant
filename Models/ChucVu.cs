using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant.Models
{
    public partial class ChucVu
    {
        public ChucVu()
        {
            KhachHangs = new HashSet<KhachHang>();
        }

        public int MaChucVu { get; set; }
        public string ChucVu1 { get; set; }

        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
