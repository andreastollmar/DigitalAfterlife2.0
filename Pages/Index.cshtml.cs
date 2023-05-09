using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DigitalAfterlife2._0.Pages
{
    public class IndexModel : PageModel
    {
        
        public string UserCheck { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            UserCheck = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(UserCheck != null)
            {
                return RedirectToPage("/Portal/Portal");
            }
            return Page();
        }
    }
}