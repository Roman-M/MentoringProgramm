namespace EF_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "CardNumber", c => c.String(maxLength: 16));
            AddColumn("dbo.Payments", "ExpDate_Month", c => c.Int());
            AddColumn("dbo.Payments", "ExpDate_Year", c => c.Int());
            AddColumn("dbo.Payments", "Account", c => c.String(maxLength: 100));
            AddColumn("dbo.Payments", "PurseNumber", c => c.String(maxLength: 12));
            AddColumn("dbo.Payments", "Type", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "Type");
            DropColumn("dbo.Payments", "PurseNumber");
            DropColumn("dbo.Payments", "Account");
            DropColumn("dbo.Payments", "ExpDate_Year");
            DropColumn("dbo.Payments", "ExpDate_Month");
            DropColumn("dbo.Payments", "CardNumber");
        }
    }
}
