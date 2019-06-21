namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingFK : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TB_M_Item", "Condition_Id");
            CreateIndex("dbo.TB_T_Return", "Condition_Id");
            AddForeignKey("dbo.TB_M_Item", "Condition_Id", "dbo.TB_M_Condition", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TB_T_Return", "Condition_Id", "dbo.TB_M_Condition", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_T_Return", "Condition_Id", "dbo.TB_M_Condition");
            DropForeignKey("dbo.TB_M_Item", "Condition_Id", "dbo.TB_M_Condition");
            DropIndex("dbo.TB_T_Return", new[] { "Condition_Id" });
            DropIndex("dbo.TB_M_Item", new[] { "Condition_Id" });
        }
    }
}
