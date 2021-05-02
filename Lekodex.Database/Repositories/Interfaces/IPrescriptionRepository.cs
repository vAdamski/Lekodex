using System;
using System.Collections.Generic;
using System.Text;

namespace Lekodex.Database
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        IEnumerable<Prescription> GetAllPrescriptions();
    }
}
