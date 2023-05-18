using DigitalAfterlife2._0.Helpers;
using DigitalAfterlife2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAfterlife2._0.Pages.Admin
{
    public class ApiServicesModel : PageModel
    {
        private readonly APIDependency _apiDependency;

        public ApiServicesModel(APIDependency apiDependency)
        {
            _apiDependency = apiDependency;
        }

        [BindProperty]
        public StreamingService NewStreamingService { get; set; }

        public List<StreamingService> StreamingServices { get; set; }
        public async Task<IActionResult> OnGetAsync(int deleteIndex, int editId)
        {
            StreamingServices = await _apiDependency.GetStreamingServices();

            if (deleteIndex != 0)
            {
                await _apiDependency.DeleteStreamingService(deleteIndex - 1);
                StreamingServices = await _apiDependency.GetStreamingServices();
            }
            if (editId != 0)
            {
                NewStreamingService = await _apiDependency.GetOneStreamService(editId);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                await _apiDependency.SaveNewStreamingService(NewStreamingService);
            }
            StreamingServices = await _apiDependency.GetStreamingServices();
            return RedirectToPage("./ApiServices");
        }
    }
}
