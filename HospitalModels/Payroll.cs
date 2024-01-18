using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalModels
{
    public class Payroll
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetSalary { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HourSalary { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BounusSalary { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Conpensation { get; set; }
        public string AccountNumber { get; set; }
        public ApplicationUser EmployeeId { get; set; }
    
    }
}