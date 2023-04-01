using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectJunior.Models
{
	public class RecipeDrug
	{
        public int Id { get; set; }
        [Required]
        public int Count { get; set; }

        [Required]
        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        public Recipe? Recipe { get; set; }
        [Required]
        public int DrugId { get; set; }
        [ForeignKey("DrugId")]
        public Drug? Drug { get; set; }
    }
}

