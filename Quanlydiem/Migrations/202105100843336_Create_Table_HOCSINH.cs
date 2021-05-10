namespace Quanlydiem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_HOCSINH : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diems",
                c => new
                    {
                        bangdiem = c.Int(nullable: false, identity: true),
                        MaHS = c.String(),
                        MaMon = c.String(),
                        DiemMieng = c.String(),
                        DiemMotTiet = c.String(),
                    })
                .PrimaryKey(t => t.bangdiem);
            
            CreateTable(
                "dbo.GIAOVIENS",
                c => new
                    {
                        MaGV = c.String(nullable: false, maxLength: 128),
                        HoTenGV = c.String(),
                        NamSinh = c.Int(nullable: false),
                        MaMon = c.String(),
                        SoDT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaGV);
            
            CreateTable(
                "dbo.HOSSINHS",
                c => new
                    {
                        MaHS = c.String(nullable: false, maxLength: 128),
                        TenHS = c.String(),
                        NamSinh = c.String(),
                        GioiTinh = c.String(),
                        QueQuan = c.String(),
                        Lop = c.String(),
                    })
                .PrimaryKey(t => t.MaHS);
            
            CreateTable(
                "dbo.LOPS",
                c => new
                    {
                        TenLop = c.String(nullable: false, maxLength: 128),
                        Khoi = c.String(),
                        MaGV = c.String(),
                        SiSo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TenLop);
            
            CreateTable(
                "dbo.MONHOCS",
                c => new
                    {
                        MaMon = c.String(nullable: false, maxLength: 128),
                        TenMonHoc = c.String(),
                        SiSo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaMon);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MONHOCS");
            DropTable("dbo.LOPS");
            DropTable("dbo.HOSSINHS");
            DropTable("dbo.GIAOVIENS");
            DropTable("dbo.Diems");
        }
    }
}
