using DigitalAfterlife2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace DigitalAfterlife2._0.Pages.Portal
{
    public class PerishedInfoModel : PageModel
    {
        private readonly DigitalAfterlife2._0.Data.ApplicationDbContext _context;

        public PerishedInfoModel(DigitalAfterlife2._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            
            return Page();
        }

        [BindProperty]
        public Perished Perished { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Perished == null || Perished == null)
            {
                return Page();
            }
            Perished.NextOfKinId = _context.NextOfKin.Where(x => x.LoginId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault().Id;
            _context.Perished.Add(Perished);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Portal/Portal");
        }
    }
}
