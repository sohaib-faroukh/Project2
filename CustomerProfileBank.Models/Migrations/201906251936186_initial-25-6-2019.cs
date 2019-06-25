namespace CustomerProfileBank.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2562019 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SOHAIB.SOHAIB_ANSWER",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Text = c.String(),
                        SurveyResponseId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        QuestionId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_QUESTION", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_SURVEYRESPONSE", t => t.SurveyResponseId, cascadeDelete: true)
                .Index(t => t.SurveyResponseId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "SOHAIB.SOHAIB_QUESTION",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Text = c.String(nullable: false, maxLength: 250),
                        Type = c.String(nullable: false, maxLength: 100),
                        Status = c.String(nullable: false, maxLength: 100),
                        ParentQuestionId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ParentOptionId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CategoryId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Option_Id = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_CATEGORY", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_OPTION", t => t.Option_Id)
                .ForeignKey("SOHAIB.SOHAIB_OPTION", t => t.ParentOptionId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_QUESTION", t => t.ParentQuestionId)
                .Index(t => t.ParentQuestionId)
                .Index(t => t.ParentOptionId)
                .Index(t => t.CategoryId)
                .Index(t => t.Option_Id);
            
            CreateTable(
                "SOHAIB.SOHAIB_CATEGORY",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 250),
                        ParentCategoryId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "SOHAIB.SOHAIB_OPTION",
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
                .ForeignKey("SOHAIB.SOHAIB_QUESTION", t => t.ParentQuestionId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_QUESTION", t => t.Question_Id)
                .Index(t => t.ParentQuestionId)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "SOHAIB.SOHAIB_SURVEYQUESTION",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Order = c.Decimal(nullable: false, precision: 10, scale: 0),
                        IsMandatory = c.Decimal(nullable: false, precision: 1, scale: 0),
                        SurveyId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        QuestionId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_QUESTION", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_SURVEY", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.SurveyId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "SOHAIB.SOHAIB_SURVEY",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 250),
                        CreationDate = c.DateTime(nullable: false),
                        ValidiatyMonthlyPeriod = c.Decimal(nullable: false, precision: 10, scale: 0),
                        FromDate = c.DateTime(),
                        ToDate = c.DateTime(),
                        Status = c.String(nullable: false, maxLength: 100),
                        CreatorId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_USER", t => t.CreatorId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.CreatorId);
            
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
                "SOHAIB.SOHAIB_PRIVILEGE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "SOHAIB.SOHAIB_SURVEYRESPONSE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        RespondDateTime = c.DateTime(nullable: false),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        SurveyId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_SURVEY", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "SOHAIB.SOHAIB_CUSTOMER",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 150),
                        LastName = c.String(nullable: false, maxLength: 150),
                        Address = c.String(nullable: false, maxLength: 150),
                        ISPN = c.String(maxLength: 150),
                        Status = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "SOHAIB.SOHAIB_CUSTOMERHOBBY",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        HobbyTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_HOBBYTYPE", t => t.HobbyTypeId, cascadeDelete: true)
                .Index(t => t.HobbyTypeId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "SOHAIB.SOHAIB_HOBBYTYPE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "SOHAIB.SOHAIB_NUMBER",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        NumberTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_NUMBERTYPE", t => t.NumberTypeId, cascadeDelete: true)
                .Index(t => t.PhoneNumber, unique: true)
                .Index(t => t.CustomerId)
                .Index(t => t.NumberTypeId);
            
            CreateTable(
                "SOHAIB.SOHAIB_NUMBERTYPE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "SOHAIB.SOHAIB_SERVICE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Status = c.String(nullable: false, maxLength: 150),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ServiceTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_SERVICETYPE", t => t.ServiceTypeId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ServiceTypeId);
            
            CreateTable(
                "SOHAIB.SOHAIB_SERVICETYPE",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "SOHAIB.SOHAIB_CUSTOMERFINGERPRINT",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FingerPrint = c.String(nullable: false, maxLength: 150),
                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        FingerPrintClassId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_FINGERPRINTCLASS", t => t.FingerPrintClassId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.FingerPrintClassId);
            
            CreateTable(
                "SOHAIB.SOHAIB_FINGERPRINTCLASS",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "SOHAIB.SOHAIB_USERFINGERPRINT",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FingerPrint = c.String(nullable: false, maxLength: 150),
                        UserId = c.Decimal(nullable: false, precision: 10, scale: 0),
                        FingerPrintClassId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("SOHAIB.SOHAIB_FINGERPRINTCLASS", t => t.FingerPrintClassId, cascadeDelete: true)
                .ForeignKey("SOHAIB.SOHAIB_USER", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.FingerPrintClassId);
            
            CreateTable(
                "SOHAIB.SOHAIB_ROLEPRIVILEGES",
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
                "SOHAIB.SOHAIB_USERROLES",
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
            DropForeignKey("SOHAIB.SOHAIB_CUSTOMERFINGERPRINT", "FingerPrintClassId", "SOHAIB.SOHAIB_FINGERPRINTCLASS");
            DropForeignKey("SOHAIB.SOHAIB_CUSTOMERFINGERPRINT", "CustomerId", "SOHAIB.SOHAIB_CUSTOMER");
            DropForeignKey("SOHAIB.SOHAIB_ANSWER", "SurveyResponseId", "SOHAIB.SOHAIB_SURVEYRESPONSE");
            DropForeignKey("SOHAIB.SOHAIB_SURVEYRESPONSE", "SurveyId", "SOHAIB.SOHAIB_SURVEY");
            DropForeignKey("SOHAIB.SOHAIB_SURVEYRESPONSE", "CustomerId", "SOHAIB.SOHAIB_CUSTOMER");
            DropForeignKey("SOHAIB.SOHAIB_SERVICE", "ServiceTypeId", "SOHAIB.SOHAIB_SERVICETYPE");
            DropForeignKey("SOHAIB.SOHAIB_SERVICE", "CustomerId", "SOHAIB.SOHAIB_CUSTOMER");
            DropForeignKey("SOHAIB.SOHAIB_NUMBER", "NumberTypeId", "SOHAIB.SOHAIB_NUMBERTYPE");
            DropForeignKey("SOHAIB.SOHAIB_NUMBER", "CustomerId", "SOHAIB.SOHAIB_CUSTOMER");
            DropForeignKey("SOHAIB.SOHAIB_CUSTOMERHOBBY", "HobbyTypeId", "SOHAIB.SOHAIB_HOBBYTYPE");
            DropForeignKey("SOHAIB.SOHAIB_CUSTOMERHOBBY", "CustomerId", "SOHAIB.SOHAIB_CUSTOMER");
            DropForeignKey("SOHAIB.SOHAIB_ANSWER", "QuestionId", "SOHAIB.SOHAIB_QUESTION");
            DropForeignKey("SOHAIB.SOHAIB_SURVEYQUESTION", "SurveyId", "SOHAIB.SOHAIB_SURVEY");
            DropForeignKey("SOHAIB.SOHAIB_SURVEY", "CreatorId", "SOHAIB.SOHAIB_USER");
            DropForeignKey("SOHAIB.SOHAIB_USERROLES", "Role_Id", "SOHAIB.SOHAIB_ROLE");
            DropForeignKey("SOHAIB.SOHAIB_USERROLES", "User_Id", "SOHAIB.SOHAIB_USER");
            DropForeignKey("SOHAIB.SOHAIB_ROLEPRIVILEGES", "Privilege_Id", "SOHAIB.SOHAIB_PRIVILEGE");
            DropForeignKey("SOHAIB.SOHAIB_ROLEPRIVILEGES", "Role_Id", "SOHAIB.SOHAIB_ROLE");
            DropForeignKey("SOHAIB.SOHAIB_SURVEYQUESTION", "QuestionId", "SOHAIB.SOHAIB_QUESTION");
            DropForeignKey("SOHAIB.SOHAIB_QUESTION", "ParentQuestionId", "SOHAIB.SOHAIB_QUESTION");
            DropForeignKey("SOHAIB.SOHAIB_QUESTION", "ParentOptionId", "SOHAIB.SOHAIB_OPTION");
            DropForeignKey("SOHAIB.SOHAIB_OPTION", "Question_Id", "SOHAIB.SOHAIB_QUESTION");
            DropForeignKey("SOHAIB.SOHAIB_QUESTION", "Option_Id", "SOHAIB.SOHAIB_OPTION");
            DropForeignKey("SOHAIB.SOHAIB_OPTION", "ParentQuestionId", "SOHAIB.SOHAIB_QUESTION");
            DropForeignKey("SOHAIB.SOHAIB_QUESTION", "CategoryId", "SOHAIB.SOHAIB_CATEGORY");
            DropIndex("SOHAIB.SOHAIB_USERROLES", new[] { "Role_Id" });
            DropIndex("SOHAIB.SOHAIB_USERROLES", new[] { "User_Id" });
            DropIndex("SOHAIB.SOHAIB_ROLEPRIVILEGES", new[] { "Privilege_Id" });
            DropIndex("SOHAIB.SOHAIB_ROLEPRIVILEGES", new[] { "Role_Id" });
            DropIndex("SOHAIB.SOHAIB_USERFINGERPRINT", new[] { "FingerPrintClassId" });
            DropIndex("SOHAIB.SOHAIB_USERFINGERPRINT", new[] { "UserId" });
            DropIndex("SOHAIB.SOHAIB_FINGERPRINTCLASS", new[] { "Name" });
            DropIndex("SOHAIB.SOHAIB_CUSTOMERFINGERPRINT", new[] { "FingerPrintClassId" });
            DropIndex("SOHAIB.SOHAIB_CUSTOMERFINGERPRINT", new[] { "CustomerId" });
            DropIndex("SOHAIB.SOHAIB_SERVICETYPE", new[] { "Name" });
            DropIndex("SOHAIB.SOHAIB_SERVICE", new[] { "ServiceTypeId" });
            DropIndex("SOHAIB.SOHAIB_SERVICE", new[] { "CustomerId" });
            DropIndex("SOHAIB.SOHAIB_SERVICE", new[] { "Name" });
            DropIndex("SOHAIB.SOHAIB_NUMBERTYPE", new[] { "Name" });
            DropIndex("SOHAIB.SOHAIB_NUMBER", new[] { "NumberTypeId" });
            DropIndex("SOHAIB.SOHAIB_NUMBER", new[] { "CustomerId" });
            DropIndex("SOHAIB.SOHAIB_NUMBER", new[] { "PhoneNumber" });
            DropIndex("SOHAIB.SOHAIB_HOBBYTYPE", new[] { "Name" });
            DropIndex("SOHAIB.SOHAIB_CUSTOMERHOBBY", new[] { "CustomerId" });
            DropIndex("SOHAIB.SOHAIB_CUSTOMERHOBBY", new[] { "HobbyTypeId" });
            DropIndex("SOHAIB.SOHAIB_SURVEYRESPONSE", new[] { "SurveyId" });
            DropIndex("SOHAIB.SOHAIB_SURVEYRESPONSE", new[] { "CustomerId" });
            DropIndex("SOHAIB.SOHAIB_ROLE", new[] { "Name" });
            DropIndex("SOHAIB.SOHAIB_USER", new[] { "Alias" });
            DropIndex("SOHAIB.SOHAIB_USER", new[] { "HRId" });
            DropIndex("SOHAIB.SOHAIB_SURVEY", new[] { "CreatorId" });
            DropIndex("SOHAIB.SOHAIB_SURVEY", new[] { "Name" });
            DropIndex("SOHAIB.SOHAIB_SURVEYQUESTION", new[] { "QuestionId" });
            DropIndex("SOHAIB.SOHAIB_SURVEYQUESTION", new[] { "SurveyId" });
            DropIndex("SOHAIB.SOHAIB_OPTION", new[] { "Question_Id" });
            DropIndex("SOHAIB.SOHAIB_OPTION", new[] { "ParentQuestionId" });
            DropIndex("SOHAIB.SOHAIB_CATEGORY", new[] { "Name" });
            DropIndex("SOHAIB.SOHAIB_QUESTION", new[] { "Option_Id" });
            DropIndex("SOHAIB.SOHAIB_QUESTION", new[] { "CategoryId" });
            DropIndex("SOHAIB.SOHAIB_QUESTION", new[] { "ParentOptionId" });
            DropIndex("SOHAIB.SOHAIB_QUESTION", new[] { "ParentQuestionId" });
            DropIndex("SOHAIB.SOHAIB_ANSWER", new[] { "QuestionId" });
            DropIndex("SOHAIB.SOHAIB_ANSWER", new[] { "SurveyResponseId" });
            DropTable("SOHAIB.SOHAIB_USERROLES");
            DropTable("SOHAIB.SOHAIB_ROLEPRIVILEGES");
            DropTable("SOHAIB.SOHAIB_USERFINGERPRINT");
            DropTable("SOHAIB.SOHAIB_FINGERPRINTCLASS");
            DropTable("SOHAIB.SOHAIB_CUSTOMERFINGERPRINT");
            DropTable("SOHAIB.SOHAIB_SERVICETYPE");
            DropTable("SOHAIB.SOHAIB_SERVICE");
            DropTable("SOHAIB.SOHAIB_NUMBERTYPE");
            DropTable("SOHAIB.SOHAIB_NUMBER");
            DropTable("SOHAIB.SOHAIB_HOBBYTYPE");
            DropTable("SOHAIB.SOHAIB_CUSTOMERHOBBY");
            DropTable("SOHAIB.SOHAIB_CUSTOMER");
            DropTable("SOHAIB.SOHAIB_SURVEYRESPONSE");
            DropTable("SOHAIB.SOHAIB_PRIVILEGE");
            DropTable("SOHAIB.SOHAIB_ROLE");
            DropTable("SOHAIB.SOHAIB_USER");
            DropTable("SOHAIB.SOHAIB_SURVEY");
            DropTable("SOHAIB.SOHAIB_SURVEYQUESTION");
            DropTable("SOHAIB.SOHAIB_OPTION");
            DropTable("SOHAIB.SOHAIB_CATEGORY");
            DropTable("SOHAIB.SOHAIB_QUESTION");
            DropTable("SOHAIB.SOHAIB_ANSWER");
        }
    }
}
