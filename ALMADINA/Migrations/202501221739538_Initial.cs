namespace ALMADINA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamName = c.String(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserTypeId = c.Int(nullable: false),
                        FullName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeesRegisters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(),
                        StudentName = c.String(),
                        FatehrsName = c.String(),
                        MotehrsName = c.String(),
                        LevelOrClassId = c.Int(),
                        SectionId = c.Int(),
                        RollNo = c.String(),
                        FeeTypeId = c.Int(),
                        FeeAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FeeAlreadyRecived = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DueAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cash = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BKash = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Nagad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayandPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reference = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FeeTypes", t => t.FeeTypeId)
                .ForeignKey("dbo.LevelOrClasses", t => t.LevelOrClassId)
                .ForeignKey("dbo.Sections", t => t.SectionId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.StudentId)
                .Index(t => t.LevelOrClassId)
                .Index(t => t.SectionId)
                .Index(t => t.FeeTypeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FeeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LevelOrClassId = c.Int(),
                        SectionId = c.Int(),
                        FeeTypeName = c.String(),
                        FeeAmount = c.Double(nullable: false),
                        LastDate = c.DateTime(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LevelOrClasses", t => t.LevelOrClassId)
                .ForeignKey("dbo.Sections", t => t.SectionId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.LevelOrClassId)
                .Index(t => t.SectionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LevelOrClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LevelOrClassName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudnetName = c.String(),
                        FathersName = c.String(),
                        MothersName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        LevelOrClassId = c.Int(),
                        SectionId = c.Int(),
                        RollNo = c.String(),
                        GenderId = c.Int(nullable: false),
                        ReligionId = c.Int(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                        UserId = c.Int(),
                        PhotoUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.LevelOrClasses", t => t.LevelOrClassId)
                .ForeignKey("dbo.Religions", t => t.ReligionId, cascadeDelete: true)
                .ForeignKey("dbo.Sections", t => t.SectionId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.LevelOrClassId)
                .Index(t => t.SectionId)
                .Index(t => t.GenderId)
                .Index(t => t.ReligionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenderName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Religions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReligionName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Groups", "UserId", "dbo.Users");
            DropForeignKey("dbo.FeesRegisters", "UserId", "dbo.Users");
            DropForeignKey("dbo.FeesRegisters", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "UserId", "dbo.Users");
            DropForeignKey("dbo.Students", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Students", "ReligionId", "dbo.Religions");
            DropForeignKey("dbo.Students", "LevelOrClassId", "dbo.LevelOrClasses");
            DropForeignKey("dbo.Students", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.FeesRegisters", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.FeesRegisters", "LevelOrClassId", "dbo.LevelOrClasses");
            DropForeignKey("dbo.FeesRegisters", "FeeTypeId", "dbo.FeeTypes");
            DropForeignKey("dbo.FeeTypes", "UserId", "dbo.Users");
            DropForeignKey("dbo.FeeTypes", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.FeeTypes", "LevelOrClassId", "dbo.LevelOrClasses");
            DropForeignKey("dbo.Exams", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Groups", new[] { "UserId" });
            DropIndex("dbo.Students", new[] { "UserId" });
            DropIndex("dbo.Students", new[] { "ReligionId" });
            DropIndex("dbo.Students", new[] { "GenderId" });
            DropIndex("dbo.Students", new[] { "SectionId" });
            DropIndex("dbo.Students", new[] { "LevelOrClassId" });
            DropIndex("dbo.FeeTypes", new[] { "UserId" });
            DropIndex("dbo.FeeTypes", new[] { "SectionId" });
            DropIndex("dbo.FeeTypes", new[] { "LevelOrClassId" });
            DropIndex("dbo.FeesRegisters", new[] { "UserId" });
            DropIndex("dbo.FeesRegisters", new[] { "FeeTypeId" });
            DropIndex("dbo.FeesRegisters", new[] { "SectionId" });
            DropIndex("dbo.FeesRegisters", new[] { "LevelOrClassId" });
            DropIndex("dbo.FeesRegisters", new[] { "StudentId" });
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.Exams", new[] { "UserId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Subjects");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Groups");
            DropTable("dbo.Religions");
            DropTable("dbo.Genders");
            DropTable("dbo.Students");
            DropTable("dbo.Sections");
            DropTable("dbo.LevelOrClasses");
            DropTable("dbo.FeeTypes");
            DropTable("dbo.FeesRegisters");
            DropTable("dbo.UserTypes");
            DropTable("dbo.Users");
            DropTable("dbo.Exams");
        }
    }
}
