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

namespace Backend_Capstone.Controllers
{
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
            //favRecipes.ForEach(fav => fav.recipe.Instructions.OrderBy(i => i.InstructionNumber));
            return View(favRecipes);
        }
        // GET: Favorites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorite = await _context.Favorite
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favorite == null)
            {
                return NotFound();
            }

            return View(favorite);
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
        public async Task<IActionResult> Create([Bind("Id,ApplicationUserId,RecipeId")] Favorite favorite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favorite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(favorite);
        }

        // GET: Favorites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorite = await _context.Favorite.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }
            return View(favorite);
        }

        // POST: Favorites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUserId,RecipeId")] Favorite favorite)
        {
            if (id != favorite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favorite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteExists(favorite.Id))
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
            return View(favorite);
        }

        // GET: Favorites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorite = await _context.Favorite
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favorite == null)
            {
                return NotFound();
            }

            return View(favorite);
        }

        // POST: Favorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favorite = await _context.Favorite.FindAsync(id);
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
