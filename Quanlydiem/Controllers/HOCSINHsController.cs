using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quanlydiem.Models;

namespace Quanlydiem.Controllers
{
    public class HOCSINHsController : Controller
    {
        private QuanlydiemDbContext db = new QuanlydiemDbContext();

        // GET: HOCSINHs
        public ActionResult Index()
        {
            return View(db.HOCSINHS.ToList());
        }

        // GET: HOCSINHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCSINH hOCSINH = db.HOCSINHS.Find(id);
            if (hOCSINH == null)
            {
                return HttpNotFound();
            }
            return View(hOCSINH);
        }

        // GET: HOCSINHs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HOCSINHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHS,TenHS,NamSinh,GioiTinh,QueQuan,MaLop")] HOCSINH hOCSINH)
        {
            if (ModelState.IsValid)
            {
                db.HOCSINHS.Add(hOCSINH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hOCSINH);
        }

        // GET: HOCSINHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCSINH hOCSINH = db.HOCSINHS.Find(id);
            if (hOCSINH == null)
            {
                return HttpNotFound();
            }
            return View(hOCSINH);
        }

        // POST: HOCSINHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHS,TenHS,NamSinh,GioiTinh,QueQuan,MaLop")] HOCSINH hOCSINH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOCSINH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hOCSINH);
        }

        // GET: HOCSINHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCSINH hOCSINH = db.HOCSINHS.Find(id);
            if (hOCSINH == null)
            {
                return HttpNotFound();
            }
            return View(hOCSINH);
        }

        // POST: HOCSINHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOCSINH hOCSINH = db.HOCSINHS.Find(id);
            db.HOCSINHS.Remove(hOCSINH);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            //dat ten cho file
            string _FileName = "HOCSINH.xls";
            //duong dan luu file
            string _path = Path.Combine(Server.MapPath("~/Uploads/Excels"), _FileName);
            //luu file len server
            file.SaveAs(_path);
            // đọc dữ liệu từ file Excel
            DataTable dt = ReadDataFromExcelFile(_path);
            //CopyDataByBulk(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HOCSINH HS = new HOCSINH();
                HS.MaHS = dt.Rows[i][0].ToString();
                HS.TenHS = dt.Rows[i][1].ToString();
                HS.NamSinh = dt.Rows[i][2].ToString();
                HS.GioiTinh = dt.Rows[i][3].ToString();
                HS.QueQuan = dt.Rows[i][4].ToString();
                HS.MaLop = dt.Rows[i][5].ToString();
                db.HOCSINHS.Add(HS);
                db.SaveChanges(); ;
            }
            return RedirectToAction("Index");
        }
        //doc file excel tra ve du lieu dang datatable
        public DataTable ReadDataFromExcelFile(string filepath)
        {
            string connectionString = "";
            string fileExtention = filepath.Substring(filepath.Length - 4).ToLower();
            if (fileExtention.IndexOf(".xlsx") == 0)
            {
                connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + filepath + ";Extended Properties=\"Excel 12.0 Xml;HDR=NO\"";
            }
            else if (fileExtention.IndexOf(".xls") == 0)
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0";
            }

            // Tạo đối tượng kết nối
            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            DataTable data = null;
            try
            {
                // Mở kết nối
                oledbConn.Open();

                // Tạo đối tượng OleDBCommand và query data từ sheet có tên "Sheet1"
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);

                // Tạo đối tượng OleDbDataAdapter để thực thi việc query lấy dữ liệu từ tập tin excel
                OleDbDataAdapter oleda = new OleDbDataAdapter();

                oleda.SelectCommand = cmd;

                // Tạo đối tượng DataSet để hứng dữ liệu từ tập tin excel
                DataSet ds = new DataSet();

                // Đổ đữ liệu từ tập excel vào DataSet
                oleda.Fill(ds);

                data = ds.Tables[0];
            }
            catch
            {
            }
            finally
            {
                // Đóng chuỗi kết nối
                oledbConn.Close();
            }
            return data;
        }
        private void CopyDataByBulk(DataTable dt)
        {
            //lay ket noi voi database luu trong file webconfig
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["QuanlydiemDbContext"].ConnectionString);
            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
            bulkcopy.DestinationTableName = "HOCSINHs";
            bulkcopy.ColumnMappings.Add(0, "MaHS");
            bulkcopy.ColumnMappings.Add(1, "TenHS");
            bulkcopy.ColumnMappings.Add(2, "NamSinh");
            bulkcopy.ColumnMappings.Add(2, "GioiTinh");
            bulkcopy.ColumnMappings.Add(2, "QueQuan");
            bulkcopy.ColumnMappings.Add(2, "MaLop");
            con.Open();
            bulkcopy.WriteToServer(dt);
            con.Close();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult LayDuLieu()
        {
            //TH1:
            var HOCSINH = (from s in db.HOCSINHS  select s).ToList();
            ViewBag.HOCSINHS = HOCSINH;
            
            return View();
        }
        public ActionResult TimKiem( string strceach)
        {
            //TH1:
            var HOCSINH = (from s in db.HOCSINHS select s).ToList();
            if (!String.IsNullOrEmpty(strceach))
            {
                HOCSINH = HOCSINH.Where(x => x.MaHS.Contains(strceach) || x.TenHS.Contains(strceach)).ToList();
            }    

            return View(HOCSINH);
        }
    }
}
