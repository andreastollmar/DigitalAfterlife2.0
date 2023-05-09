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
    public class DetailsModel : PageModel
    {
        private readonly DigitalAfterlife2._0.Data.ApplicationDbContext _context;

        public DetailsModel(DigitalAfterlife2._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
