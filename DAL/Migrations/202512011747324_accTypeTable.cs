namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accTypeTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AccountTypes", newName: "AccTypes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AccTypes", newName: "AccountTypes");
        }
    }
}
