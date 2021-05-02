﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lekodex.Database
{
    public class Doctor : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public int WorkYears { get; set; }

        public bool IsAbleToMakePrescription { get; set; }

        [NotMapped]
        public virtual List<Prescription> Prescriptions { get; set; }
    }
}
