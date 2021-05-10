using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Quanlydiem.Models;

namespace Quanlydiem.Controllers
{
    public class AccountController : Controller
    {
        Encrytion encry = new Encrytion();
        QuanlydiemDbContext db = new QuanlydiemDbContext();
        private string encrtionpass;

        public object FormsAuthemtication { get; private set; }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register (Account acc)
        {
            if (ModelState.IsValid)
            {
                acc.Password = encry.PasswordEncrytion(acc.Password);
                db.Accounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            return View(acc);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(Account acc)
        {
            if (ModelState.IsValid)
            {
                string encrytionpass = encry.PasswordEncrytion(acc.Password);
                var model = db.Accounts.Where(m => m.TenDN == acc.TenDN && m.Password == encrtionpass).ToList().Count();
                if (model == 1)
                {
                     FormsAuthentication.SetAuthCookie(acc.TenDN, true);
                    return RedirectToAction("Index", "Home");
                }    
                else
                {
                    ModelState.AddModelError("", "Thông Tin Đăng Nhập Không Chính Xác");
                }    
            }
            return View(acc);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}