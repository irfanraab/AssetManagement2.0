namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssetManagementDB : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TB_M_Item", new[] { "Typeitem_Id" });
            CreateIndex("dbo.TB_M_Item", "TypeItem_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TB_M_Item", new[] { "TypeItem_Id" });
            CreateIndex("dbo.TB_M_Item", "Typeitem_Id");
        }
    }
}
