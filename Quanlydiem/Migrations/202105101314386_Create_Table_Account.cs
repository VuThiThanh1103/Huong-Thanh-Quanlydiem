namespace Quanlydiem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Account : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        TenDN = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.TenDN);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accounts");
        }
    }
}
