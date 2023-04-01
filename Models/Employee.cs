using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectJunior.Models
{
	public class Employee
	{
		public int Id { get; set; }
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Surname { get; set; }
		[Required]
		public string? Post { get; set; }

		[Required]
		public int PharmacyId { get; set; }
		[ForeignKey("PharmacyId")]
		public Pharmacy? Pharmacy { get; set; }
	}
}

