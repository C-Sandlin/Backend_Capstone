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
    public class MealPlansController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public MealPlansController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {

            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: MealPlans
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var userMealPlan = await _context.MealPlan
                                             .Where(mp => mp.ApplicationUserId == user.Id)
                                             .Include(mp => mp.Recipe)
                                             .ToListAsync();
            user.WeeklyRecipes = userMealPlan;

            var adminMealPlan = await _context.MealPlan
                                             .Where(mp => mp.ApplicationUserId == "00000000-ffff-ffff-ffff-ffffffffffff")
                                             .Include(mp => mp.Recipe)
                                             .ToListAsync();
            user.AdminRecipes = adminMealPlan;

            return View(user);
        }

        // POST: MealPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DayOfWeek,RecipeId,ApplicationUserId")] int id, string dayOfWeek)
        {

            var user = await GetCurrentUserAsync();

            var newMP = new MealPlan()
            {
                ApplicationUserId = user.Id,
                RecipeId = id,
                DayOfWeek = dayOfWeek
            };

            if (ModelState.IsValid)
            {
                _context.Add(newMP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // POST: MealPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mealPlan = await _context.MealPlan.FindAsync(id);
            _context.MealPlan.Remove(mealPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealPlanExists(int id)
        {
            return _context.MealPlan.Any(e => e.Id == id);
        }

        // POST: MealPlans/Delete/5
        [HttpPost, ActionName("DeleteAll")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAll()
        {
            var user = await GetCurrentUserAsync();

            var mealPlan = await _context.MealPlan.Where(mp => mp.ApplicationUserId == user.Id).ToListAsync();
            _context.MealPlan.RemoveRange(mealPlan);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
