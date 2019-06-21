namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_M_Item", "Condition_Id", c => c.Int(nullable: false));
            AddColumn("dbo.TB_T_Return", "Condition_Id", c => c.Int(nullable: false));
            DropColumn("dbo.TB_T_Return", "Last_Condition");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TB_T_Return", "Last_Condition", c => c.String());
            DropColumn("dbo.TB_T_Return", "Condition_Id");
            DropColumn("dbo.TB_M_Item", "Condition_Id");
        }
    }
}
