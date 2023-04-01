using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectJunior.Models
{
	public class Discount
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		[Required]
		public string? Type { get; set; }
		[Required]
		public int Value { get; set; }
	}
}

