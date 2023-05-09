using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DigitalAfterlife2._0.Data;
using DigitalAfterlife2._0.Models;

namespace DigitalAfterlife2._0.Pages.Admin.PerishedAdmin
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
        ViewData["NextOfKinId"] = new SelectList(_context.NextOfKin, "Id", "Id");
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

            _context.Perished.Add(Perished);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
