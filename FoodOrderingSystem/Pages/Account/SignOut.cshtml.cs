using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodOrderingSystem.Pages.Account
{
    public class SignOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();
            
            return RedirectToPage("/Index");
        }
        
        public IActionResult OnPost()
        {
            HttpContext.Session.Clear();
            
            return RedirectToPage("/Index");
        }
    }
}