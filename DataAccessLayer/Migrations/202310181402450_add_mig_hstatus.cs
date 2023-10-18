namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig_hstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "HStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Headings", "HeadingStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Headings", "HeadingStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Headings", "HStatus");
        }
    }
}
