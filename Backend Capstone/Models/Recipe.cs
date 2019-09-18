using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Capstone.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        
        
        public string ImageUrl { get; set; }

        [Required]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Special characters are not allowed")]
        [StringLength(55, ErrorMessage = "Please shorten the recipe title to 55 characters")]
        public string Title { get; set; }

        [Required]
        [Range(1, 1440, ErrorMessage = "Prep time must be between 1 and 1440 minutes")]
        public int PrepTime { get; set; }

        [Required]
        [Range(1, 1440, ErrorMessage = "Cook time must be between 1 and 1440 minutes")]
        public int CookTime { get; set; }

        [NotMapped]
        public int TotalTime
        {
            get { return PrepTime + CookTime; }
        }



        [Required]
        [Range(1, 20, ErrorMessage = "Servings must be between 1 and 20 people")]
        public int Servings { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CuisineId { get; set; }

        public Cuisine Cuisine { get; set; }
        
        public string ApplicationUserId { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateAdded { get; set; }

        public virtual List<Ingredient> Ingredients { get; set; }
        public virtual List<Instruction> Instructions { get; set; }

        public ApplicationUser User { get; set; }

    }
}
