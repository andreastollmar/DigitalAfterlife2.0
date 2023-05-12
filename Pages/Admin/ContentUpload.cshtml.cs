using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAfterlife2._0.Pages.Admin
{
    public class ContentUploadModel : PageModel
    {

        public int? PageNr { get; set; }

        public IActionResult OnGet(string pageNr)
        {
            if (pageNr != null)
            {
                PageNr = int.Parse(pageNr);
            }
            return Page();
        }
    }
}
