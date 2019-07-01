namespace CustomerProfileBank.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCategoryModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("SOHAIB.SOHAIB_CATEGORY", "ParentCategoryId", c => c.Decimal(precision: 10, scale: 0));
        }
        
        public override void Down()
        {
            AlterColumn("SOHAIB.SOHAIB_CATEGORY", "ParentCategoryId", c => c.Decimal(nullable: false, precision: 10, scale: 0));
        }
    }
}
