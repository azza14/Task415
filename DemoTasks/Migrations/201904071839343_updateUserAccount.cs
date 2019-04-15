namespace DemoTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUserAccount : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserAccounts", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAccounts", "Address", c => c.String(nullable: false));
        }
    }
}
