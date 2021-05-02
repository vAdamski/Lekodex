using System;
using System.Collections.Generic;
using System.Text;

namespace Lekodex.Database
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IEnumerable<Doctor> GetAllDoctors();
    }
}
