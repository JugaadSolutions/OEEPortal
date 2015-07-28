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
                        LineID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MachineId)
                .ForeignKey("dbo.Lines", t => t.LineID, cascadeDelete: true)
                .Index(t => t.LineID);
            
            CreateTable(
                "dbo.MachineOutputRecords",
                c => new
                    {
                        MachineOutputRecordId = c.Int(nullable: false, identity: true),
                        EquipmentBreakDown = c.Double(nullable: false),
                        ChangeOver = c.Double(nullable: false),
                        MaterialDownTime = c.Double(nullable: false),
                        QuantityDownTime = c.Double(nullable: false),
                        OtherNonProduct = c.Double(nullable: false),
                        PreventiveMaintenance = c.Double(nullable: false),
                        ManagementMeeting = c.Double(nullable: false),
                        RegulatoryBreaks = c.Double(nullable: false),
                        PilotRun = c.Double(nullable: false),
                        MachineId = c.Int(nullable: false),
                        ReferenceId = c.Int(nullable: false),
                        ShiftId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MachineOutputRecordId)
                .ForeignKey("dbo.Machines", t => t.MachineId, cascadeDelete: true)
                .ForeignKey("dbo.References", t => t.ReferenceId, cascadeDelete: true)
                .ForeignKey("dbo.Shifts", t => t.ShiftId, cascadeDelete: true)
                .Index(t => t.MachineId)
                .Index(t => t.ReferenceId)
                .Index(t => t.ShiftId);
            
            CreateTable(
                "dbo.References",
                c => new
                    {
                        ReferenceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UsefullTme = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ReferenceId);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        ShiftId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ShiftId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MachineOutputRecords", "ShiftId", "dbo.Shifts");
            DropForeignKey("dbo.MachineOutputRecords", "ReferenceId", "dbo.References");
            DropForeignKey("dbo.MachineOutputRecords", "MachineId", "dbo.Machines");
            DropForeignKey("dbo.Machines", "LineID", "dbo.Lines");
            DropIndex("dbo.MachineOutputRecords", new[] { "ShiftId" });
            DropIndex("dbo.MachineOutputRecords", new[] { "ReferenceId" });
            DropIndex("dbo.MachineOutputRecords", new[] { "MachineId" });
            DropIndex("dbo.Machines", new[] { "LineID" });
            DropTable("dbo.Shifts");
            DropTable("dbo.References");
            DropTable("dbo.MachineOutputRecords");
            DropTable("dbo.Machines");
            DropTable("dbo.Lines");
        }
    }
}
