using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lekodex
{
    public static class TestDatabasePleaseDelete
    {
        public static List<DoctorViewModel> Doctors { get; set; } = new List<DoctorViewModel>
        {
            new DoctorViewModel
            {
                Name = "Patryk",
                Prescriptions = new List<PrescriptionViewModel>
                {
                    new PrescriptionViewModel
                    {
                        Name = "Recepta 1",
                        Medicines = new List<MedicineViewModel>
                        {
                            new MedicineViewModel
                            {
                                Name = "Magnez",
                            },
                            new MedicineViewModel
                            {
                                Name = "Aspiryna"
                            }
                        }
                    },
                    new PrescriptionViewModel
                    {
                        Name = "Recepta 2",
                        Medicines = new List<MedicineViewModel>
                        {
                            new MedicineViewModel
                            {
                                Name = "Witmina C",
                            },
                            new MedicineViewModel
                            {
                                Name = "Witamina D"
                            }
                        }
                    }
                }
            },
            new DoctorViewModel
            {
                Name = "Kazimierz",
                Prescriptions = new List<PrescriptionViewModel>
                {
                    new PrescriptionViewModel
                    {
                        Name = "Recepta 1",
                        Medicines = new List<MedicineViewModel>
                        {
                            new MedicineViewModel
                            {
                                Name = "Magnez",
                            },
                            new MedicineViewModel
                            {
                                Name = "Aspiryna"
                            }
                        }
                    },
                    new PrescriptionViewModel
                    {
                        Name = "Recepta 2",
                        Medicines = new List<MedicineViewModel>
                        {
                            new MedicineViewModel
                            {
                                Name = "Witmina C",
                            },
                            new MedicineViewModel
                            {
                                Name = "Witamina D"
                            }
                        }
                    }
                }
            },
            new DoctorViewModel
            {
                Name = "Zbigniew",
                Prescriptions = new List<PrescriptionViewModel>
                {
                    new PrescriptionViewModel
                    {
                        Name = "Recepta 1",
                        Medicines = new List<MedicineViewModel>
                        {
                            new MedicineViewModel
                            {
                                Name = "Magnez",
                            },
                            new MedicineViewModel
                            {
                                Name = "Aspiryna"
                            }
                        }
                    },
                    new PrescriptionViewModel
                    {
                        Name = "Recepta 2",
                        Medicines = new List<MedicineViewModel>
                        {
                            new MedicineViewModel
                            {
                                Name = "Witmina C",
                            },
                            new MedicineViewModel
                            {
                                Name = "Witamina D"
                            }
                        }
                    }
                }
            }
        };
    }
}
