namespace PrsServerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedothercontrollers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                        PartNumber = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 200),
                        Unit = c.String(nullable: false, maxLength: 20),
                        PhotoPath = c.String(nullable: false, maxLength: 200),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 80),
                        State = c.String(nullable: false, maxLength: 2),
                        City = c.String(nullable: false, maxLength: 20),
                        Zip = c.String(nullable: false, maxLength: 5),
                        Email = c.String(nullable: false, maxLength: 80),
                        Phone = c.String(nullable: false, maxLength: 12),
                        IsPreApproved = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "dbo.PurchaseRequestLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseRequestId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quanity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseRequests", t => t.PurchaseRequestId, cascadeDelete: true)
                .Index(t => t.PurchaseRequestId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PurchaseRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Justification = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 180),
                        DeliveryMode = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReasonForRejection = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "Phone", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 80));
            CreateIndex("dbo.Users", "UserName", unique: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseRequestLines", "PurchaseRequestId", "dbo.PurchaseRequests");
            DropForeignKey("dbo.PurchaseRequests", "UserId", "dbo.Users");
            DropForeignKey("dbo.PurchaseRequestLines", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "VendorId", "dbo.Vendors");
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.PurchaseRequests", new[] { "UserId" });
            DropIndex("dbo.PurchaseRequestLines", new[] { "ProductId" });
            DropIndex("dbo.PurchaseRequestLines", new[] { "PurchaseRequestId" });
            DropIndex("dbo.Vendors", new[] { "Code" });
            DropIndex("dbo.Products", new[] { "VendorId" });
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Phone", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            DropTable("dbo.PurchaseRequests");
            DropTable("dbo.PurchaseRequestLines");
            DropTable("dbo.Vendors");
            DropTable("dbo.Products");
        }
    }
}
