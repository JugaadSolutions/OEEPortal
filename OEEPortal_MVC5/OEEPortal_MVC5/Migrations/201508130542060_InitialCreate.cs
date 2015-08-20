namespace OEEPortal_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lines",
                c => new
                    {
                        LineId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LineId);
            
            CreateTable(
                "dbo.Machines",
                c => new
                    {
                        MachineId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Icon = c.String(),
                        LineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MachineId)
                .ForeignKey("dbo.Lines", t => t.LineId, cascadeDelete: true)
                .Index(t => t.LineId);
            
            CreateTable(
                "dbo.MachineOutputRecords",
                c => new
                    {
                        MachineOutputRecordId = c.Int(nullable: false, identity: true),
                        OperatorId = c.String(),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        OutputQuantity = c.Int(nullable: false),
                        DefectQuantity = c.Int(nullable: false),
                        EquipmentBreakDownTime = c.Time(precision: 7),
                        ChangeOverTime = c.Time(precision: 7),
                        MaterialDownTime = c.Time(precision: 7),
                        QualityDownTime = c.Time(precision: 7),
                        OtherNonProductTime = c.Time(precision: 7),
                        PreventiveMaintenanceTime = c.Time(precision: 7),
                        ManagementMeetingTime = c.Time(precision: 7),
                        RegulatoryBreaksTime = c.Time(precision: 7),
                        PilotRunTime = c.Time(precision: 7),
                        MachineId = c.Int(nullable: false),
                        ReferenceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MachineOutputRecordId)
                .ForeignKey("dbo.Machines", t => t.MachineId, cascadeDelete: true)
                .ForeignKey("dbo.References", t => t.ReferenceId, cascadeDelete: true)
                .Index(t => t.MachineId)
                .Index(t => t.ReferenceId);
            
            CreateTable(
                "dbo.References",
                c => new
                    {
                        ReferenceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ReferenceId);
            
            CreateTable(
                "dbo.ReferenceMachines",
                c => new
                    {
                        ReferenceMachineId = c.Int(nullable: false, identity: true),
                        UsefullTime = c.Double(nullable: false),
                        ReferenceId = c.Int(nullable: false),
                        MachineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReferenceMachineId)
                .ForeignKey("dbo.Machines", t => t.MachineId, cascadeDelete: true)
                .ForeignKey("dbo.References", t => t.ReferenceId, cascadeDelete: true)
                .Index(t => t.ReferenceId)
                .Index(t => t.MachineId);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        ShiftId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShiftId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReferenceMachines", "ReferenceId", "dbo.References");
            DropForeignKey("dbo.ReferenceMachines", "MachineId", "dbo.Machines");
            DropForeignKey("dbo.MachineOutputRecords", "ReferenceId", "dbo.References");
            DropForeignKey("dbo.MachineOutputRecords", "MachineId", "dbo.Machines");
            DropForeignKey("dbo.Machines", "LineId", "dbo.Lines");
            DropIndex("dbo.ReferenceMachines", new[] { "MachineId" });
            DropIndex("dbo.ReferenceMachines", new[] { "ReferenceId" });
            DropIndex("dbo.MachineOutputRecords", new[] { "ReferenceId" });
            DropIndex("dbo.MachineOutputRecords", new[] { "MachineId" });
            DropIndex("dbo.Machines", new[] { "LineId" });
            DropTable("dbo.Shifts");
            DropTable("dbo.ReferenceMachines");
            DropTable("dbo.References");
            DropTable("dbo.MachineOutputRecords");
            DropTable("dbo.Machines");
            DropTable("dbo.Lines");
        }
    }
}
