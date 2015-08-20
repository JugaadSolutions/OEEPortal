namespace OEEPortal_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start_end_machineoutputrecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MachineOutputRecords", "EquipmentBreakDownStart", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "EquipmentBreakDownEnd", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "ChangeOverStart", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "ChangeOverEnd", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "MaterialDownStart", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "MaterialDownEnd", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "QualityDownStart", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "QualityDownEnd", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "NonProductionStart", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "NonProductionEnd", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "PreventiveMaintenanceStart", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "PreventiveMaintenanceEnd", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "ManagementMeetingStart", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "ManagementMeetingEnd", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "RegulatoryBreaksStart", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "RegulatoryBreaksEnd", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "PilotRunStart", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "PilotRunEnd", c => c.Time(precision: 7));
            DropColumn("dbo.MachineOutputRecords", "EquipmentBreakDownTime");
            DropColumn("dbo.MachineOutputRecords", "ChangeOverTime");
            DropColumn("dbo.MachineOutputRecords", "MaterialDownTime");
            DropColumn("dbo.MachineOutputRecords", "QualityDownTime");
            DropColumn("dbo.MachineOutputRecords", "OtherNonProductTime");
            DropColumn("dbo.MachineOutputRecords", "PreventiveMaintenanceTime");
            DropColumn("dbo.MachineOutputRecords", "ManagementMeetingTime");
            DropColumn("dbo.MachineOutputRecords", "RegulatoryBreaksTime");
            DropColumn("dbo.MachineOutputRecords", "PilotRunTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MachineOutputRecords", "PilotRunTime", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "RegulatoryBreaksTime", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "ManagementMeetingTime", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "PreventiveMaintenanceTime", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "OtherNonProductTime", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "QualityDownTime", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "MaterialDownTime", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "ChangeOverTime", c => c.Time(precision: 7));
            AddColumn("dbo.MachineOutputRecords", "EquipmentBreakDownTime", c => c.Time(precision: 7));
            DropColumn("dbo.MachineOutputRecords", "PilotRunEnd");
            DropColumn("dbo.MachineOutputRecords", "PilotRunStart");
            DropColumn("dbo.MachineOutputRecords", "RegulatoryBreaksEnd");
            DropColumn("dbo.MachineOutputRecords", "RegulatoryBreaksStart");
            DropColumn("dbo.MachineOutputRecords", "ManagementMeetingEnd");
            DropColumn("dbo.MachineOutputRecords", "ManagementMeetingStart");
            DropColumn("dbo.MachineOutputRecords", "PreventiveMaintenanceEnd");
            DropColumn("dbo.MachineOutputRecords", "PreventiveMaintenanceStart");
            DropColumn("dbo.MachineOutputRecords", "NonProductionEnd");
            DropColumn("dbo.MachineOutputRecords", "NonProductionStart");
            DropColumn("dbo.MachineOutputRecords", "QualityDownEnd");
            DropColumn("dbo.MachineOutputRecords", "QualityDownStart");
            DropColumn("dbo.MachineOutputRecords", "MaterialDownEnd");
            DropColumn("dbo.MachineOutputRecords", "MaterialDownStart");
            DropColumn("dbo.MachineOutputRecords", "ChangeOverEnd");
            DropColumn("dbo.MachineOutputRecords", "ChangeOverStart");
            DropColumn("dbo.MachineOutputRecords", "EquipmentBreakDownEnd");
            DropColumn("dbo.MachineOutputRecords", "EquipmentBreakDownStart");
        }
    }
}
