namespace MyTunesList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumRating",
                c => new
                    {
                        AlbumRatingId = c.Int(nullable: false, identity: true),
                        AuthorId = c.Guid(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        ReviewComment = c.String(),
                    })
                .PrimaryKey(t => t.AlbumRatingId)
                .ForeignKey("dbo.Album", t => t.AlbumId, cascadeDelete: true)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        AlbumTitle = c.String(nullable: false),
                        ReleaseYear = c.Int(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                        Artist_Band = c.String(nullable: false),
                        SongList = c.String(),
                    })
                .PrimaryKey(t => t.AlbumId);
            
            CreateTable(
                "dbo.Artist_Band",
                c => new
                    {
                        Artist_BandId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FormationYear = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Genre = c.Int(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Artist_BandId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.SingleRating",
                c => new
                    {
                        SingleRatingId = c.Int(nullable: false, identity: true),
                        SingleId = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        ReviewComment = c.String(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SingleRatingId)
                .ForeignKey("dbo.SingleTrack", t => t.SingleId, cascadeDelete: true)
                .Index(t => t.SingleId);
            
            CreateTable(
                "dbo.SingleTrack",
                c => new
                    {
                        SingleId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Genre = c.Int(nullable: false),
                        Artist_Band = c.String(nullable: false),
                        ReleaseDate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SingleId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.SingleRating", "SingleId", "dbo.SingleTrack");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.AlbumRating", "AlbumId", "dbo.Album");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SingleRating", new[] { "SingleId" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.AlbumRating", new[] { "AlbumId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.SingleTrack");
            DropTable("dbo.SingleRating");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Artist_Band");
            DropTable("dbo.Album");
            DropTable("dbo.AlbumRating");
        }
    }
}
