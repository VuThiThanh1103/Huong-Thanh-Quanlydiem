namespace Quanlydiem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_GIAOVIEN : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Diems",
                c => new
                    {
                        bangdiem = c.Int(nullable: false, identity: true),
                        MaHS = c.String(maxLength: 128),
                        MaMon = c.String(maxLength: 128),
                        DiemMieng = c.Single(nullable: false),
                        DiemMotTiet = c.Single(nullable: false),
                        Tong = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.bangdiem)
                .ForeignKey("dbo.HOSSINHS", t => t.MaHS)
                .ForeignKey("dbo.MONHOCS", t => t.MaMon)
                .Index(t => t.MaHS)
                .Index(t => t.MaMon);
            
            CreateTable(
                "dbo.HOSSINHS",
                c => new
                    {
                        MaHS = c.String(nullable: false, maxLength: 128),
                        TenHS = c.String(),
                        NamSinh = c.String(),
                        GioiTinh = c.String(),
                        QueQuan = c.String(),
                        MaLop = c.String(),
                    })
                .PrimaryKey(t => t.MaHS);
            
            CreateTable(
                "dbo.LOPS",
                c => new
                    {
                        MaLop = c.String(nullable: false, maxLength: 128),
                        TenLop = c.String(),
                        SiSo = c.String(),
                    })
                .PrimaryKey(t => t.MaLop);
            
            CreateTable(
                "dbo.GIAOVIENS",
                c => new
                    {
                        MaGV = c.String(nullable: false, maxLength: 128),
                        HoTenGV = c.String(),
                        NamSinh = c.Int(nullable: false),
                        MaMon = c.String(maxLength: 128),
                        SoDT = c.String(),
                        MaLop = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaGV)
                .ForeignKey("dbo.LOPS", t => t.MaLop)
                .ForeignKey("dbo.MONHOCS", t => t.MaMon)
                .Index(t => t.MaMon)
                .Index(t => t.MaLop);
            
            CreateTable(
                "dbo.MONHOCS",
                c => new
                    {
                        MaMon = c.String(nullable: false, maxLength: 128),
                        TenMon = c.String(),
                        SoTinChi = c.String(),
                        SiSo = c.String(),
                    })
                .PrimaryKey(t => t.MaMon);
            
            CreateTable(
                "dbo.LOPHOCSINHs",
                c => new
                    {
                        LOP_MaLop = c.String(nullable: false, maxLength: 128),
                        HOCSINH_MaHS = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LOP_MaLop, t.HOCSINH_MaHS })
                .ForeignKey("dbo.LOPS", t => t.LOP_MaLop, cascadeDelete: true)
                .ForeignKey("dbo.HOSSINHS", t => t.HOCSINH_MaHS, cascadeDelete: true)
                .Index(t => t.LOP_MaLop)
                .Index(t => t.HOCSINH_MaHS);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Diems", "MaMon", "dbo.MONHOCS");
            DropForeignKey("dbo.Diems", "MaHS", "dbo.HOSSINHS");
            DropForeignKey("dbo.LOPHOCSINHs", "HOCSINH_MaHS", "dbo.HOSSINHS");
            DropForeignKey("dbo.LOPHOCSINHs", "LOP_MaLop", "dbo.LOPS");
            DropForeignKey("dbo.GIAOVIENS", "MaMon", "dbo.MONHOCS");
            DropForeignKey("dbo.GIAOVIENS", "MaLop", "dbo.LOPS");
            DropIndex("dbo.LOPHOCSINHs", new[] { "HOCSINH_MaHS" });
            DropIndex("dbo.LOPHOCSINHs", new[] { "LOP_MaLop" });
            DropIndex("dbo.GIAOVIENS", new[] { "MaLop" });
            DropIndex("dbo.GIAOVIENS", new[] { "MaMon" });
            DropIndex("dbo.Diems", new[] { "MaMon" });
            DropIndex("dbo.Diems", new[] { "MaHS" });
            DropTable("dbo.LOPHOCSINHs");
            DropTable("dbo.MONHOCS");
            DropTable("dbo.GIAOVIENS");
            DropTable("dbo.LOPS");
            DropTable("dbo.HOSSINHS");
            DropTable("dbo.Diems");
            DropTable("dbo.Accounts");
        }
    }
}
