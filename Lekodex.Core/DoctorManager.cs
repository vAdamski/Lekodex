using Lekodex.Core.Mappers;
using Lekodex.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lekodex.Core
{
    public class DoctorManager
    {
        private readonly IDoctorRepository mDoctorRepository;
        private readonly IPrescriptionRepository mPrescriptionRepository;
        private readonly IMedicineRepository mMedicineRepository;
        private readonly DoctorsMapper mDoctorsMapper;

        public DoctorManager(IDoctorRepository doctorRepository, IPrescriptionRepository prescriptionRepository, IMedicineRepository medicineRepository, DoctorsMapper doctorsMapper)
        {
            mDoctorRepository = doctorRepository;
            mPrescriptionRepository = prescriptionRepository;
            mMedicineRepository = medicineRepository;
            mDoctorsMapper = doctorsMapper;
        }

        public IEnumerable<DoctorDto> GetAllDoctors(string filterString)
        {
            var doctorEntities = mDoctorRepository.GetAllDoctors();

            if(!string.IsNullOrEmpty(filterString))
            {
                doctorEntities = doctorEntities.Where(x => x.FirstName.Contains(filterString) || x.LastName.Contains(filterString));
            }

            return mDoctorsMapper.Map(doctorEntities);
        }

        public IEnumerable<PrescriptionDto> GetAllPrescriptionsForADoctor(int doctorId, string filterString)
        {
            var prescriptionEntities = mPrescriptionRepository.GetAllPrescriptions().Where(x => x.DoctorId == doctorId);

            if (!string.IsNullOrEmpty(filterString))
            {
                prescriptionEntities = prescriptionEntities.Where(x => x.Name.Contains(filterString));
            }

            return mDoctorsMapper.Map(prescriptionEntities);
        }

        public IEnumerable<MedicineDto> GetAllMedicineForAPrescription(int prescriptionID, string filterString)
        {
            var medicineEntities = mMedicineRepository.GetAllMedicines().Where(x => x.PrescriptionId == prescriptionID);

            if (!string.IsNullOrEmpty(filterString))
            {
                medicineEntities = medicineEntities
                    .Where(x => x.ActiveSubstance.Contains(filterString) ||
                                x.Name.Contains(filterString) ||
                                x.CompanyName.Contains(filterString));
            }

            return mDoctorsMapper.Map(medicineEntities);
        }

        public void AddNewMedicine(MedicineDto medicine, int prescriptionId)
        {
            var entity = mDoctorsMapper.Map(medicine);

            entity.PrescriptionId = prescriptionId;

            mMedicineRepository.AddNew(entity);
        }

        public void AddNewPrescription(PrescriptionDto prescription, int doctorId)
        {
            var entity = mDoctorsMapper.Map(prescription);

            entity.DoctorId = doctorId;

            mMedicineRepository.AddNew(entity);
        }
    }
}
