using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quanlydiem.Models
{
    [Table("GIAOVIENS")]
    public class GIAOVIEN
    {
        [Key]
        public String MaGV { get; set; }
        public String HoTenGV { get; set; }
        public int NamSinh { get; set; }
        public String MaMon { get; set; }
        public int SoDT { get; set; }

    }
}