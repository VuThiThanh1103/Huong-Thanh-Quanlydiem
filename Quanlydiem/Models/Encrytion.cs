using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Quanlydiem.Models
{
    public class Encrytion
    {
        public string PasswordEncrytion (String Password)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Trim(), "MD5");
        }
    }
}