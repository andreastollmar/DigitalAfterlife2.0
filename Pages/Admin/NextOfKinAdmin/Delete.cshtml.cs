using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DigitalAfterlife2._0.Data;
using DigitalAfterlife2._0.Models;

namespace DigitalAfterlife2._0.Pages.Admin.NextOfKinAdmin
{
    public class DeleteModel : PageModel
    {
        private readonly DigitalAfterlife2._0.Data.ApplicationDbContext _context;

        public DeleteModel(DigitalAfterlife2._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public NextOfKin NextOfKin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.NextOfKin == null)
            {
                return NotFound();
            }

            var nextofkin = await _context.NextOfKin.FirstOrDefaultAsync(m => m.Id == id);

            if (nextofkin == null)
            {
                return NotFound();
            }
            else 
            {
                NextOfKin = nextofkin;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.NextOfKin == null)
            {
                return NotFound();
            }
            var nextofkin = await _context.NextOfKin.FindAsync(id);

            if (nextofkin != null)
            {
                NextOfKin = nextofkin;
                _context.NextOfKin.Remove(NextOfKin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
