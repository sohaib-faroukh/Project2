namespace CustomerProfileBank.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "MYDATABASE.CustomerFingerPrints",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FingerPrint = c.String(),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        FingerPrintClassId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.FingerPrintClasses", t => t.FingerPrintClassId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.FingerPrintClassId);
            
            CreateTable(
                "MYDATABASE.Customers",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FirstName = c.String(maxLength: 200),
                        LastName = c.String(maxLength: 200),
                        Address = c.String(maxLength: 200),
                        ISPN = c.String(),
                        Status = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "MYDATABASE.CustomerHobbies",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        HobbyTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.HobbyTypes", t => t.HobbyTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.HobbyTypeId);
            
            CreateTable(
                "MYDATABASE.HobbyTypes",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "MYDATABASE.Numbers",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PhoneNumber = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NumberTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.NumberTypes", t => t.NumberTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.NumberTypeId);
            
            CreateTable(
                "MYDATABASE.NumberTypes",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "MYDATABASE.Services",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        IsActive = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ServiceTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.ServiceTypes", t => t.ServiceTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ServiceTypeId);
            
            CreateTable(
                "MYDATABASE.ServiceTypes",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "MYDATABASE.FingerPrintClasses",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "MYDATABASE.Privileges",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        RoleId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        PrivilegeTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.PrivilegeTypes", t => t.PrivilegeTypeId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.PrivilegeTypeId);
            
            CreateTable(
                "MYDATABASE.PrivilegeTypes",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "MYDATABASE.Roles",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(maxLength: 200),
                        User_Id = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "MYDATABASE.Question_Orders",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Order = c.Decimal(nullable: false, precision: 10, scale: 0),
                        QuestionId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SurveyId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.Surveys", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "MYDATABASE.Questions",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Text = c.String(maxLength: 500),
                        IsActive = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Updated = c.DateTime(nullable: false),
                        Survey_Id = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.Surveys", t => t.Survey_Id)
                .Index(t => t.Survey_Id);
            
            CreateTable(
                "MYDATABASE.Surveys",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(maxLength: 200),
                        Description = c.String(maxLength: 500),
                        Updated = c.DateTime(nullable: false),
                        IsActive = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CreatedBy = c.Decimal(nullable: false, precision: 10, scale: 0),
                        User_Id = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "MYDATABASE.Users",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FullName = c.String(maxLength: 200),
                        IsActive = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ManagerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.Users", t => t.ManagerId)
                .Index(t => t.ManagerId);
            
            CreateTable(
                "MYDATABASE.Responses",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Answer = c.String(maxLength: 500),
                        Survey_ResponseId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        QuestionId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.Survey_Responses", t => t.Survey_ResponseId, cascadeDelete: true)
                .Index(t => t.Survey_ResponseId)
                .Index(t => t.QuestionId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "MYDATABASE.Survey_Responses",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Updated = c.DateTime(nullable: false),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SurveyId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.Surveys", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "MYDATABASE.Role_Users",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        UserId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        RoleId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "MYDATABASE.UserFingerPrints",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FingerPrint = c.String(),
                        UserId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        FingerPrintClassId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.FingerPrintClasses", t => t.FingerPrintClassId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.FingerPrintClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("MYDATABASE.UserFingerPrints", "UserId", "MYDATABASE.Users");
            DropForeignKey("MYDATABASE.UserFingerPrints", "FingerPrintClassId", "MYDATABASE.FingerPrintClasses");
            DropForeignKey("MYDATABASE.Role_Users", "UserId", "MYDATABASE.Users");
            DropForeignKey("MYDATABASE.Role_Users", "RoleId", "MYDATABASE.Roles");
            DropForeignKey("MYDATABASE.Responses", "Survey_ResponseId", "MYDATABASE.Survey_Responses");
            DropForeignKey("MYDATABASE.Survey_Responses", "SurveyId", "MYDATABASE.Surveys");
            DropForeignKey("MYDATABASE.Survey_Responses", "CustomerId", "MYDATABASE.Customers");
            DropForeignKey("MYDATABASE.Responses", "QuestionId", "MYDATABASE.Questions");
            DropForeignKey("MYDATABASE.Responses", "CustomerId", "MYDATABASE.Customers");
            DropForeignKey("MYDATABASE.Question_Orders", "SurveyId", "MYDATABASE.Surveys");
            DropForeignKey("MYDATABASE.Surveys", "User_Id", "MYDATABASE.Users");
            DropForeignKey("MYDATABASE.Roles", "User_Id", "MYDATABASE.Users");
            DropForeignKey("MYDATABASE.Users", "ManagerId", "MYDATABASE.Users");
            DropForeignKey("MYDATABASE.Questions", "Survey_Id", "MYDATABASE.Surveys");
            DropForeignKey("MYDATABASE.Question_Orders", "QuestionId", "MYDATABASE.Questions");
            DropForeignKey("MYDATABASE.Privileges", "RoleId", "MYDATABASE.Roles");
            DropForeignKey("MYDATABASE.Privileges", "PrivilegeTypeId", "MYDATABASE.PrivilegeTypes");
            DropForeignKey("MYDATABASE.CustomerFingerPrints", "FingerPrintClassId", "MYDATABASE.FingerPrintClasses");
            DropForeignKey("MYDATABASE.CustomerFingerPrints", "CustomerId", "MYDATABASE.Customers");
            DropForeignKey("MYDATABASE.Services", "ServiceTypeId", "MYDATABASE.ServiceTypes");
            DropForeignKey("MYDATABASE.Services", "CustomerId", "MYDATABASE.Customers");
            DropForeignKey("MYDATABASE.Numbers", "NumberTypeId", "MYDATABASE.NumberTypes");
            DropForeignKey("MYDATABASE.Numbers", "CustomerId", "MYDATABASE.Customers");
            DropForeignKey("MYDATABASE.CustomerHobbies", "HobbyTypeId", "MYDATABASE.HobbyTypes");
            DropForeignKey("MYDATABASE.CustomerHobbies", "CustomerId", "MYDATABASE.Customers");
            DropIndex("MYDATABASE.UserFingerPrints", new[] { "FingerPrintClassId" });
            DropIndex("MYDATABASE.UserFingerPrints", new[] { "UserId" });
            DropIndex("MYDATABASE.Role_Users", new[] { "RoleId" });
            DropIndex("MYDATABASE.Role_Users", new[] { "UserId" });
            DropIndex("MYDATABASE.Survey_Responses", new[] { "SurveyId" });
            DropIndex("MYDATABASE.Survey_Responses", new[] { "CustomerId" });
            DropIndex("MYDATABASE.Responses", new[] { "CustomerId" });
            DropIndex("MYDATABASE.Responses", new[] { "QuestionId" });
            DropIndex("MYDATABASE.Responses", new[] { "Survey_ResponseId" });
            DropIndex("MYDATABASE.Users", new[] { "ManagerId" });
            DropIndex("MYDATABASE.Surveys", new[] { "User_Id" });
            DropIndex("MYDATABASE.Questions", new[] { "Survey_Id" });
            DropIndex("MYDATABASE.Question_Orders", new[] { "SurveyId" });
            DropIndex("MYDATABASE.Question_Orders", new[] { "QuestionId" });
            DropIndex("MYDATABASE.Roles", new[] { "User_Id" });
            DropIndex("MYDATABASE.Privileges", new[] { "PrivilegeTypeId" });
            DropIndex("MYDATABASE.Privileges", new[] { "RoleId" });
            DropIndex("MYDATABASE.Services", new[] { "ServiceTypeId" });
            DropIndex("MYDATABASE.Services", new[] { "CustomerId" });
            DropIndex("MYDATABASE.Numbers", new[] { "NumberTypeId" });
            DropIndex("MYDATABASE.Numbers", new[] { "CustomerId" });
            DropIndex("MYDATABASE.CustomerHobbies", new[] { "HobbyTypeId" });
            DropIndex("MYDATABASE.CustomerHobbies", new[] { "CustomerId" });
            DropIndex("MYDATABASE.CustomerFingerPrints", new[] { "FingerPrintClassId" });
            DropIndex("MYDATABASE.CustomerFingerPrints", new[] { "CustomerId" });
            DropTable("MYDATABASE.UserFingerPrints");
            DropTable("MYDATABASE.Role_Users");
            DropTable("MYDATABASE.Survey_Responses");
            DropTable("MYDATABASE.Responses");
            DropTable("MYDATABASE.Users");
            DropTable("MYDATABASE.Surveys");
            DropTable("MYDATABASE.Questions");
            DropTable("MYDATABASE.Question_Orders");
            DropTable("MYDATABASE.Roles");
            DropTable("MYDATABASE.PrivilegeTypes");
            DropTable("MYDATABASE.Privileges");
            DropTable("MYDATABASE.FingerPrintClasses");
            DropTable("MYDATABASE.ServiceTypes");
            DropTable("MYDATABASE.Services");
            DropTable("MYDATABASE.NumberTypes");
            DropTable("MYDATABASE.Numbers");
            DropTable("MYDATABASE.HobbyTypes");
            DropTable("MYDATABASE.CustomerHobbies");
            DropTable("MYDATABASE.Customers");
            DropTable("MYDATABASE.CustomerFingerPrints");
        }
    }
}
