using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Capstone.Models
{
    public class Ingredient
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Please shorten the product title to 30 characters")]
        public string Quantity { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please shorten the Ingredient Name to 55 characters")]
        public string Title { get; set; }

        public Recipe Recipe { get; set; }
    }
}
