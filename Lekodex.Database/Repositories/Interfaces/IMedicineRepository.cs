using System;
using System.Collections.Generic;
using System.Text;

namespace Lekodex.Database
{
    public interface IMedicineRepository : IRepository<Medicine>
    {
        IEnumerable<Medicine> GetAllMedicines();
    }
}
