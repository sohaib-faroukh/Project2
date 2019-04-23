namespace CustomerProfileBank.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Change_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SOHAIB.SOHAIB_CUSTOMERFINGERPRINT",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FingerPrint = c.String(),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        FingerPrintClassId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_FINGERPRINTCLASS", t => t.FingerPrintClassId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.FingerPrintClassId);
            
            CreateTable(
                "SOHAIB.SOHAIB_CUSTOMER",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        ISPN = c.String(),
                        Status = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "SOHAIB.SOHAIB_CUSTOMERHOBBY",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        HobbyTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_HOBBYTYPE", t => t.HobbyTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.HobbyTypeId);
            
            CreateTable(
                "SOHAIB.SOHAIB_HOBBYTYPE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "SOHAIB.SOHAIB_NUMBER",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PhoneNumber = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NumberTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_NUMBERTYPE", t => t.NumberTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.NumberTypeId);
            
            CreateTable(
                "SOHAIB.SOHAIB_NUMBERTYPE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "SOHAIB.SOHAIB_SERVICE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        IsActive = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ServiceTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_SERVICETYPE", t => t.ServiceTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ServiceTypeId);
            
            CreateTable(
                "SOHAIB.SOHAIB_SERVICETYPE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "SOHAIB.SOHAIB_FINGERPRINTCLASS",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "SOHAIB.SOHAIB_PRIVILEGE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "SOHAIB.SOHAIB_ROLE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
                        Status = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "SOHAIB.SOHAIB_USER",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        HRId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Alias = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Status = c.String(nullable: false, maxLength: 50),
                        CreationDate = c.DateTime(nullable: false),
                        DeactivationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.HRId, unique: true)
                .Index(t => t.Alias, unique: true);
            
            CreateTable(
                "SOHAIB.SOHAIB_QUESTION_ORDER",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Order = c.Decimal(nullable: false, precision: 10, scale: 0),
                        QuestionId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SurveyId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_QUESTION", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_SURVEY", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "SOHAIB.SOHAIB_QUESTION",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Text = c.String(),
                        IsActive = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Updated = c.DateTime(nullable: false),
                        Survey_Id = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_SURVEY", t => t.Survey_Id)
                .Index(t => t.Survey_Id);
            
            CreateTable(
                "SOHAIB.SOHAIB_SURVEY",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Updated = c.DateTime(nullable: false),
                        IsActive = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CreatedBy = c.Decimal(nullable: false, precision: 10, scale: 0),
                        User_Id = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_USER", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "SOHAIB.SOHAIB_RESPONSE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Answer = c.String(),
                        Survey_ResponseId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        QuestionId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_QUESTION", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_SURVEY_RESPONSE", t => t.Survey_ResponseId, cascadeDelete: true)
                .Index(t => t.Survey_ResponseId)
                .Index(t => t.QuestionId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "SOHAIB.SOHAIB_SURVEY_RESPONSE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Updated = c.DateTime(nullable: false),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SurveyId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_SURVEY", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "SOHAIB.SOHAIB_USERFINGERPRINT",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FingerPrint = c.String(),
                        UserId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        FingerPrintClassId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_FINGERPRINTCLASS", t => t.FingerPrintClassId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_USER", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.FingerPrintClassId);
            
            CreateTable(
                "SOHAIB.RolePrivileges",
                c => new
                    {
                        Role_Id = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Privilege_Id = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Privilege_Id })
                .ForeignKey("SOHAIB.SOHAIB_ROLE", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_PRIVILEGE", t => t.Privilege_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Privilege_Id);
            
            CreateTable(
                "SOHAIB.UserRoles",
                c => new
                    {
                        User_Id = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Role_Id = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id })
                .ForeignKey("SOHAIB.SOHAIB_USER", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_ROLE", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("SOHAIB.SOHAIB_USERFINGERPRINT", "UserId", "SOHAIB.SOHAIB_USER");
            DropForeignKey("SOHAIB.SOHAIB_USERFINGERPRINT", "FingerPrintClassId", "SOHAIB.SOHAIB_FINGERPRINTCLASS");
            DropForeignKey("SOHAIB.SOHAIB_RESPONSE", "Survey_ResponseId", "SOHAIB.SOHAIB_SURVEY_RESPONSE");
            DropForeignKey("SOHAIB.SOHAIB_SURVEY_RESPONSE", "SurveyId", "SOHAIB.SOHAIB_SURVEY");
            DropForeignKey("SOHAIB.SOHAIB_SURVEY_RESPONSE", "CustomerId", "SOHAIB.SOHAIB_CUSTOMER");
            DropForeignKey("SOHAIB.SOHAIB_RESPONSE", "QuestionId", "SOHAIB.SOHAIB_QUESTION");
            DropForeignKey("SOHAIB.SOHAIB_RESPONSE", "CustomerId", "SOHAIB.SOHAIB_CUSTOMER");
            DropForeignKey("SOHAIB.SOHAIB_QUESTION_ORDER", "SurveyId", "SOHAIB.SOHAIB_SURVEY");
            DropForeignKey("SOHAIB.SOHAIB_SURVEY", "User_Id", "SOHAIB.SOHAIB_USER");
            DropForeignKey("SOHAIB.SOHAIB_QUESTION", "Survey_Id", "SOHAIB.SOHAIB_SURVEY");
            DropForeignKey("SOHAIB.SOHAIB_QUESTION_ORDER", "QuestionId", "SOHAIB.SOHAIB_QUESTION");
            DropForeignKey("SOHAIB.UserRoles", "Role_Id", "SOHAIB.SOHAIB_ROLE");
            DropForeignKey("SOHAIB.UserRoles", "User_Id", "SOHAIB.SOHAIB_USER");
            DropForeignKey("SOHAIB.RolePrivileges", "Privilege_Id", "SOHAIB.SOHAIB_PRIVILEGE");
            DropForeignKey("SOHAIB.RolePrivileges", "Role_Id", "SOHAIB.SOHAIB_ROLE");
            DropForeignKey("SOHAIB.SOHAIB_CUSTOMERFINGERPRINT", "FingerPrintClassId", "SOHAIB.SOHAIB_FINGERPRINTCLASS");
            DropForeignKey("SOHAIB.SOHAIB_CUSTOMERFINGERPRINT", "CustomerId", "SOHAIB.SOHAIB_CUSTOMER");
            DropForeignKey("SOHAIB.SOHAIB_SERVICE", "ServiceTypeId", "SOHAIB.SOHAIB_SERVICETYPE");
            DropForeignKey("SOHAIB.SOHAIB_SERVICE", "CustomerId", "SOHAIB.SOHAIB_CUSTOMER");
            DropForeignKey("SOHAIB.SOHAIB_NUMBER", "NumberTypeId", "SOHAIB.SOHAIB_NUMBERTYPE");
            DropForeignKey("SOHAIB.SOHAIB_NUMBER", "CustomerId", "SOHAIB.SOHAIB_CUSTOMER");
            DropForeignKey("SOHAIB.SOHAIB_CUSTOMERHOBBY", "HobbyTypeId", "SOHAIB.SOHAIB_HOBBYTYPE");
            DropForeignKey("SOHAIB.SOHAIB_CUSTOMERHOBBY", "CustomerId", "SOHAIB.SOHAIB_CUSTOMER");
            DropIndex("SOHAIB.UserRoles", new[] { "Role_Id" });
            DropIndex("SOHAIB.UserRoles", new[] { "User_Id" });
            DropIndex("SOHAIB.RolePrivileges", new[] { "Privilege_Id" });
            DropIndex("SOHAIB.RolePrivileges", new[] { "Role_Id" });
            DropIndex("SOHAIB.SOHAIB_USERFINGERPRINT", new[] { "FingerPrintClassId" });
            DropIndex("SOHAIB.SOHAIB_USERFINGERPRINT", new[] { "UserId" });
            DropIndex("SOHAIB.SOHAIB_SURVEY_RESPONSE", new[] { "SurveyId" });
            DropIndex("SOHAIB.SOHAIB_SURVEY_RESPONSE", new[] { "CustomerId" });
            DropIndex("SOHAIB.SOHAIB_RESPONSE", new[] { "CustomerId" });
            DropIndex("SOHAIB.SOHAIB_RESPONSE", new[] { "QuestionId" });
            DropIndex("SOHAIB.SOHAIB_RESPONSE", new[] { "Survey_ResponseId" });
            DropIndex("SOHAIB.SOHAIB_SURVEY", new[] { "User_Id" });
            DropIndex("SOHAIB.SOHAIB_QUESTION", new[] { "Survey_Id" });
            DropIndex("SOHAIB.SOHAIB_QUESTION_ORDER", new[] { "SurveyId" });
            DropIndex("SOHAIB.SOHAIB_QUESTION_ORDER", new[] { "QuestionId" });
            DropIndex("SOHAIB.SOHAIB_USER", new[] { "Alias" });
            DropIndex("SOHAIB.SOHAIB_USER", new[] { "HRId" });
            DropIndex("SOHAIB.SOHAIB_ROLE", new[] { "Name" });
            DropIndex("SOHAIB.SOHAIB_SERVICE", new[] { "ServiceTypeId" });
            DropIndex("SOHAIB.SOHAIB_SERVICE", new[] { "CustomerId" });
            DropIndex("SOHAIB.SOHAIB_NUMBER", new[] { "NumberTypeId" });
            DropIndex("SOHAIB.SOHAIB_NUMBER", new[] { "CustomerId" });
            DropIndex("SOHAIB.SOHAIB_CUSTOMERHOBBY", new[] { "HobbyTypeId" });
            DropIndex("SOHAIB.SOHAIB_CUSTOMERHOBBY", new[] { "CustomerId" });
            DropIndex("SOHAIB.SOHAIB_CUSTOMERFINGERPRINT", new[] { "FingerPrintClassId" });
            DropIndex("SOHAIB.SOHAIB_CUSTOMERFINGERPRINT", new[] { "CustomerId" });
            DropTable("SOHAIB.UserRoles");
            DropTable("SOHAIB.RolePrivileges");
            DropTable("SOHAIB.SOHAIB_USERFINGERPRINT");
            DropTable("SOHAIB.SOHAIB_SURVEY_RESPONSE");
            DropTable("SOHAIB.SOHAIB_RESPONSE");
            DropTable("SOHAIB.SOHAIB_SURVEY");
            DropTable("SOHAIB.SOHAIB_QUESTION");
            DropTable("SOHAIB.SOHAIB_QUESTION_ORDER");
            DropTable("SOHAIB.SOHAIB_USER");
            DropTable("SOHAIB.SOHAIB_ROLE");
            DropTable("SOHAIB.SOHAIB_PRIVILEGE");
            DropTable("SOHAIB.SOHAIB_FINGERPRINTCLASS");
            DropTable("SOHAIB.SOHAIB_SERVICETYPE");
            DropTable("SOHAIB.SOHAIB_SERVICE");
            DropTable("SOHAIB.SOHAIB_NUMBERTYPE");
            DropTable("SOHAIB.SOHAIB_NUMBER");
            DropTable("SOHAIB.SOHAIB_HOBBYTYPE");
            DropTable("SOHAIB.SOHAIB_CUSTOMERHOBBY");
            DropTable("SOHAIB.SOHAIB_CUSTOMER");
            DropTable("SOHAIB.SOHAIB_CUSTOMERFINGERPRINT");
        }
    }
}
