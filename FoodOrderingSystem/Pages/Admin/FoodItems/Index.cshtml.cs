using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodOrderingSystem.Data;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingSystem.Pages.Admin.FoodItems
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<FoodItem> FoodItems { get; set; } = new List<FoodItem>();

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!AuthHelper.IsAdmin(HttpContext))
            {
                return RedirectToPage("/Account/Login", new { returnUrl = "/Admin/FoodItems" });
            }

            FoodItems = await _context.FoodItems.ToListAsync();
            return Page();
        }
    }
}
