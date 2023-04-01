using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace ProjectJunior.Models
{
	public class RecipeDrug
	{
        public int Id { get; set; }
        [Required]
        public int Count { get; set; }

        [Required]
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        [Required]
        public int DrugId { get; set; }
        public Drug? Drug { get; set; }

    }
}

