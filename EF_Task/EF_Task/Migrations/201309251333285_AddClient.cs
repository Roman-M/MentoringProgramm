namespace EF_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Login = c.String(maxLength: 50),
                        FIO = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);

			Sql("INSERT INTO dbo.Clients ([Login],[FIO]) VALUES ('ANONYM','Anonymous client')");
            AddColumn("dbo.Payments", "Client", c => c.Int(nullable: false));
			Sql("UPDATE dbo.Payments SET Client = (SELECT ID FROM dbo.Clients WHERE Login = 'ANONYM')");
            AddForeignKey("dbo.Payments", "Client", "dbo.Clients", "ID", cascadeDelete: true);
            CreateIndex("dbo.Payments", "Client");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Payments", new[] { "Client" });
            DropForeignKey("dbo.Payments", "Client", "dbo.Clients");
            DropColumn("dbo.Payments", "Client");
            DropTable("dbo.Clients");
        }
    }
}
