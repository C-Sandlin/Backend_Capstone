using System;
using System.Collections.Generic;
using System.Text;
using Backend_Capstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend_Capstone.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Cuisine> Cuisine { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Instruction> Instruction { get; set; }
        public DbSet<MealPlan> MealPlan { get; set; }
        public DbSet<Recipe> Recipe { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<Recipe>()
                .Property(r => r.DateAdded)
                .HasDefaultValueSql("GETDATE()");

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Shelby",
                LastName = "Sandlin",
                UserName = "shelby@shelby.com",
                NormalizedUserName = "SHELBY@SHELBY.COM",
                Email = "shelby@shelby.com",
                NormalizedEmail = "SHELBY@SHELBY.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Password1!");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<Cuisine>().HasData(
                new Cuisine()
                {
                    Id = 1,
                    Title = "Mexican"
                },
                new Cuisine()
                {
                    Id = 2,
                    Title = "Italian"
                },
                new Cuisine()
                {
                    Id = 3,
                    Title = "Mediterranean"
                },
                new Cuisine()
                {
                    Id = 4,
                    Title = "Thai"
                },
                new Cuisine()
                {
                    Id = 5,
                    Title = "Greek"
                },
                new Cuisine()
                {
                    Id = 6,
                    Title = "Japanese"
                },
                new Cuisine()
                {
                    Id = 7,
                    Title = "Island Pacific"
                },
                new Cuisine()
                {
                    Id = 8,
                    Title = "American"
                },
                new Cuisine()
                {
                    Id = 9,
                    Title = "Cuban"
                },
                new Cuisine()
                {
                    Id = 10,
                    Title = "Cajun"
                }
            );


            modelBuilder.Entity<Recipe>().HasData(
               new Recipe()
               {
                   Id = 1,
                   ImageUrl = "~/images/1567107648779-c20533fc-0c42-4641-99cf-76f4227f6b52.jpg",
                   Title = "Lemon Feta Chicken",
                   PrepTime = 15,
                   CookTime = 20,
                   Servings = 4,
                   Description = "A weeknight dinner party is easy with this chicken dinner that’s special enough for company. Pair it with roasted potatoes and steamed broccoli with fresh herbs to satisfy all your guests, even those who eat gluten-free.",
                   CuisineId = 5,
                   ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff"
               },
               new Recipe()
               {
                   Id = 2,
                   ImageUrl = "~/images/1567095407907-00000000-ffff-ffff-ffff-ffffffffffff.jpg",
                   Title = "Honey Sriracha Salmon",
                   PrepTime = 10,
                   CookTime = 20,
                   Servings = 2,
                   Description = "Salmon is amazing any way you prepare it, but this is one of my favorite ways. Marinate the salmon in a sweet and spicy honey sriracha sauce and cook to perfection. It’s the perfect combination of sweet and spicy and unbelievably easy to prepare.",
                   CuisineId = 4,
                   ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff"
               }
             );

            modelBuilder.Entity<Instruction>().HasData(
               new Instruction()
               {
                   Id = 1,
                   RecipeId = 1,
                   InstructionNumber = 1,
                   InstructionText = "Preheat oven to 425."
               },
               new Instruction()
               {
                   Id = 2,
                   RecipeId = 1,
                   InstructionNumber = 2,
                   InstructionText = "Place chicken thighs in large ziploc bag."
               },
               new Instruction()
               {
                   Id = 3,
                   RecipeId = 1,
                   InstructionNumber = 3,
                   InstructionText = "Pour lemon juice and oregano in bag.  Shake bag to coat chicken completely. Let marinate for at leat 20 min."
               },
               new Instruction()
               {
                   Id = 4,
                   RecipeId = 1,
                   InstructionNumber = 4,
                   InstructionText = "Place chicken in oven proof dish and cook for 15-25 min depending on size of thighs."
               },
               new Instruction()
               {
                   Id = 5,
                   RecipeId = 1,
                   InstructionNumber = 5,
                   InstructionText = "Remove from oven. Top with feta and put back in oven for 2 min until feta is lightly browned."
               },
               new Instruction()
               {
                   Id = 6,
                   RecipeId = 2,
                   InstructionNumber = 1,
                   InstructionText = "In gallon zip-loc bag or large bowl, combine soy sauce, honey, vinegar, sriracha, ginger, and garlic.Test it out and feel free to add more of anything."
               },
               new Instruction()
               {
                   Id = 7,
                   RecipeId = 2,
                   InstructionNumber = 2,
                   InstructionText = "Add the salmon and toss to coat. Refrigerate at least 1 hour or longer for even better flavor."
               },
               new Instruction()
               {
                   Id = 8,
                   RecipeId = 2,
                   InstructionNumber = 3,
                   InstructionText = "Remove salmon from bag or bowl. Reserve leftover marinade."
               },
               new Instruction()
               {
                   Id = 9,
                   RecipeId = 2,
                   InstructionNumber = 4,
                   InstructionText = "Heat large saute pan over medium-high heat and add the sesame oil. Coat pan evenly."
               },
               new Instruction()
               {
                   Id = 10,
                   RecipeId = 2,
                   InstructionNumber = 5,
                   InstructionText = "Add salmon and cook until one side is browned (about 5 min). Flip and cook until other side is browned (another 5 min)."
               },
               new Instruction()
               {
                   Id = 11,
                   RecipeId = 2,
                   InstructionNumber = 6,
                   InstructionText = "Reduce heat to low and pour in the reserved marinade. Cover and cook until fish is cooked through (about 6-7 more minutes)."
               }
            );

            modelBuilder.Entity<Ingredient>().HasData(
               new Ingredient()
               {
                   Id = 1,
                   RecipeId = 1,
                   Quantity = "4",
                   Title = "medium chicken thighs"
               },
               new Ingredient()
               {
                   Id = 2,
                   RecipeId = 1,
                   Quantity = "1/2 cup",
                   Title = "lemon juice"
               },
               new Ingredient()
               {
                   Id = 3,
                   RecipeId = 1,
                   Quantity = "3 tbs",
                   Title = "dried oregano"
               },
               new Ingredient()
               {
                   Id = 4,
                   RecipeId = 1,
                   Quantity = "1/4 cup",
                   Title = "feta cheese"
               },
               new Ingredient()
               {
                   Id = 5,
                   RecipeId = 2,
                   Quantity = "2",
                   Title = "6oz pieces of salmon"
               },
               new Ingredient()
               {
                   Id = 6,
                   RecipeId = 2,
                   Quantity = "1/4 cup",
                   Title = "reduced sodium soy sauce"
               },
               new Ingredient()
               {
                   Id = 7,
                   RecipeId = 2,
                   Quantity = "1 1/2 tbsp",
                   Title = "honey"
               },
               new Ingredient()
               {
                   Id = 8,
                   RecipeId = 2,
                   Quantity = "3.4 tbsp",
                   Title = "rice vinegar"
               },
               new Ingredient()
               {
                   Id = 9,
                   RecipeId = 2,
                   Quantity = "1/2 tbsp",
                   Title = "sriracha"
               },
               new Ingredient()
               {
                   Id = 10,
                   RecipeId = 2,
                   Quantity = "1 tsp",
                   Title = "ground ginger"
               },
               new Ingredient()
               {
                   Id = 11,
                   RecipeId = 2,
                   Quantity = "2 cloves",
                   Title = "minced garlic"
               },
               new Ingredient()
               {
                   Id = 12,
                   RecipeId = 2,
                   Quantity = "1 tsp",
                   Title = "sesame oil"
               },
               new Ingredient()
               {
                   Id = 13,
                   RecipeId = 2,
                   Quantity = "1 tbsp",
                   Title = "chopped scallions"
               }
            );
        }
    }
}
