using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lekodex.Database
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        protected override DbSet<Doctor> DbSet => mDbContext.Doctors;

        public DoctorRepository(LekodexAppDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return DbSet.Include(x => x.Prescriptions).ThenInclude(x => x.Medicines).Select(x => x);
        }
    }
}
