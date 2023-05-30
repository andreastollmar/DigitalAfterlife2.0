using DigitalAfterlife2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DigitalAfterlife2._0.Pages.Portal
{
    public class PortalModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public PortalModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public int? PageNr { get; set; }

        public List<Perished>? Perished { get; set; }


        public IActionResult OnGet(string pageNr)
        {
            if (pageNr != null)
            {
                PageNr = int.Parse(pageNr);
            }
            var check = _context.NextOfKin.Where(x => x.LoginId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
            
            if (check == null)
            {
                return RedirectToPage("/Account/Manage/EditNOK", new { area = "Identity" });
            }
            if(check != null)
            {
                Perished = _context.Perished.Where(x => x.NextOfKinId == check.Id).ToList();

            }

            return Page();


        }
    }
}
