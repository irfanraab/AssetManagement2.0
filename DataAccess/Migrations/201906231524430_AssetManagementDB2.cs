namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssetManagementDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_M_Condition", "Condition_Name", c => c.String());
            DropColumn("dbo.TB_M_Condition", "Conditon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TB_M_Condition", "Conditon", c => c.String());
            DropColumn("dbo.TB_M_Condition", "Condition_Name");
        }
    }
}
