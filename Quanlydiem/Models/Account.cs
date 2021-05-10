using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quanlydiem.Models
{
    [Table("Accounts")]
    public class Account
    {
        [Key]
        [Required(ErrorMessage ="Tên Đăng Nhập Không Đúng")]
        public String TenDN { get; set; }
        [Required(ErrorMessage = "Password Không Đúng")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}