using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Capstone.Models
{
    public class MealPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DayOfWeek { get; set; }

        [Required]
        public int RecipeId { get; set; }
    }
}
