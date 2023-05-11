using DigitalAfterlife2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DigitalAfterlife2._0.Pages.Portal
{
    public class PersonuppgifterModel : PageModel
    {
        private readonly DigitalAfterlife2._0.Data.ApplicationDbContext _context;

        public PersonuppgifterModel(DigitalAfterlife2._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            NextOfKin = _context.NextOfKin.Where(x => x.LoginId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
            return Page();
        }

        [BindProperty]
        public NextOfKin NextOfKin { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.NextOfKin == null || NextOfKin == null)
            {
                return Page();
            }
            else
            {
                var user = _context.NextOfKin.Where(x => x.LoginId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
                if (user == null)
                {
                    NextOfKin.LoginId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    _context.NextOfKin.Add(NextOfKin);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    NextOfKin.LoginId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    _context.NextOfKin.Update(NextOfKin);
                    await _context.SaveChangesAsync();
                }
            }


            return RedirectToPage("/Portal/Portal");
        }
    }
}
