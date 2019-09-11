using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backend_Capstone.Data;
using Backend_Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;

namespace Backend_Capstone.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _env;

        public RecipesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHostingEnvironment env)
        {
            _env = env;
            _context = context;
            _userManager = userManager;
        }

        // GET: All Recipes
        public async Task<IActionResult> Index()
        {

            var allRecipes = await _context.Recipe
                                            .Include(r => r.Ingredients)
                                            .Include(r => r.Instructions)
                                            .ToListAsync();
            allRecipes.ForEach(recipe => recipe.Instructions.OrderBy(i => i.InstructionNumber));
            return View(allRecipes);
        }

        // GET: my recipes
        public async Task<IActionResult> MyRecipes()
        {
            var user = await GetCurrentUserAsync();

            var myRecipes = await _context.Recipe
                                            .Include(r => r.Ingredients)
                                            .Include(r => r.Instructions)
                                            .Where(r => r.User.Id == user.Id)
                                            .ToListAsync();
            myRecipes.ForEach(recipe => recipe.Instructions.OrderBy(i => i.InstructionNumber));
            return View(myRecipes);
        }

        // GET: most recent
        public async Task<IActionResult> RecentRecipes()
        {
            var user = await GetCurrentUserAsync();

            var myRecipes = await _context.Recipe
                                            .Include(r => r.Ingredients)
                                            .Include(r => r.Instructions)
                                            .OrderByDescending(r => r.DateAdded)
                                            .Take(5)
                                            .ToListAsync();
            myRecipes.ForEach(recipe => recipe.Instructions.OrderBy(i => i.InstructionNumber));
            return View(myRecipes);
        }

        


        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await GetCurrentUserAsync();
            var favRecipes = await _context.Favorite
                                           .Include(fav => fav.Recipe)
                                               .ThenInclude(r => r.Ingredients)
                                           .Include(f => f.Recipe)
                                               .ThenInclude(r => r.Instructions)
                                           .Where(f => f.ApplicationUserId == user.Id)
                                           .ToListAsync();

            user.FavoriteRecipes = favRecipes;

            var recipe = await _context.Recipe
                .Include(r => r.User)
                .Include(r => r.Ingredients)
                .Include(r => r.Instructions)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["CuisineId"] = new SelectList(_context.Cuisine.OrderBy(c => c.Title), "Id", "Title");
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageUrl,Title,PrepTime,CookTime,Servings,Description,CuisineId,ApplicationUserId,DateAdded,Ingredients,Instructions")] Recipe recipe, IFormFile file)
        {
            var user = await GetCurrentUserAsync();

            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                recipe.ApplicationUserId = user.Id;

                try
                {
                    recipe.ImageUrl = await SaveFile(file, user.Id);
                }
                catch (Exception ex)
                {
                    return NotFound();
                }

                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CuisineId"] = new SelectList(_context.Cuisine.OrderBy(c => c.Title), "Id", "Title");
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                                .Include(r => r.User)
                                .Include(r => r.Ingredients)
                                .Include(r => r.Instructions)
                                .FirstOrDefaultAsync(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            ViewData["CuisineId"] = new SelectList(_context.Cuisine.OrderBy(c => c.Title), "Id", "Title");
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageUrl,Title,PrepTime,CookTime,Servings,Description,CuisineId,ApplicationUserId,DateAdded,Ingredients,Instructions")] Recipe recipe)
        {
            var user = await GetCurrentUserAsync();
            var fetchedRecipe = await _context.Recipe
                                .Include(r => r.User)
                                .Include(r => r.Ingredients)
                                .Include(r => r.Instructions)
                                .FirstOrDefaultAsync(r => r.Id == id);

            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //this remains same
                _context.Entry(fetchedRecipe).CurrentValues.SetValues(recipe);
                
                // loop through exising ingredients - if match with passed in ingredient, remove the existing ingredient
                foreach(var existIngredient in fetchedRecipe.Ingredients.ToList())
                {
                    if (!recipe.Ingredients.Any(c => c.Id == existIngredient.Id))
                        _context.Ingredient.Remove(existIngredient);
                }

                foreach (var existInstruction in fetchedRecipe.Instructions.ToList())
                {
                    if (!recipe.Instructions.Any(c => c.Id == existInstruction.Id))
                        _context.Instruction.Remove(existInstruction);
                }


                foreach (var passedInIngredient in recipe.Ingredients)
                {
                    var existingIngredient = fetchedRecipe.Ingredients.Where(i => i.Id == passedInIngredient.Id).SingleOrDefault();
                    if(existingIngredient != null)
                    {
                        _context.Entry(existingIngredient).CurrentValues.SetValues(passedInIngredient);
                    } else
                    {
                        var newIngredient = new Ingredient
                        {
                            RecipeId = id,
                            Quantity = passedInIngredient.Quantity,
                            Title = passedInIngredient.Title
                        };
                        fetchedRecipe.Ingredients.Add(newIngredient);
                    }
                }

                foreach (var passedInInstruction in recipe.Instructions)
                {
                    var existingInstruction = fetchedRecipe.Instructions.Where(i => i.Id == passedInInstruction.Id).SingleOrDefault();
                    if (existingInstruction != null)
                    {
                        _context.Entry(existingInstruction).CurrentValues.SetValues(passedInInstruction);
                    }
                    else
                    {
                        var newInstruction = new Instruction
                        {
                            RecipeId = id,
                            InstructionNumber = passedInInstruction.InstructionNumber,
                            InstructionText = passedInInstruction.InstructionText
                        };
                        fetchedRecipe.Instructions.Add(newInstruction);
                    }
                }
                try
                {
                    //_context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipe.FindAsync(id);
            _context.Recipe.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.Id == id);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        private async Task<string> SaveFile(IFormFile file, string userId)
        {
            if (file.Length > 5242880) throw new Exception("File too large!");
            var ext = GetMimeType(file.FileName);
            if (ext == null) throw new Exception("Invalid file type");
            var epoch = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();
            var fileName = $"{epoch}-{userId}.{ext}";
            var webRoot = _env.WebRootPath;
            var absoluteFilePath = Path.Combine(
                webRoot,
                "images",
                fileName);
            string relFilePath = null;
            if (file.Length > 0)
            {
                using (var stream = new FileStream(absoluteFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    relFilePath = $"~/images/{fileName}";
                };
            }
            return relFilePath;
        }
        private string GetMimeType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            provider.TryGetContentType(fileName, out contentType);
            if (contentType == "image/jpeg") contentType = "jpg";
            else contentType = null;
            return contentType;
        }
    }
}
