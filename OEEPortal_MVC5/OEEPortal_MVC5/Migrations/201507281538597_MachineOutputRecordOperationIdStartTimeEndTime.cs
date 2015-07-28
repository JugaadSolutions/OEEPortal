namespace OEEPortal_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MachineOutputRecordOperationIdStartTimeEndTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MachineOutputRecords", "OperatorId", c => c.String());
            AddColumn("dbo.MachineOutputRecords", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.MachineOutputRecords", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MachineOutputRecords", "EndTime");
            DropColumn("dbo.MachineOutputRecords", "StartTime");
            DropColumn("dbo.MachineOutputRecords", "OperatorId");
        }
    }
}
