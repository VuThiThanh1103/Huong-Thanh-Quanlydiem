using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quanlydiem.Models
{
    [Table("MONHOCS")]
    public class MONHOC
    {
        [Key]
        public String MaMon { get; set; }
        public String TenMonHoc { get; set; }
        public int SiSo { get; set; }
    }
}