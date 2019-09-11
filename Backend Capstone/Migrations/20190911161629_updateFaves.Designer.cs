﻿// <auto-generated />
using System;
using Backend_Capstone.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend_Capstone.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190911161629_updateFaves")]
    partial class updateFaves
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend_Capstone.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "00000000-ffff-ffff-ffff-ffffffffffff",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d721b317-147f-4e5a-87d1-339b65909404",
                            Email = "shelby@shelby.com",
                            EmailConfirmed = true,
                            FirstName = "Shelby",
                            LastName = "Sandlin",
                            LockoutEnabled = false,
                            NormalizedEmail = "SHELBY@SHELBY.COM",
                            NormalizedUserName = "SHELBY@SHELBY.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEALpW4zTORaVSHBD5LpnAocrXHOlfVM68TXRIMHNJvqXmrSiEOyRyqh73XMeiGmi6g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                            TwoFactorEnabled = false,
                            UserName = "shelby@shelby.com"
                        });
                });

            modelBuilder.Entity("Backend_Capstone.Models.Cuisine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("Id");

                    b.ToTable("Cuisine");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Mexican"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Italian"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Mediterranean"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Thai"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Greek"
                        },
                        new
                        {
                            Id = 6,
                            Title = "Japanese"
                        },
                        new
                        {
                            Id = 7,
                            Title = "Island Pacific"
                        },
                        new
                        {
                            Id = 8,
                            Title = "American"
                        },
                        new
                        {
                            Id = 9,
                            Title = "Cuban"
                        },
                        new
                        {
                            Id = 10,
                            Title = "Cajun"
                        });
                });

            modelBuilder.Entity("Backend_Capstone.Models.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("RecipeId");

                    b.HasKey("Id");

                    b.ToTable("Favorite");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 2,
                            ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                            RecipeId = 29
                        });
                });

            modelBuilder.Entity("Backend_Capstone.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("RecipeId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredient");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Quantity = "4",
                            RecipeId = 1,
                            Title = "medium chicken thighs"
                        },
                        new
                        {
                            Id = 2,
                            Quantity = "1/2 cup",
                            RecipeId = 1,
                            Title = "lemon juice"
                        },
                        new
                        {
                            Id = 3,
                            Quantity = "3 tbs",
                            RecipeId = 1,
                            Title = "dried oregano"
                        },
                        new
                        {
                            Id = 4,
                            Quantity = "1/4 cup",
                            RecipeId = 1,
                            Title = "feta cheese"
                        },
                        new
                        {
                            Id = 5,
                            Quantity = "2",
                            RecipeId = 2,
                            Title = "6oz pieces of salmon"
                        },
                        new
                        {
                            Id = 6,
                            Quantity = "1/4 cup",
                            RecipeId = 2,
                            Title = "reduced sodium soy sauce"
                        },
                        new
                        {
                            Id = 7,
                            Quantity = "1 1/2 tbsp",
                            RecipeId = 2,
                            Title = "honey"
                        },
                        new
                        {
                            Id = 8,
                            Quantity = "3.4 tbsp",
                            RecipeId = 2,
                            Title = "rice vinegar"
                        },
                        new
                        {
                            Id = 9,
                            Quantity = "1/2 tbsp",
                            RecipeId = 2,
                            Title = "sriracha"
                        },
                        new
                        {
                            Id = 10,
                            Quantity = "1 tsp",
                            RecipeId = 2,
                            Title = "ground ginger"
                        },
                        new
                        {
                            Id = 11,
                            Quantity = "2 cloves",
                            RecipeId = 2,
                            Title = "minced garlic"
                        },
                        new
                        {
                            Id = 12,
                            Quantity = "1 tsp",
                            RecipeId = 2,
                            Title = "sesame oil"
                        },
                        new
                        {
                            Id = 13,
                            Quantity = "1 tbsp",
                            RecipeId = 2,
                            Title = "chopped scallions"
                        });
                });

            modelBuilder.Entity("Backend_Capstone.Models.Instruction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InstructionNumber");

                    b.Property<string>("InstructionText")
                        .IsRequired();

                    b.Property<int>("RecipeId");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Instruction");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InstructionNumber = 1,
                            InstructionText = "Preheat oven to 425.",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 2,
                            InstructionNumber = 2,
                            InstructionText = "Place chicken thighs in large ziploc bag.",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 3,
                            InstructionNumber = 3,
                            InstructionText = "Pour lemon juice and oregano in bag.  Shake bag to coat chicken completely. Let marinate for at leat 20 min.",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 4,
                            InstructionNumber = 4,
                            InstructionText = "Place chicken in oven proof dish and cook for 15-25 min depending on size of thighs.",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 5,
                            InstructionNumber = 5,
                            InstructionText = "Remove from oven. Top with feta and put back in oven for 2 min until feta is lightly browned.",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 6,
                            InstructionNumber = 1,
                            InstructionText = "In gallon zip-loc bag or large bowl, combine soy sauce, honey, vinegar, sriracha, ginger, and garlic.Test it out and feel free to add more of anything.",
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 7,
                            InstructionNumber = 2,
                            InstructionText = "Add the salmon and toss to coat. Refrigerate at least 1 hour or longer for even better flavor.",
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 8,
                            InstructionNumber = 3,
                            InstructionText = "Remove salmon from bag or bowl. Reserve leftover marinade.",
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 9,
                            InstructionNumber = 4,
                            InstructionText = "Heat large saute pan over medium-high heat and add the sesame oil. Coat pan evenly.",
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 10,
                            InstructionNumber = 5,
                            InstructionText = "Add salmon and cook until one side is browned (about 5 min). Flip and cook until other side is browned (another 5 min).",
                            RecipeId = 2
                        },
                        new
                        {
                            Id = 11,
                            InstructionNumber = 6,
                            InstructionText = "Reduce heat to low and pour in the reserved marinade. Cover and cook until fish is cooked through (about 6-7 more minutes).",
                            RecipeId = 2
                        });
                });

            modelBuilder.Entity("Backend_Capstone.Models.MealPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DayOfWeek")
                        .IsRequired();

                    b.Property<int>("RecipeId");

                    b.HasKey("Id");

                    b.ToTable("MealPlan");
                });

            modelBuilder.Entity("Backend_Capstone.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("CookTime");

                    b.Property<int>("CuisineId");

                    b.Property<DateTime>("DateAdded")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ImageUrl");

                    b.Property<int>("PrepTime");

                    b.Property<int>("Servings");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Recipe");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                            CookTime = 20,
                            CuisineId = 5,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A weeknight dinner party is easy with this chicken dinner that’s special enough for company. Pair it with roasted potatoes and steamed broccoli with fresh herbs to satisfy all your guests, even those who eat gluten-free.",
                            ImageUrl = "~/images/1567107648779-c20533fc-0c42-4641-99cf-76f4227f6b52.jpg",
                            PrepTime = 15,
                            Servings = 4,
                            Title = "Lemon Feta Chicken"
                        },
                        new
                        {
                            Id = 2,
                            ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                            CookTime = 20,
                            CuisineId = 4,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Salmon is amazing any way you prepare it, but this is one of my favorite ways. Marinate the salmon in a sweet and spicy honey sriracha sauce and cook to perfection. It’s the perfect combination of sweet and spicy and unbelievably easy to prepare.",
                            ImageUrl = "~/images/1567095407907-00000000-ffff-ffff-ffff-ffffffffffff.jpg",
                            PrepTime = 10,
                            Servings = 2,
                            Title = "Honey Sriracha Salmon"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Backend_Capstone.Models.Ingredient", b =>
                {
                    b.HasOne("Backend_Capstone.Models.Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend_Capstone.Models.Instruction", b =>
                {
                    b.HasOne("Backend_Capstone.Models.Recipe")
                        .WithMany("Instructions")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Backend_Capstone.Models.Recipe", b =>
                {
                    b.HasOne("Backend_Capstone.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Backend_Capstone.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Backend_Capstone.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Backend_Capstone.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Backend_Capstone.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
