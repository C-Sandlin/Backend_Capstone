using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backend_Capstone.Data;
using Backend_Capstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Backend_Capstone.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public FavoritesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        
        // GET: Favorites
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var favRecipes = await _context.Favorite
                                            .Include(fav => fav.Recipe)
                                                .ThenInclude(r => r.Ingredients)
                                            .Include(f => f.Recipe)
                                                .ThenInclude(r => r.Instructions)
                                            .Where(f => f.ApplicationUserId == user.Id)
                                            .ToListAsync();
            favRecipes.ForEach(fav => fav.Recipe.Instructions.OrderBy(i => i.InstructionNumber));
            return View(favRecipes);
        }
      

        // GET: Favorites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Favorites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFavorite([Bind("Id,ApplicationUserId,RecipeId")] int id)
        {

            var user = await GetCurrentUserAsync();

            var Fav = new Favorite()
            {
                ApplicationUserId = user.Id,
                RecipeId = id
            };

            if (ModelState.IsValid)
            {
                _context.Add(Fav);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Favorites");
            }
            else
            {
                return NotFound();
            }
           
        }


        // POST: Favorites/Delete/5
        [HttpPost, ActionName("RemoveFavorite")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFavorite(int id)
        {
            var user = await GetCurrentUserAsync();
            var recipe = await _context.Recipe.Where(r => r.Id == id).FirstOrDefaultAsync();

            var JT = await _context.Favorite.Where(f => f.RecipeId == id && f.ApplicationUserId == user.Id).FirstOrDefaultAsync();
            var favorite = await _context.Favorite.FindAsync(JT.Id);
            _context.Favorite.Remove(favorite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoriteExists(int id)
        {
            return _context.Favorite.Any(e => e.Id == id);
        }
    }
}
