using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Capstone.Models
{
    public class Cuisine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Special characters are not allowed")]
        [StringLength(55, ErrorMessage = "Please shorten the cuisine title to 55 characters")]
        public string Title { get; set; }

        public virtual List<Recipe> Recipes { get; set; }

    }
}
