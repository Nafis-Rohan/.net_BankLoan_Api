namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccTypeId = c.Int(nullable: false),
                        Balance = c.Double(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTypes", t => t.AccTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.AccTypeId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                        Password = c.String(nullable: false, maxLength: 200, unicode: false),
                        Income = c.Double(nullable: false),
                        EId = c.Int(nullable: false),
                        CreditScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employments", t => t.EId, cascadeDelete: true)
                .Index(t => t.EId);
            
            CreateTable(
                "dbo.Employments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoanApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanTypeId = c.Int(nullable: false),
                        PrincipalAmmount = c.Double(nullable: false),
                        InterestRate = c.Double(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        DueDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.LoanTypes", t => t.LoanTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Statuses", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.LoanTypeId)
                .Index(t => t.StatusId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.LoanTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Statuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanApplications", "StatusId", "dbo.Statuses");
            DropForeignKey("dbo.LoanApplications", "LoanTypeId", "dbo.LoanTypes");
            DropForeignKey("dbo.LoanApplications", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.BankAccounts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "EId", "dbo.Employments");
            DropForeignKey("dbo.BankAccounts", "AccTypeId", "dbo.AccountTypes");
            DropIndex("dbo.LoanApplications", new[] { "CustomerId" });
            DropIndex("dbo.LoanApplications", new[] { "StatusId" });
            DropIndex("dbo.LoanApplications", new[] { "LoanTypeId" });
            DropIndex("dbo.Customers", new[] { "EId" });
            DropIndex("dbo.BankAccounts", new[] { "CustomerId" });
            DropIndex("dbo.BankAccounts", new[] { "AccTypeId" });
            DropTable("dbo.Statuses");
            DropTable("dbo.LoanTypes");
            DropTable("dbo.LoanApplications");
            DropTable("dbo.Employments");
            DropTable("dbo.Customers");
            DropTable("dbo.BankAccounts");
            DropTable("dbo.AccountTypes");
        }
    }
}
