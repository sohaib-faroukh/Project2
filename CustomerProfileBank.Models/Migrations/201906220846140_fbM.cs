//namespace CustomerProfileBank.Models.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class fbM : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "mydatabase.mydatabase_ANSWER",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        Text = c.String(),
//                        SurveyResponseId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        QuestionId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("mydatabase.mydatabase_QUESTION", t => t.QuestionId, cascadeDelete: true)
//                .ForeignKey("mydatabase.mydatabase_SURVEYRESPONSE", t => t.SurveyResponseId, cascadeDelete: true)
//                .Index(t => t.SurveyResponseId)
//                .Index(t => t.QuestionId);
            
//            CreateTable(
//                "mydatabase.mydatabase_QUESTION",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        Text = c.String(nullable: false, maxLength: 250),
//                        ParentQuestionId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        ParentOptionId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        Type = c.String(),
//                        Status = c.String(),
//                        Option_Id = c.Decimal(precision: 10, scale: 0),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("mydatabase.mydatabase_OPTION", t => t.Option_Id)
//                .ForeignKey("mydatabase.mydatabase_OPTION", t => t.ParentOptionId, cascadeDelete: true)
//                .ForeignKey("mydatabase.mydatabase_QUESTION", t => t.ParentQuestionId)
//                .Index(t => t.ParentQuestionId)
//                .Index(t => t.ParentOptionId)
//                .Index(t => t.Option_Id);
            
//            CreateTable(
//                "mydatabase.mydatabase_OPTION",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        Text = c.String(nullable: false, maxLength: 200),
//                        Order = c.Decimal(precision: 10, scale: 0),
//                        IsDefault = c.Decimal(precision: 1, scale: 0),
//                        ParentQuestionId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        Question_Id = c.Decimal(precision: 10, scale: 0),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("mydatabase.mydatabase_QUESTION", t => t.ParentQuestionId, cascadeDelete: true)
//                .ForeignKey("mydatabase.mydatabase_QUESTION", t => t.Question_Id)
//                .Index(t => t.ParentQuestionId)
//                .Index(t => t.Question_Id);
            
//            CreateTable(
//                "mydatabase.mydatabase_SURVEYQUESTION",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        Order = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        IsMandatory = c.Decimal(nullable: false, precision: 1, scale: 0),
//                        SurveyId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        QuestionId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("mydatabase.mydatabase_QUESTION", t => t.QuestionId, cascadeDelete: true)
//                .ForeignKey("mydatabase.mydatabase_SURVEY", t => t.SurveyId, cascadeDelete: true)
//                .Index(t => t.SurveyId)
//                .Index(t => t.QuestionId);
            
//            CreateTable(
//                "mydatabase.mydatabase_SURVEY",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        Name = c.String(nullable: false, maxLength: 100),
//                        Description = c.String(maxLength: 100),
//                        creationDate = c.DateTime(nullable: false),
//                        ValidiatyMonthlyPeriod = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        FromDate = c.DateTime(),
//                        ToDate = c.DateTime(),
//                        Status = c.String(),
//                        CreatorId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("mydatabase.mydatabase_USER", t => t.CreatorId, cascadeDelete: true)
//                .Index(t => t.Name, unique: true)
//                .Index(t => t.CreatorId);
            
//            CreateTable(
//                "mydatabase.mydatabase_USER",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        HRId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        Alias = c.String(nullable: false, maxLength: 50),
//                        FirstName = c.String(nullable: false, maxLength: 50),
//                        LastName = c.String(nullable: false, maxLength: 50),
//                        Status = c.String(nullable: false, maxLength: 50),
//                        CreationDate = c.DateTime(nullable: false),
//                        DeactivationDate = c.DateTime(),
//                    })
//                .PrimaryKey(t => t.Id)
//                .Index(t => t.HRId, unique: true)
//                .Index(t => t.Alias, unique: true);
            
//            CreateTable(
//                "mydatabase.mydatabase_ROLE",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        Name = c.String(nullable: false, maxLength: 50),
//                        Description = c.String(nullable: false, maxLength: 500),
//                        Status = c.String(nullable: false, maxLength: 50),
//                    })
//                .PrimaryKey(t => t.Id)
//                .Index(t => t.Name, unique: true);
            
//            CreateTable(
//                "mydatabase.mydatabase_PRIVILEGE",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        Name = c.String(nullable: false, maxLength: 50),
//                        Description = c.String(nullable: false, maxLength: 500),
//                    })
//                .PrimaryKey(t => t.Id);
            
//            CreateTable(
//                "mydatabase.mydatabase_SURVEYRESPONSE",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        RespondDateTime = c.DateTime(nullable: false),
//                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        SurveyId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("mydatabase.mydatabase_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
//                .ForeignKey("mydatabase.mydatabase_SURVEY", t => t.SurveyId, cascadeDelete: true)
//                .Index(t => t.CustomerId)
//                .Index(t => t.SurveyId);
            
//            CreateTable(
//                "mydatabase.mydatabase_CUSTOMER",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        FirstName = c.String(),
//                        LastName = c.String(),
//                        Address = c.String(),
//                        ISPN = c.String(),
//                        Status = c.Decimal(nullable: false, precision: 10, scale: 0),
//                    })
//                .PrimaryKey(t => t.Id);
            
//            CreateTable(
//                "mydatabase.mydatabase_CUSTOMERHOBBY",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        HobbyTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("mydatabase.mydatabase_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
//                .ForeignKey("mydatabase.mydatabase_HOBBYTYPE", t => t.HobbyTypeId, cascadeDelete: true)
//                .Index(t => t.CustomerId)
//                .Index(t => t.HobbyTypeId);
            
//            CreateTable(
//                "mydatabase.mydatabase_HOBBYTYPE",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        Name = c.String(),
//                    })
//                .PrimaryKey(t => t.Id);
            
//            CreateTable(
//                "mydatabase.mydatabase_NUMBER",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        PhoneNumber = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        NumberTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("mydatabase.mydatabase_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
//                .ForeignKey("mydatabase.mydatabase_NUMBERTYPE", t => t.NumberTypeId, cascadeDelete: true)
//                .Index(t => t.CustomerId)
//                .Index(t => t.NumberTypeId);
            
//            CreateTable(
//                "mydatabase.mydatabase_NUMBERTYPE",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        Name = c.String(),
//                    })
//                .PrimaryKey(t => t.Id);
            
//            CreateTable(
//                "mydatabase.mydatabase_SERVICE",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        IsActive = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        ServiceTypeId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("mydatabase.mydatabase_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
//                .ForeignKey("mydatabase.mydatabase_SERVICETYPE", t => t.ServiceTypeId, cascadeDelete: true)
//                .Index(t => t.CustomerId)
//                .Index(t => t.ServiceTypeId);
            
//            CreateTable(
//                "mydatabase.mydatabase_SERVICETYPE",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        Name = c.String(),
//                    })
//                .PrimaryKey(t => t.Id);
            
//            CreateTable(
//                "mydatabase.mydatabase_CUSTOMERFINGERPRINT",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        FingerPrint = c.String(),
//                        CustomerId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        FingerPrintClassId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("mydatabase.mydatabase_CUSTOMER", t => t.CustomerId, cascadeDelete: true)
//                .ForeignKey("mydatabase.mydatabase_FINGERPRINTCLASS", t => t.FingerPrintClassId, cascadeDelete: true)
//                .Index(t => t.CustomerId)
//                .Index(t => t.FingerPrintClassId);
            
//            CreateTable(
//                "mydatabase.mydatabase_FINGERPRINTCLASS",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        Name = c.String(),
//                    })
//                .PrimaryKey(t => t.Id);
            
//            CreateTable(
//                "mydatabase.mydatabase_USERFINGERPRINT",
//                c => new
//                    {
//                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
//                        FingerPrint = c.String(),
//                        UserId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        FingerPrintClassId = c.Decimal(nullable: false, precision: 10, scale: 0),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("mydatabase.mydatabase_FINGERPRINTCLASS", t => t.FingerPrintClassId, cascadeDelete: true)
//                .ForeignKey("mydatabase.mydatabase_USER", t => t.UserId, cascadeDelete: true)
//                .Index(t => t.UserId)
//                .Index(t => t.FingerPrintClassId);
            
//            CreateTable(
//                "mydatabase.mydatabase_ROLEPRIVILEGES",
//                c => new
//                    {
//                        Role_Id = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        Privilege_Id = c.Decimal(nullable: false, precision: 10, scale: 0),
//                    })
//                .PrimaryKey(t => new { t.Role_Id, t.Privilege_Id })
//                .ForeignKey("mydatabase.mydatabase_ROLE", t => t.Role_Id, cascadeDelete: true)
//                .ForeignKey("mydatabase.mydatabase_PRIVILEGE", t => t.Privilege_Id, cascadeDelete: true)
//                .Index(t => t.Role_Id)
//                .Index(t => t.Privilege_Id);
            
//            CreateTable(
//                "mydatabase.mydatabase_USERROLES",
//                c => new
//                    {
//                        User_Id = c.Decimal(nullable: false, precision: 10, scale: 0),
//                        Role_Id = c.Decimal(nullable: false, precision: 10, scale: 0),
//                    })
//                .PrimaryKey(t => new { t.User_Id, t.Role_Id })
//                .ForeignKey("mydatabase.mydatabase_USER", t => t.User_Id, cascadeDelete: true)
//                .ForeignKey("mydatabase.mydatabase_ROLE", t => t.Role_Id, cascadeDelete: true)
//                .Index(t => t.User_Id)
//                .Index(t => t.Role_Id);
            
//        }
        
//        public override void Down()
//        {
//            DropForeignKey("mydatabase.mydatabase_USERFINGERPRINT", "UserId", "mydatabase.mydatabase_USER");
//            DropForeignKey("mydatabase.mydatabase_USERFINGERPRINT", "FingerPrintClassId", "mydatabase.mydatabase_FINGERPRINTCLASS");
//            DropForeignKey("mydatabase.mydatabase_CUSTOMERFINGERPRINT", "FingerPrintClassId", "mydatabase.mydatabase_FINGERPRINTCLASS");
//            DropForeignKey("mydatabase.mydatabase_CUSTOMERFINGERPRINT", "CustomerId", "mydatabase.mydatabase_CUSTOMER");
//            DropForeignKey("mydatabase.mydatabase_ANSWER", "SurveyResponseId", "mydatabase.mydatabase_SURVEYRESPONSE");
//            DropForeignKey("mydatabase.mydatabase_SURVEYRESPONSE", "SurveyId", "mydatabase.mydatabase_SURVEY");
//            DropForeignKey("mydatabase.mydatabase_SURVEYRESPONSE", "CustomerId", "mydatabase.mydatabase_CUSTOMER");
//            DropForeignKey("mydatabase.mydatabase_SERVICE", "ServiceTypeId", "mydatabase.mydatabase_SERVICETYPE");
//            DropForeignKey("mydatabase.mydatabase_SERVICE", "CustomerId", "mydatabase.mydatabase_CUSTOMER");
//            DropForeignKey("mydatabase.mydatabase_NUMBER", "NumberTypeId", "mydatabase.mydatabase_NUMBERTYPE");
//            DropForeignKey("mydatabase.mydatabase_NUMBER", "CustomerId", "mydatabase.mydatabase_CUSTOMER");
//            DropForeignKey("mydatabase.mydatabase_CUSTOMERHOBBY", "HobbyTypeId", "mydatabase.mydatabase_HOBBYTYPE");
//            DropForeignKey("mydatabase.mydatabase_CUSTOMERHOBBY", "CustomerId", "mydatabase.mydatabase_CUSTOMER");
//            DropForeignKey("mydatabase.mydatabase_ANSWER", "QuestionId", "mydatabase.mydatabase_QUESTION");
//            DropForeignKey("mydatabase.mydatabase_SURVEYQUESTION", "SurveyId", "mydatabase.mydatabase_SURVEY");
//            DropForeignKey("mydatabase.mydatabase_SURVEY", "CreatorId", "mydatabase.mydatabase_USER");
//            DropForeignKey("mydatabase.mydatabase_USERROLES", "Role_Id", "mydatabase.mydatabase_ROLE");
//            DropForeignKey("mydatabase.mydatabase_USERROLES", "User_Id", "mydatabase.mydatabase_USER");
//            DropForeignKey("mydatabase.mydatabase_ROLEPRIVILEGES", "Privilege_Id", "mydatabase.mydatabase_PRIVILEGE");
//            DropForeignKey("mydatabase.mydatabase_ROLEPRIVILEGES", "Role_Id", "mydatabase.mydatabase_ROLE");
//            DropForeignKey("mydatabase.mydatabase_SURVEYQUESTION", "QuestionId", "mydatabase.mydatabase_QUESTION");
//            DropForeignKey("mydatabase.mydatabase_QUESTION", "ParentQuestionId", "mydatabase.mydatabase_QUESTION");
//            DropForeignKey("mydatabase.mydatabase_QUESTION", "ParentOptionId", "mydatabase.mydatabase_OPTION");
//            DropForeignKey("mydatabase.mydatabase_OPTION", "Question_Id", "mydatabase.mydatabase_QUESTION");
//            DropForeignKey("mydatabase.mydatabase_QUESTION", "Option_Id", "mydatabase.mydatabase_OPTION");
//            DropForeignKey("mydatabase.mydatabase_OPTION", "ParentQuestionId", "mydatabase.mydatabase_QUESTION");
//            DropIndex("mydatabase.mydatabase_USERROLES", new[] { "Role_Id" });
//            DropIndex("mydatabase.mydatabase_USERROLES", new[] { "User_Id" });
//            DropIndex("mydatabase.mydatabase_ROLEPRIVILEGES", new[] { "Privilege_Id" });
//            DropIndex("mydatabase.mydatabase_ROLEPRIVILEGES", new[] { "Role_Id" });
//            DropIndex("mydatabase.mydatabase_USERFINGERPRINT", new[] { "FingerPrintClassId" });
//            DropIndex("mydatabase.mydatabase_USERFINGERPRINT", new[] { "UserId" });
//            DropIndex("mydatabase.mydatabase_CUSTOMERFINGERPRINT", new[] { "FingerPrintClassId" });
//            DropIndex("mydatabase.mydatabase_CUSTOMERFINGERPRINT", new[] { "CustomerId" });
//            DropIndex("mydatabase.mydatabase_SERVICE", new[] { "ServiceTypeId" });
//            DropIndex("mydatabase.mydatabase_SERVICE", new[] { "CustomerId" });
//            DropIndex("mydatabase.mydatabase_NUMBER", new[] { "NumberTypeId" });
//            DropIndex("mydatabase.mydatabase_NUMBER", new[] { "CustomerId" });
//            DropIndex("mydatabase.mydatabase_CUSTOMERHOBBY", new[] { "HobbyTypeId" });
//            DropIndex("mydatabase.mydatabase_CUSTOMERHOBBY", new[] { "CustomerId" });
//            DropIndex("mydatabase.mydatabase_SURVEYRESPONSE", new[] { "SurveyId" });
//            DropIndex("mydatabase.mydatabase_SURVEYRESPONSE", new[] { "CustomerId" });
//            DropIndex("mydatabase.mydatabase_ROLE", new[] { "Name" });
//            DropIndex("mydatabase.mydatabase_USER", new[] { "Alias" });
//            DropIndex("mydatabase.mydatabase_USER", new[] { "HRId" });
//            DropIndex("mydatabase.mydatabase_SURVEY", new[] { "CreatorId" });
//            DropIndex("mydatabase.mydatabase_SURVEY", new[] { "Name" });
//            DropIndex("mydatabase.mydatabase_SURVEYQUESTION", new[] { "QuestionId" });
//            DropIndex("mydatabase.mydatabase_SURVEYQUESTION", new[] { "SurveyId" });
//            DropIndex("mydatabase.mydatabase_OPTION", new[] { "Question_Id" });
//            DropIndex("mydatabase.mydatabase_OPTION", new[] { "ParentQuestionId" });
//            DropIndex("mydatabase.mydatabase_QUESTION", new[] { "Option_Id" });
//            DropIndex("mydatabase.mydatabase_QUESTION", new[] { "ParentOptionId" });
//            DropIndex("mydatabase.mydatabase_QUESTION", new[] { "ParentQuestionId" });
//            DropIndex("mydatabase.mydatabase_ANSWER", new[] { "QuestionId" });
//            DropIndex("mydatabase.mydatabase_ANSWER", new[] { "SurveyResponseId" });
//            DropTable("mydatabase.mydatabase_USERROLES");
//            DropTable("mydatabase.mydatabase_ROLEPRIVILEGES");
//            DropTable("mydatabase.mydatabase_USERFINGERPRINT");
//            DropTable("mydatabase.mydatabase_FINGERPRINTCLASS");
//            DropTable("mydatabase.mydatabase_CUSTOMERFINGERPRINT");
//            DropTable("mydatabase.mydatabase_SERVICETYPE");
//            DropTable("mydatabase.mydatabase_SERVICE");
//            DropTable("mydatabase.mydatabase_NUMBERTYPE");
//            DropTable("mydatabase.mydatabase_NUMBER");
//            DropTable("mydatabase.mydatabase_HOBBYTYPE");
//            DropTable("mydatabase.mydatabase_CUSTOMERHOBBY");
//            DropTable("mydatabase.mydatabase_CUSTOMER");
//            DropTable("mydatabase.mydatabase_SURVEYRESPONSE");
//            DropTable("mydatabase.mydatabase_PRIVILEGE");
//            DropTable("mydatabase.mydatabase_ROLE");
//            DropTable("mydatabase.mydatabase_USER");
//            DropTable("mydatabase.mydatabase_SURVEY");
//            DropTable("mydatabase.mydatabase_SURVEYQUESTION");
//            DropTable("mydatabase.mydatabase_OPTION");
//            DropTable("mydatabase.mydatabase_QUESTION");
//            DropTable("mydatabase.mydatabase_ANSWER");
//        }
//    }
//}
