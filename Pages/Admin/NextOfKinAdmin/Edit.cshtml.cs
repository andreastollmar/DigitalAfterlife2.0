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

namespace DigitalAfterlife2._0.Pages.Admin.NextOfKinAdmin
{
    public class EditModel : PageModel
    {
        private readonly DigitalAfterlife2._0.Data.ApplicationDbContext _context;

        public EditModel(DigitalAfterlife2._0.Data.ApplicationDbContext context)
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

            var nextofkin =  await _context.NextOfKin.FirstOrDefaultAsync(m => m.Id == id);
            if (nextofkin == null)
            {
                return NotFound();
            }
            NextOfKin = nextofkin;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NextOfKin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NextOfKinExists(NextOfKin.Id))
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

        private bool NextOfKinExists(int id)
        {
          return (_context.NextOfKin?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
