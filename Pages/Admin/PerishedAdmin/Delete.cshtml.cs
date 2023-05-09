using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DigitalAfterlife2._0.Data;
using DigitalAfterlife2._0.Models;

namespace DigitalAfterlife2._0.Pages.Admin.PerishedAdmin
{
    public class DeleteModel : PageModel
    {
        private readonly DigitalAfterlife2._0.Data.ApplicationDbContext _context;

        public DeleteModel(DigitalAfterlife2._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Perished Perished { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Perished == null)
            {
                return NotFound();
            }

            var perished = await _context.Perished.FirstOrDefaultAsync(m => m.Id == id);

            if (perished == null)
            {
                return NotFound();
            }
            else 
            {
                Perished = perished;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Perished == null)
            {
                return NotFound();
            }
            var perished = await _context.Perished.FindAsync(id);

            if (perished != null)
            {
                Perished = perished;
                _context.Perished.Remove(Perished);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
