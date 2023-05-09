using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using DigitalAfterlife2._0.Data;
using DigitalAfterlife2._0.Models;

namespace DigitalAfterlife2._0.Pages.Portal
{
    public class DeathcertModel : PageModel
    {

        private readonly Data.ApplicationDbContext _context;

        public DeathcertModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }


        [BindProperty]
        public IFormFile UploadedDeathcert { get; set; }

        [BindProperty]
        public Models.File Files { get; set; }

        public Models.NextOfKin User1 { get; set; }

        public Models.Perished Perished { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            string fileName = string.Empty;
            if (UploadedDeathcert != null)
            {
                Random rnd = new();
                fileName = "deathcert-" + rnd.Next(0, 100000) + "-" + UploadedDeathcert.FileName;
                var file = "./wwwroot/deathcert/" + fileName;

                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await UploadedDeathcert.CopyToAsync(fileStream);
                }

                Files.UploadedFile = fileName;
                Files.DateOfUpload = DateTime.Now;
                // Files.PerishedId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                //_context.Add(Files);

                //User1 = _context.Users.Where(x => x.LoginId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
                //if (User1 == null)
                //{
                //    User1 = new Models.User();
                //    User1.Deathcert = true;
                //    User1.LoginId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //    _context.Add(User1);
                //}
                //else
                //{
                //    User1.Deathcert = true;
                //    _context.Update(User1);
                //}

                // await _context.SaveChangesAsync();
            }

            

            return RedirectToPage("./Portal");
        }
    }
}
