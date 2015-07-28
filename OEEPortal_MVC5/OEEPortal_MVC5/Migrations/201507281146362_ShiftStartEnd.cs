namespace OEEPortal_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShiftStartEnd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shifts", "Start", c => c.DateTime(nullable: false));
            AddColumn("dbo.Shifts", "End", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shifts", "End");
            DropColumn("dbo.Shifts", "Start");
        }
    }
}
