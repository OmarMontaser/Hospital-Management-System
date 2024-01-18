using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels
{
    public class TestPrice
    {
        public int Id { get; set; }
        public string TestCode { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public Lab Lab { get; set; }
        public Bill Bill { get; set; }
    }
}
