namespace Quanlydiem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_HOCSINH1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HOSSINHS", "MaLop", "dbo.LOPS");
            DropIndex("dbo.HOSSINHS", new[] { "MaLop" });
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
            
            AlterColumn("dbo.HOSSINHS", "MaLop", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LOPHOCSINHs", "HOCSINH_MaHS", "dbo.HOSSINHS");
            DropForeignKey("dbo.LOPHOCSINHs", "LOP_MaLop", "dbo.LOPS");
            DropIndex("dbo.LOPHOCSINHs", new[] { "HOCSINH_MaHS" });
            DropIndex("dbo.LOPHOCSINHs", new[] { "LOP_MaLop" });
            AlterColumn("dbo.HOSSINHS", "MaLop", c => c.String(maxLength: 128));
            DropTable("dbo.LOPHOCSINHs");
            CreateIndex("dbo.HOSSINHS", "MaLop");
            AddForeignKey("dbo.HOSSINHS", "MaLop", "dbo.LOPS", "MaLop");
        }
    }
}
