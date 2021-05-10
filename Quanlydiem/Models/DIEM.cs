using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quanlydiem.Models
{
    [Table("Diems")]
    public class DIEM
    {
        [Key]
        public int bangdiem { get; set; }
        public String MaHS { get; set; }
        public String MaMon { get; set; }
        public String DiemMieng { get; set; }
        public String DiemMotTiet { get; set; }
       
    }
}