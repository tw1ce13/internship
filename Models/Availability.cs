using System;
using System.ComponentModel.DataAnnotations;
namespace ProjectJunior.Models
{
	public class Availability
	{
		public int Id { get; set; }
		[Required]
		public int Count { get; set; }

		[Required]
		public int PharmacyId { get; set; }
		public Pharmacy? Pharmacy { get; set; }
		[Required]
		public int DrugId { get; set; }
		public Drug? Drug { get; set; }
		[Required]
		public int DeliveryId { get; set; }
		public Delivery? Delivery { get; set; }
	}
}

