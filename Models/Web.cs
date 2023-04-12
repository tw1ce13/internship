using System;
using System.ComponentModel.DataAnnotations;
namespace ProjectJunior.Models
{
	public class Web
	{
		public int Id { get; set; }
        	[Required]
        	public string? Name { get; set; }
        	[Required]
       		public int CountPharmacy { get; set; }
	}
}

