using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Quanlydiem.Models
{
    public partial class QuanlydiemDbContext : DbContext
    {
        public QuanlydiemDbContext()
            : base("name=QuanlydiemDbContext")
        {
        }

        
        public virtual DbSet<GIAOVIEN> GIAOVIENS { get; set; }
        public virtual DbSet<MONHOC> MONHOCS { get; set; }
        public virtual DbSet<LOP> LOPS { get; set; }
        public virtual DbSet<DIEM> Diems { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<HOCSINH> HOCSINHS { get; set; }
        public object HOCSINHs { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
