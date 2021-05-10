using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quanlydiem.Models
{
    [Table("LOPS")]
    public class LOP
    {
        
        public String Khoi { get; set; }
        [Key]
        public String TenLop { get; set; }
        public String MaGV { get; set; }
        public int SiSo { get; set; }
    }
}