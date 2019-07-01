namespace CustomerProfileBank.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNationalNumberToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("SOHAIB.SOHAIB_CUSTOMER", "NationalNumber", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("SOHAIB.SOHAIB_CUSTOMER", "NationalNumber", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("SOHAIB.SOHAIB_CUSTOMER", new[] { "NationalNumber" });
            DropColumn("SOHAIB.SOHAIB_CUSTOMER", "NationalNumber");
        }
    }
}
