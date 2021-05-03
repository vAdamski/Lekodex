﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lekodex.Core
{
    public interface IDoctorManager
    {
        void AddNewDoctor(DoctorDto doctor);
        void AddNewMedicine(MedicineDto medicine, int prescriptionId);
        void AddNewPrescription(PrescriptionDto prescription, int doctorId);
        bool DeleteDoctor(DoctorDto doctor);
        bool DeleteMedicine(MedicineDto medicine);
        bool DeletePrescription(PrescriptionDto prescription);
        List<DoctorDto> GetAllDoctors(string filterString);
        List<MedicineDto> GetAllMedicineForAPrescription(int prescriptionID, string filterString);
        List<PrescriptionDto> GetAllPrescriptionsForADoctor(int doctorId, string filterString);
    }
}
