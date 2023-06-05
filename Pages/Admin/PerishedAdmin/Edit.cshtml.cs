using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigitalAfterlife2._0.Data;
using DigitalAfterlife2._0.Models;

namespace DigitalAfterlife2._0.Pages.Admin.PerishedAdmin
{
    public class EditModel : PageModel
    {
        private readonly DigitalAfterlife2._0.Data.ApplicationDbContext _context;

        public EditModel(DigitalAfterlife2._0.Data.ApplicationDbContext context)
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

            var perished =  await _context.Perished.FirstOrDefaultAsync(m => m.Id == id);
            if (perished == null)
            {
                return NotFound();
            }
            Perished = perished;
           ViewData["NextOfKinId"] = new SelectList(_context.NextOfKin, "Id", "FirstName");
            return Page();
        }
       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Perished).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerishedExists(Perished.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PerishedExists(int id)
        {
          return (_context.Perished?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
