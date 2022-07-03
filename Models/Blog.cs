using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant.Models
{
    public partial class Blog
    {
        public int MaBlog { get; set; }
        public int? Tk { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public DateTime? NgayDang { get; set; }
        public string Anh { get; set; }

        public virtual Admin TkNavigation { get; set; }
    }
}
