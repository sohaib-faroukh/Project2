namespace CustomerProfileBank.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "MYDATABASE.MYDATABASE_ANSWER",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Text = c.String(),
                        SurveyResponseId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        QuestionId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.MYDATABASE_QUESTION", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.MYDATABASE_SURVEYRESPONSE", t => t.SurveyResponseId, cascadeDelete: true)
                .Index(t => t.SurveyResponseId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_QUESTION",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Text = c.String(nullable: false, maxLength: 250),
                        ParentQuestionId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ParentOptionId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Type = c.String(),
                        Status = c.String(),
                        Option_Id = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.MYDATABASE_OPTION", t => t.Option_Id)
                .ForeignKey("MYDATABASE.MYDATABASE_OPTION", t => t.ParentOptionId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.MYDATABASE_QUESTION", t => t.ParentQuestionId)
                .Index(t => t.ParentQuestionId)
                .Index(t => t.ParentOptionId)
                .Index(t => t.Option_Id);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_OPTION",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Text = c.String(nullable: false, maxLength: 200),
                        Order = c.Decimal(precision: 10, scale: 0),
                        IsDefault = c.Decimal(precision: 1, scale: 0),
                        ParentQuestionId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Question_Id = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.MYDATABASE_QUESTION", t => t.ParentQuestionId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.MYDATABASE_QUESTION", t => t.Question_Id)
                .Index(t => t.ParentQuestionId)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_SURVEYQUESTION",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Order = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IsMandatory = c.Decimal(nullable: false, precision: 1, scale: 0),
                        SurveyId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        QuestionId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.MYDATABASE_QUESTION", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.MYDATABASE_SURVEY", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.SurveyId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_SURVEY",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 100),
                        creationDate = c.DateTime(nullable: false),
                        ValidiatyMonthlyPeriod = c.Decimal(nullable: false, precision: 10, scale: 0),
                        FromDate = c.DateTime(),
                        ToDate = c.DateTime(),
                        Status = c.String(),
                        CreatorId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.MYDATABASE_USER", t => t.CreatorId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_USER",
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
                "MYDATABASE.MYDATABASE_ROLE",
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
                "MYDATABASE.MYDATABASE_PRIVILEGE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_SURVEYRESPONSE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        RespondDateTime = c.DateTime(nullable: false),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SurveyId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.MYDATABASE_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.MYDATABASE_SURVEY", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_CUSTOMER",
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
                "MYDATABASE.MYDATABASE_CUSTOMERHOBBY",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        HobbyTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.MYDATABASE_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.MYDATABASE_HOBBYTYPE", t => t.HobbyTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.HobbyTypeId);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_HOBBYTYPE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_NUMBER",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PhoneNumber = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NumberTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.MYDATABASE_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.MYDATABASE_NUMBERTYPE", t => t.NumberTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.NumberTypeId);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_NUMBERTYPE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_SERVICE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        IsActive = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ServiceTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.MYDATABASE_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.MYDATABASE_SERVICETYPE", t => t.ServiceTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ServiceTypeId);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_SERVICETYPE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_CUSTOMERFINGERPRINT",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FingerPrint = c.String(),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        FingerPrintClassId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.MYDATABASE_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.MYDATABASE_FINGERPRINTCLASS", t => t.FingerPrintClassId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.FingerPrintClassId);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_FINGERPRINTCLASS",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_USERFINGERPRINT",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FingerPrint = c.String(),
                        UserId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        FingerPrintClassId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("MYDATABASE.MYDATABASE_FINGERPRINTCLASS", t => t.FingerPrintClassId, cascadeDelete: true)
                .ForeignKey("MYDATABASE.MYDATABASE_USER", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.FingerPrintClassId);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_ROLEPRIVILEGES",
                c => new
                    {
                        Role_Id = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Privilege_Id = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Privilege_Id })
                .ForeignKey("MYDATABASE.MYDATABASE_ROLE", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("MYDATABASE.MYDATABASE_PRIVILEGE", t => t.Privilege_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Privilege_Id);
            
            CreateTable(
                "MYDATABASE.MYDATABASE_USERROLES",
                c => new
                    {
                        User_Id = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Role_Id = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id })
                .ForeignKey("MYDATABASE.MYDATABASE_USER", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("MYDATABASE.MYDATABASE_ROLE", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("MYDATABASE.MYDATABASE_USERFINGERPRINT", "UserId", "MYDATABASE.MYDATABASE_USER");
            DropForeignKey("MYDATABASE.MYDATABASE_USERFINGERPRINT", "FingerPrintClassId", "MYDATABASE.MYDATABASE_FINGERPRINTCLASS");
            DropForeignKey("MYDATABASE.MYDATABASE_CUSTOMERFINGERPRINT", "FingerPrintClassId", "MYDATABASE.MYDATABASE_FINGERPRINTCLASS");
            DropForeignKey("MYDATABASE.MYDATABASE_CUSTOMERFINGERPRINT", "CustomerId", "MYDATABASE.MYDATABASE_CUSTOMER");
            DropForeignKey("MYDATABASE.MYDATABASE_ANSWER", "SurveyResponseId", "MYDATABASE.MYDATABASE_SURVEYRESPONSE");
            DropForeignKey("MYDATABASE.MYDATABASE_SURVEYRESPONSE", "SurveyId", "MYDATABASE.MYDATABASE_SURVEY");
            DropForeignKey("MYDATABASE.MYDATABASE_SURVEYRESPONSE", "CustomerId", "MYDATABASE.MYDATABASE_CUSTOMER");
            DropForeignKey("MYDATABASE.MYDATABASE_SERVICE", "ServiceTypeId", "MYDATABASE.MYDATABASE_SERVICETYPE");
            DropForeignKey("MYDATABASE.MYDATABASE_SERVICE", "CustomerId", "MYDATABASE.MYDATABASE_CUSTOMER");
            DropForeignKey("MYDATABASE.MYDATABASE_NUMBER", "NumberTypeId", "MYDATABASE.MYDATABASE_NUMBERTYPE");
            DropForeignKey("MYDATABASE.MYDATABASE_NUMBER", "CustomerId", "MYDATABASE.MYDATABASE_CUSTOMER");
            DropForeignKey("MYDATABASE.MYDATABASE_CUSTOMERHOBBY", "HobbyTypeId", "MYDATABASE.MYDATABASE_HOBBYTYPE");
            DropForeignKey("MYDATABASE.MYDATABASE_CUSTOMERHOBBY", "CustomerId", "MYDATABASE.MYDATABASE_CUSTOMER");
            DropForeignKey("MYDATABASE.MYDATABASE_ANSWER", "QuestionId", "MYDATABASE.MYDATABASE_QUESTION");
            DropForeignKey("MYDATABASE.MYDATABASE_SURVEYQUESTION", "SurveyId", "MYDATABASE.MYDATABASE_SURVEY");
            DropForeignKey("MYDATABASE.MYDATABASE_SURVEY", "CreatorId", "MYDATABASE.MYDATABASE_USER");
            DropForeignKey("MYDATABASE.MYDATABASE_USERROLES", "Role_Id", "MYDATABASE.MYDATABASE_ROLE");
            DropForeignKey("MYDATABASE.MYDATABASE_USERROLES", "User_Id", "MYDATABASE.MYDATABASE_USER");
            DropForeignKey("MYDATABASE.MYDATABASE_ROLEPRIVILEGES", "Privilege_Id", "MYDATABASE.MYDATABASE_PRIVILEGE");
            DropForeignKey("MYDATABASE.MYDATABASE_ROLEPRIVILEGES", "Role_Id", "MYDATABASE.MYDATABASE_ROLE");
            DropForeignKey("MYDATABASE.MYDATABASE_SURVEYQUESTION", "QuestionId", "MYDATABASE.MYDATABASE_QUESTION");
            DropForeignKey("MYDATABASE.MYDATABASE_QUESTION", "ParentQuestionId", "MYDATABASE.MYDATABASE_QUESTION");
            DropForeignKey("MYDATABASE.MYDATABASE_QUESTION", "ParentOptionId", "MYDATABASE.MYDATABASE_OPTION");
            DropForeignKey("MYDATABASE.MYDATABASE_OPTION", "Question_Id", "MYDATABASE.MYDATABASE_QUESTION");
            DropForeignKey("MYDATABASE.MYDATABASE_QUESTION", "Option_Id", "MYDATABASE.MYDATABASE_OPTION");
            DropForeignKey("MYDATABASE.MYDATABASE_OPTION", "ParentQuestionId", "MYDATABASE.MYDATABASE_QUESTION");
            DropIndex("MYDATABASE.MYDATABASE_USERROLES", new[] { "Role_Id" });
            DropIndex("MYDATABASE.MYDATABASE_USERROLES", new[] { "User_Id" });
            DropIndex("MYDATABASE.MYDATABASE_ROLEPRIVILEGES", new[] { "Privilege_Id" });
            DropIndex("MYDATABASE.MYDATABASE_ROLEPRIVILEGES", new[] { "Role_Id" });
            DropIndex("MYDATABASE.MYDATABASE_USERFINGERPRINT", new[] { "FingerPrintClassId" });
            DropIndex("MYDATABASE.MYDATABASE_USERFINGERPRINT", new[] { "UserId" });
            DropIndex("MYDATABASE.MYDATABASE_CUSTOMERFINGERPRINT", new[] { "FingerPrintClassId" });
            DropIndex("MYDATABASE.MYDATABASE_CUSTOMERFINGERPRINT", new[] { "CustomerId" });
            DropIndex("MYDATABASE.MYDATABASE_SERVICE", new[] { "ServiceTypeId" });
            DropIndex("MYDATABASE.MYDATABASE_SERVICE", new[] { "CustomerId" });
            DropIndex("MYDATABASE.MYDATABASE_NUMBER", new[] { "NumberTypeId" });
            DropIndex("MYDATABASE.MYDATABASE_NUMBER", new[] { "CustomerId" });
            DropIndex("MYDATABASE.MYDATABASE_CUSTOMERHOBBY", new[] { "HobbyTypeId" });
            DropIndex("MYDATABASE.MYDATABASE_CUSTOMERHOBBY", new[] { "CustomerId" });
            DropIndex("MYDATABASE.MYDATABASE_SURVEYRESPONSE", new[] { "SurveyId" });
            DropIndex("MYDATABASE.MYDATABASE_SURVEYRESPONSE", new[] { "CustomerId" });
            DropIndex("MYDATABASE.MYDATABASE_ROLE", new[] { "Name" });
            DropIndex("MYDATABASE.MYDATABASE_USER", new[] { "Alias" });
            DropIndex("MYDATABASE.MYDATABASE_USER", new[] { "HRId" });
            DropIndex("MYDATABASE.MYDATABASE_SURVEY", new[] { "CreatorId" });
            DropIndex("MYDATABASE.MYDATABASE_SURVEY", new[] { "Name" });
            DropIndex("MYDATABASE.MYDATABASE_SURVEYQUESTION", new[] { "QuestionId" });
            DropIndex("MYDATABASE.MYDATABASE_SURVEYQUESTION", new[] { "SurveyId" });
            DropIndex("MYDATABASE.MYDATABASE_OPTION", new[] { "Question_Id" });
            DropIndex("MYDATABASE.MYDATABASE_OPTION", new[] { "ParentQuestionId" });
            DropIndex("MYDATABASE.MYDATABASE_QUESTION", new[] { "Option_Id" });
            DropIndex("MYDATABASE.MYDATABASE_QUESTION", new[] { "ParentOptionId" });
            DropIndex("MYDATABASE.MYDATABASE_QUESTION", new[] { "ParentQuestionId" });
            DropIndex("MYDATABASE.MYDATABASE_ANSWER", new[] { "QuestionId" });
            DropIndex("MYDATABASE.MYDATABASE_ANSWER", new[] { "SurveyResponseId" });
            DropTable("MYDATABASE.MYDATABASE_USERROLES");
            DropTable("MYDATABASE.MYDATABASE_ROLEPRIVILEGES");
            DropTable("MYDATABASE.MYDATABASE_USERFINGERPRINT");
            DropTable("MYDATABASE.MYDATABASE_FINGERPRINTCLASS");
            DropTable("MYDATABASE.MYDATABASE_CUSTOMERFINGERPRINT");
            DropTable("MYDATABASE.MYDATABASE_SERVICETYPE");
            DropTable("MYDATABASE.MYDATABASE_SERVICE");
            DropTable("MYDATABASE.MYDATABASE_NUMBERTYPE");
            DropTable("MYDATABASE.MYDATABASE_NUMBER");
            DropTable("MYDATABASE.MYDATABASE_HOBBYTYPE");
            DropTable("MYDATABASE.MYDATABASE_CUSTOMERHOBBY");
            DropTable("MYDATABASE.MYDATABASE_CUSTOMER");
            DropTable("MYDATABASE.MYDATABASE_SURVEYRESPONSE");
            DropTable("MYDATABASE.MYDATABASE_PRIVILEGE");
            DropTable("MYDATABASE.MYDATABASE_ROLE");
            DropTable("MYDATABASE.MYDATABASE_USER");
            DropTable("MYDATABASE.MYDATABASE_SURVEY");
            DropTable("MYDATABASE.MYDATABASE_SURVEYQUESTION");
            DropTable("MYDATABASE.MYDATABASE_OPTION");
            DropTable("MYDATABASE.MYDATABASE_QUESTION");
            DropTable("MYDATABASE.MYDATABASE_ANSWER");
        }
    }
}
