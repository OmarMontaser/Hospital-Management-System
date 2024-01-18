using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels
{
    public class Lab
    {
        public int Id { get; set; }
        public string LabNumber { get; set; }
        public string TestType { get; set; }
        public string TestCode { get; set; }
        public int weight { get; set; }
        public int Height { get; set; }
        public int BloodPressure { get; set; }
        public double Temperature { get; set; }
        public string TestResult { get; set; }
        public ApplicationUser Patient { get; set; }


    }
}
