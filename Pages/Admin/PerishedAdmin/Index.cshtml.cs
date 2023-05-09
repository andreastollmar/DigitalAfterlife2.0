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
    public class IndexModel : PageModel
    {
        private readonly DigitalAfterlife2._0.Data.ApplicationDbContext _context;

        public IndexModel(DigitalAfterlife2._0.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Perished> Perished { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Perished != null)
            {
                Perished = await _context.Perished
                .Include(p => p.NextOfKin).ToListAsync();
            }
        }
    }
}
