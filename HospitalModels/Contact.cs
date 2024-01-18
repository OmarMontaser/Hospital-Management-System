using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModels
{
    public class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int HospialId { get; set; }
        public Hospital Hospital { get; set; }
     
    }
}
