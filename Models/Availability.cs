using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectJunior.Models
{
	public class Availability
	{
		public int Id { get; set; }
		[Required]
		public int Count { get; set; }

		[Required]
		public int PharmacyId { get; set; }
        	[ForeignKey("PharmacyId")]
		public Pharmacy? Pharmacy { get; set; }
        	[Required]
		public int DrugId { get; set; }
        	[ForeignKey("DrugId")]
		public Drug? Drug { get; set; }
        	[Required]
		public int DeliveryId { get; set; }
        	[ForeignKey("DeliveryId")]
		public Delivery? Delivery { get; set; }
    	}
}

