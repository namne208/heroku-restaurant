using System;
using System.Collections.Generic;

#nullable disable

namespace Restaurant.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Blogs = new HashSet<Blog>();
        }

        public int MaTk { get; set; }
        public string Tk { get; set; }
        public string Mk { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
