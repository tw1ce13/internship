using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectJunior.Models
{
	public class Ord
	{
		public int Id { get; set; }
		[Required]
		public DateTime Date { get; set; }

		[Required]
		public int PharmacyId { get; set; }
		public Pharmacy? Pharmacy { get; set; }
        [Required]
        public int EmployeeId { get; set; }
		public Employee? Employee { get; set; }
        [Required]
        public int PatientId { get; set; }
		public Patient? Patient { get; set; }
        [Required]
        public int DiscountId { get; set; }
		public Discount? Discount { get; set; }
	}
}

