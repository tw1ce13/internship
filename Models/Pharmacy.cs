using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectJunior.Models
{
	public class Pharmacy
	{
		public int Id { get; set; }
        	[Required]
        	public string? Address { get; set; }
        	[Required]
        	public string? Type { get; set; }

        	[Required]
        	public int WebId { get; set; }
       		[ForeignKey("WebId")]
        	public Class? Web { get; set; }
    }
}

