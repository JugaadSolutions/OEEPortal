namespace OEEPortal_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MachineOutputRecordChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MachineOutputRecords", "EquipmentBreakDownStart", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "EquipmentBreakDownEnd", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "ChangeOverStart", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "ChangeOverEnd", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "MaterialDownStart", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "MaterialDownEnd", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "QualityDownStart", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "QualityDownEnd", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "NonProductionStart", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "NonProductionEnd", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "PreventiveMaintenanceStart", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "PreventiveMaintenanceEnd", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "ManagementMeetingStart", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "ManagementMeetingEnd", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "RegulatoryBreaksStart", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "RegulatoryBreaksEnd", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "PilotRunStart", c => c.DateTime());
            AlterColumn("dbo.MachineOutputRecords", "PilotRunEnd", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MachineOutputRecords", "PilotRunEnd", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "PilotRunStart", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "RegulatoryBreaksEnd", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "RegulatoryBreaksStart", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "ManagementMeetingEnd", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "ManagementMeetingStart", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "PreventiveMaintenanceEnd", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "PreventiveMaintenanceStart", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "NonProductionEnd", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "NonProductionStart", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "QualityDownEnd", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "QualityDownStart", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "MaterialDownEnd", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "MaterialDownStart", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "ChangeOverEnd", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "ChangeOverStart", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "EquipmentBreakDownEnd", c => c.Time(precision: 7));
            AlterColumn("dbo.MachineOutputRecords", "EquipmentBreakDownStart", c => c.Time(precision: 7));
        }
    }
}
