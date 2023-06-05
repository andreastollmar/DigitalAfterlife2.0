using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DigitalAfterlife2._0.Data;
using DigitalAfterlife2._0.Models;

namespace DigitalAfterlife2._0.Pages.Admin.NextOfKinAdmin
{
    public class CreateModel : PageModel
    {
        private readonly DigitalAfterlife2._0.Data.ApplicationDbContext _context;

        public CreateModel(DigitalAfterlife2._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NextOfKin NextOfKin { get; set; } = default!;        

        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.NextOfKin == null || NextOfKin == null)
            {
                return Page();
            }

            _context.NextOfKin.Add(NextOfKin);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
