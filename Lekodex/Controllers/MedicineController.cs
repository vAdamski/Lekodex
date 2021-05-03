using Lekodex.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lekodex.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IDoctorManager mDoctorManager;
        private readonly ViewModelMapper mViewModelMapper;

        public MedicineController(IDoctorManager doctorManager, ViewModelMapper viewModelMapper)
        {
            mDoctorManager = doctorManager;
            mViewModelMapper = viewModelMapper;
        }

        public IActionResult Index(int doctorId, int prescriptionId, string filterString)
        {
            TempData["PrescriptionId"] = prescriptionId;
            TempData["DoctorId"] = doctorId;

            var prescriptionDto = mDoctorManager.GetAllPrescriptionsForADoctor(doctorId, null).FirstOrDefault(x => x.Id == prescriptionId);
            var medicineDtos = mDoctorManager.GetAllMedicineForAPrescription(prescriptionId, filterString);

            var prescriptionViewModel = mViewModelMapper.Map(prescriptionDto);
            prescriptionViewModel.Medicines = mViewModelMapper.Map(medicineDtos);

            return View(prescriptionViewModel);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MedicineViewModel medicineViewModel)
        {
            var dto = mViewModelMapper.Map(medicineViewModel);

            mDoctorManager.AddNewMedicine(dto, int.Parse(TempData["PrescriptionId"].ToString()));

            return RedirectToAction("Index", new { doctorId = int.Parse(TempData["DoctorId"].ToString()), prescriptionId = int.Parse(TempData["PrescriptionId"].ToString()) });
        }
        public IActionResult Delete(int medicineId)
        {
            mDoctorManager.DeleteMedicine(new MedicineDto { Id = medicineId});

            return RedirectToAction("Index", new { doctorId = int.Parse(TempData["DoctorId"].ToString()), prescriptionId = int.Parse(TempData["PrescriptionId"].ToString()) });
        }
    }
}
