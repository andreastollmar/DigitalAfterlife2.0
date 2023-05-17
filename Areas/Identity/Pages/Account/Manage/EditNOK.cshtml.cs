using DigitalAfterlife2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DigitalAfterlife2._0.Areas.Identity.Pages.Account.Manage
{
    public class EditNOKModel : PageModel
    {
        private readonly DigitalAfterlife2._0.Data.ApplicationDbContext _context;

        public EditNOKModel(DigitalAfterlife2._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public NextOfKin NextOfKin { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            NextOfKin = _context.NextOfKin.Where(x => x.LoginId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            
                
                
            var user = _context.NextOfKin.Where(x => x.LoginId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
                
            // kolla vad som behöver vara kvar

            NextOfKin.LoginId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            user.City = NextOfKin.City;
            user.LastName = NextOfKin.LastName;
            user.PhoneNumber = NextOfKin.PhoneNumber;
            user.Email = NextOfKin.Email;
            user.StreetAddress = NextOfKin.StreetAddress;
            user.ZipCode = NextOfKin.ZipCode;
            user.LoginId = NextOfKin.LoginId;
            user.Country = NextOfKin.Country;
            user.Gender = NextOfKin.Gender;
            _context.NextOfKin.Update(user);
            await _context.SaveChangesAsync();
                
            


            return RedirectToPage("/Portal/Portal");
        }
    }
}
