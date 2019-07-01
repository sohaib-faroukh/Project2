namespace CustomerProfileBank.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateQuestionModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("SOHAIB.SOHAIB_QUESTION", "ParentOptionId", "SOHAIB.SOHAIB_OPTION");
            DropIndex("SOHAIB.SOHAIB_QUESTION", new[] { "ParentQuestionId" });
            DropIndex("SOHAIB.SOHAIB_QUESTION", new[] { "ParentOptionId" });
            AlterColumn("SOHAIB.SOHAIB_QUESTION", "ParentQuestionId", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("SOHAIB.SOHAIB_QUESTION", "ParentOptionId", c => c.Decimal(precision: 10, scale: 0));
            CreateIndex("SOHAIB.SOHAIB_QUESTION", "ParentQuestionId");
            CreateIndex("SOHAIB.SOHAIB_QUESTION", "ParentOptionId");
            AddForeignKey("SOHAIB.SOHAIB_QUESTION", "ParentOptionId", "SOHAIB.SOHAIB_OPTION", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("SOHAIB.SOHAIB_QUESTION", "ParentOptionId", "SOHAIB.SOHAIB_OPTION");
            DropIndex("SOHAIB.SOHAIB_QUESTION", new[] { "ParentOptionId" });
            DropIndex("SOHAIB.SOHAIB_QUESTION", new[] { "ParentQuestionId" });
            AlterColumn("SOHAIB.SOHAIB_QUESTION", "ParentOptionId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AlterColumn("SOHAIB.SOHAIB_QUESTION", "ParentQuestionId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            CreateIndex("SOHAIB.SOHAIB_QUESTION", "ParentOptionId");
            CreateIndex("SOHAIB.SOHAIB_QUESTION", "ParentQuestionId");
            AddForeignKey("SOHAIB.SOHAIB_QUESTION", "ParentOptionId", "SOHAIB.SOHAIB_OPTION", "Id", cascadeDelete: true);
        }
    }
}
