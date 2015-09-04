namespace OEEPortal_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShiftModelChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shifts", "StartDay", c => c.Int(nullable: false));
            AddColumn("dbo.Shifts", "EndDay", c => c.Int(nullable: false));
            AlterColumn("dbo.Shifts", "Start", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Shifts", "End", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shifts", "End", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Shifts", "Start", c => c.DateTime(nullable: false));
            DropColumn("dbo.Shifts", "EndDay");
            DropColumn("dbo.Shifts", "StartDay");
        }
    }
}
