using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectJunior.Models
{
	public class Delivery
	{
		public int Id { get; set; }
		public DateTime CreateData { get; set; }
		[Required]
		public DateTime ExpirationData { get; set; }
	}
}

