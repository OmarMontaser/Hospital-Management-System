using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels
{
    public class Timing
    {
        public int Id { get; set; }
        public ApplicationUser DoctorId { get; set; }
        public DateTime Date { get; set; }
        public int MorningShiftStartTime { get; set; }
        public int MorningShiftEndTime { get; set; }
        public int AfternoonShiftStartTime { get; set; }
        public int AfternoonShiftEndTime { get; set; }
        public int Duration { get; set; }
        public Status status { get; set; }
    }
}


namespace HospitalModels
{
    public enum Status
    {
        Available,
        Pending,
        Confirm
    }
}