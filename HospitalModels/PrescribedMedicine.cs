﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels
{
    public class PrescribedMedicine
    {
        public int Id { get; set; }
        public Medicine Medicine { get; set; }
        public PatientReport PatientReport { get; set; }




    }
}
