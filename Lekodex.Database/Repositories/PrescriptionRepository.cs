using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lekodex.Database
{
    public class PrescriptionRepository : BaseRepository<Prescription>, IPrescriptionRepository
    {
        protected override DbSet<Prescription> DbSet => mDbContext.Prescriptions;

        public PrescriptionRepository(LekodexAppDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Prescription> GetAllPrescriptions()
        {
            return DbSet.Include(x => x.Medicines).Select(x => x);
        }
    }
}
