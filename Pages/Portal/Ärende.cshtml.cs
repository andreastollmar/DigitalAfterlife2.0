using DigitalAfterlife2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DigitalAfterlife2._0.Pages.Portal
{
    public class ÄrendeModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public ÄrendeModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Perished>? Perished { get; set; }


        public IActionResult OnGet()
        {

            var check = _context.NextOfKin.Where(x => x.LoginId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();

            if (check != null)
            {
                Perished = _context.Perished.Where(x => x.NextOfKinId == check.Id).ToList();
            }

            return Page();
        }
    }
}
