using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class EmployeeViewModel
    {
        public int CurrenPageIndex { get; set; }
        public int PageCout{ get; private set; }
        public List<SanPham> SanPhamList { get; set; }
       
    }

   


}
