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
    public class PrescriptionController : Controller
    {
        private readonly IDoctorManager mDoctorManager;
        private readonly ViewModelMapper mViewModelMapper;

        public PrescriptionController(IDoctorManager doctorManager, ViewModelMapper viewModelMapper)
        {
            mDoctorManager = doctorManager;
            mViewModelMapper = viewModelMapper;
        }

        public IActionResult Index(int doctorId, string filterString)
        {
            TempData["DoctorId"] = doctorId;

            var doctorDto = mDoctorManager.GetAllDoctors(null).FirstOrDefault(x => x.Id == doctorId);

            var prescriptionsDtos = mDoctorManager.GetAllPrescriptionsForADoctor(doctorId, filterString);

            var doctorViewModel = mViewModelMapper.Map(doctorDto);

            doctorViewModel.Prescriptions = mViewModelMapper.Map(prescriptionsDtos);

            return View(doctorViewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PrescriptionViewModel prescriptionViewModel)
        {
            var dto = mViewModelMapper.Map(prescriptionViewModel);

            mDoctorManager.AddNewPrescription(dto, int.Parse(TempData["DoctorId"].ToString()));

            return RedirectToAction("Index", new { doctorId = int.Parse(TempData["DoctorId"].ToString()) });
        }

        public IActionResult View(int prescriptionId)
        {
            return RedirectToAction("Index", "Medicine", new { doctorId = int.Parse(TempData["DoctorId"].ToString()), prescriptionId = prescriptionId});
        }

        public IActionResult Delete(int prescriptionId)
        {
            mDoctorManager.DeletePrescription(new PrescriptionDto { Id = prescriptionId });

            return RedirectToAction("Index", new { doctorId = int.Parse(TempData["DoctorId"].ToString()) });
        }
    }
}
