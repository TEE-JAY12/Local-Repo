namespace To_show.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverideConventionforinfo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Information", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Information", "Sex", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Information", "Sex", c => c.String());
            AlterColumn("dbo.Information", "Name", c => c.String());
        }
    }
}
