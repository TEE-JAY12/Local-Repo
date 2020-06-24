namespace To_show.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIscancelled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Information", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Information", "IsCanceled");
        }
    }
}
