using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectJunior.Models
{
	public class OrdDrug
	{
        public int Id { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int Price { get; set; }

        [Required]
        public int OrdId { get; set; }
        [ForeignKey("OrdId")]
        public Ord? Ord { get; set; }
        [Required]
        public int DrugId { get; set; }
        [ForeignKey("DrugId")]
        public Drug? Drug { get; set; }
        [Required]
        public int DiscountId { get; set; }
        [ForeignKey("DiscountId")]
        public Discount? Discount { get; set; }
    }
}

