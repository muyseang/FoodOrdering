using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodOrderingSystem.Helpers;

namespace FoodOrderingSystem.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (!AuthHelper.IsAdmin(HttpContext))
            {
                return RedirectToPage("/Account/Login", new { returnUrl = "/Admin" });
            }
            return Page();
        }
    }
}
