namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssetManagementDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_T_Procurement", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TB_T_Procurement", "Status");
        }
    }
}
