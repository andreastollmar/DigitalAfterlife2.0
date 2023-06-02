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


        public async Task<IActionResult> OnGetAsync(int deleteId)
        {

            var check = _context.NextOfKin.Where(x => x.LoginId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();

            if (check != null)
            {
                Perished = _context.Perished.Where(x => x.NextOfKinId == check.Id).ToList();
            }

            if(deleteId != 0)
            {
                var persihedToDelete = await _context.Perished.FindAsync(deleteId);
                if(persihedToDelete != null)
                {
                    _context.Perished.Remove(persihedToDelete);
                    await _context.SaveChangesAsync();
                }
                
            }

            return Page();
        }
    }
}
