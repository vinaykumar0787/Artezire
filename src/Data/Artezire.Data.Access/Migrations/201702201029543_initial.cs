namespace Artezire.Data.Access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlobTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlobTypeCode = c.Int(nullable: false),
                        BlobTypeDescription = c.String(),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenderCode = c.Int(nullable: false),
                        Description = c.String(),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductBlobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        BlobKey = c.String(),
                        ContainerKey = c.String(),
                        BlobTypeId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlobTypes", t => t.BlobTypeId, cascadeDelete: true)
                .Index(t => t.BlobTypeId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        ProductTypeId = c.Int(nullable: false),
                        ProductStatusId = c.Int(nullable: false),
                        NoOfLikes = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductStatus", t => t.ProductStatusId, cascadeDelete: true)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeId, cascadeDelete: true)
                .Index(t => t.ProductTypeId)
                .Index(t => t.ProductStatusId);
            
            CreateTable(
                "dbo.ProductStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductStatusDescription = c.String(),
                        ProductStatusCode = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductTypeName = c.String(),
                        ProductTypeDescription = c.String(),
                        ProductTypeCode = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProductViews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        NoOfViews = c.Int(nullable: false),
                        IsFavorite = c.Boolean(nullable: false),
                        FirstViewedOn = c.DateTime(nullable: false),
                        LastViewedOn = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        Email = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        CountryCode = c.Int(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        GenderId = c.Int(nullable: false),
                        UserTypeId = c.Int(nullable: false),
                        UserStatusId = c.Int(nullable: false),
                        IsValidUser = c.Short(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.UserStatus", t => t.UserStatusId, cascadeDelete: true)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.GenderId)
                .Index(t => t.UserTypeId)
                .Index(t => t.UserStatusId);
            
            CreateTable(
                "dbo.UserStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserStatusCode = c.Int(nullable: false),
                        UserStatusDescription = c.String(),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserTypeCode = c.Int(nullable: false),
                        UserTypeDescription = c.String(),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProductXrefs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProductXrefs", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserProductXrefs", "ProductId", "dbo.Products");
            DropForeignKey("dbo.UserProductViews", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Users", "UserStatusId", "dbo.UserStatus");
            DropForeignKey("dbo.Users", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.UserProductViews", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes");
            DropForeignKey("dbo.Products", "ProductStatusId", "dbo.ProductStatus");
            DropForeignKey("dbo.ProductBlobs", "BlobTypeId", "dbo.BlobTypes");
            DropIndex("dbo.UserProductXrefs", new[] { "ProductId" });
            DropIndex("dbo.UserProductXrefs", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "UserStatusId" });
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.Users", new[] { "GenderId" });
            DropIndex("dbo.UserProductViews", new[] { "ProductId" });
            DropIndex("dbo.UserProductViews", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "ProductStatusId" });
            DropIndex("dbo.Products", new[] { "ProductTypeId" });
            DropIndex("dbo.ProductBlobs", new[] { "BlobTypeId" });
            DropTable("dbo.UserProductXrefs");
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserStatus");
            DropTable("dbo.Users");
            DropTable("dbo.UserProductViews");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.ProductStatus");
            DropTable("dbo.Products");
            DropTable("dbo.ProductBlobs");
            DropTable("dbo.Genders");
            DropTable("dbo.BlobTypes");
        }
    }
}
