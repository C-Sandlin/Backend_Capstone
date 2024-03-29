﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Capstone.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        public virtual List<Favorite> FavoriteRecipes { get; set; }

        [NotMapped]
        public virtual List<MealPlan> WeeklyRecipes { get; set; }

        [NotMapped]
        public virtual List<MealPlan> AdminRecipes { get; set; }
    }
}
