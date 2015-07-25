using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OEEPortal.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
    {

    }
        public DbSet<Entity> Entities { get; set; }

    }
}