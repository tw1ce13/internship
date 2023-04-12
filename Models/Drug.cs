using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectJunior.Models
{
	
	public class Drug
	{
		public int Id { get; set; }
		[Required]
		public string? Name { get; set; }
		[Required]
		public bool IsRecipe { get; set; }

		[Required]
		public int ClassId { get; set; }
        	[ForeignKey("ClassId")]
		public Class? Class { get; set; }
	}
}

