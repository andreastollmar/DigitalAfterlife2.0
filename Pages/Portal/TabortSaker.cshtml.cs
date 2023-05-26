using DigitalAfterlife2._0.Helpers;
using DigitalAfterlife2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace DigitalAfterlife2._0.Pages.Portal
{
    public class TabortSakerModel : PageModel
    {
        private readonly APIDependency _apiDependency;
        private readonly Data.ApplicationDbContext _context;

        public TabortSakerModel(APIDependency apiDependency, Data.ApplicationDbContext context)
        {
            _apiDependency = apiDependency;
            _context = context;

        }

        [BindProperty]
        public List<StreamingService> StreamingServices { get; set; } = new List<StreamingService>();
        [BindProperty]
        public ServiceToDelete ServiceToDelete { get; set; }

        public List<Models.Perished> PerishedList { get; set; }

        public Models.NextOfKin NextOfKin { get; set; }



        public async Task<IActionResult> OnGetAsync()
        {
            StreamingServices = await _apiDependency.GetStreamingServices();
            NextOfKin =  _context.NextOfKin.Where(x => x.LoginId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
            PerishedList = _context.Perished.Where(x => x.NextOfKinId == NextOfKin.Id).ToList();



            ViewData["PerishedId"] = new SelectList(_context.Perished.Where(x => x.NextOfKinId == NextOfKin.Id), "Id", "FirstName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string trueService = "";

            foreach (var service in StreamingServices)
            {
                if (service.IsChecked == true)
                {
                    trueService += service.Name + ",";
                }                
            }
            trueService = trueService.Substring(0, trueService.Length - 1);
            ServiceToDelete.True = trueService;
            _context.Add(ServiceToDelete);
            await _context.SaveChangesAsync();
            return RedirectToPage("Portal");
        }
    }
}
