using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels
{
    public class Bill
    {
        public int Id { get; set; }
        public int BillNumber { get; set; }
        public int DoctorCharge { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MedicineCharge { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OperationCharge { get; set; }

        public int NoOfDays { get; set; }
        public int LabCharge { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Advance { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalBill { get; set; }
        public ApplicationUser Patient { get; set; }
        public Insurance Insurance { get; set; }
    }
}
