using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quanlydiem.Models
{
    [Table("HOSSINHS")]
    public class HOCSINH
    {
        [Key]
        public String MaHS { get; set; }
        [AllowHtml]
        public String TenHS { get; set; }
        public string NamSinh { get; set; }
        public string GioiTinh { get; set; }
        public String QueQuan { get; set; }
        public String Lop { get; set; }

    }
}