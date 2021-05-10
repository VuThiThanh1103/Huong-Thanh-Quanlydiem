namespace Quanlydiem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alter_Table_Account : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "Password", c => c.String());
        }
    }
}
