using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Capstone.Models
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }

        
        public virtual Recipe Recipe { get; set; }

    }
}
