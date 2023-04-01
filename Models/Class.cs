using System;
using System.ComponentModel.DataAnnotations;
namespace ProjectJunior.Models
{
	public class Class
	{
		public int Id { get; set; }
		[Required]
		public string? Name { get; set; }
	}
}

