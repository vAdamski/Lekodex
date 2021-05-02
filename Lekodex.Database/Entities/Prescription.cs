using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lekodex.Database
{
    public class Prescription : BaseEntity
    {
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        public virtual Doctor Doctor  { get; set; }

        [NotMapped]
        public virtual List<Medicine> Medicines { get; set; }
    }
}
