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

        // GET: MealPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealPlan = await _context.MealPlan.FindAsync(id);
            if (mealPlan == null)
            {
                return NotFound();
            }
            return View(mealPlan);
        }

        // POST: MealPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DayOfWeek,RecipeId,ApplicationUserId")] MealPlan mealPlan)
        {
            if (id != mealPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mealPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealPlanExists(mealPlan.Id))
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
            return View(mealPlan);
        }

        // GET: MealPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealPlan = await _context.MealPlan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mealPlan == null)
            {
                return NotFound();
            }

            return View(mealPlan);
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
    }
}
