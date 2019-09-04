using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Capstone.Models
{
    public class Instruction
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "You can only have a maximum of 10 steps in a recipe")]
        public int InstructionNumber { get; set; }

        [Required]
        public string InstructionText { get; set; }
    }   
}
