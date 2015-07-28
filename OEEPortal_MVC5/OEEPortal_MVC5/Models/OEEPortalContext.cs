using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OEEPortal_MVC5.Models
{
    public class OEEPortalContext : DbContext
    {
        public DbSet<Line> Lines { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<MachineOutputRecord> MachineOutputRecords { get; set; }


        public OEEPortalContext()
          : base("name=OEEPortalConnection")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
    }
}