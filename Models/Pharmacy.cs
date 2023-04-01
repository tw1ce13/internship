using System;
using System.ComponentModel.DataAnnotations;
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
        public Web? Web { get; set; }
	}
}

