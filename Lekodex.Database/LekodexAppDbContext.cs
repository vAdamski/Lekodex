using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lekodex.Database
{
    public class LekodexAppDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Medicine> Medicines { get; set; }

        public LekodexAppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
