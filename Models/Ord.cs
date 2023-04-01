using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectJunior.Models
{
	public class Ord
	{
		public int Id { get; set; }
		[Required]
		public DateTime Date { get; set; }

		[Required]
		public int PharmacyId { get; set; }
        [ForeignKey("PharmacyId")]
        public Pharmacy? Pharmacy { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }
        [Required]
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }
        [Required]
        public int DiscountId { get; set; }
        [ForeignKey("DiscountId")]
        public Discount? Discount { get; set; }
    }
}

