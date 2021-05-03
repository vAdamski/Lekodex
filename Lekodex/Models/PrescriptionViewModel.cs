using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lekodex
{
    public class PrescriptionViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DoctorViewModel Doctor { get; set; }

        public IEnumerable<MedicineViewModel> Medicines { get; set; }
    }
}
