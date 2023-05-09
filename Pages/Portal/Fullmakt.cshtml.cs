using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DigitalAfterlife2._0.Pages.Portal
{
    public class FullmaktModel : PageModel
    {
        //private readonly Data.ApplicationDbContext _context;

        //public FullmaktModel(Data.ApplicationDbContext context)
        //{
        //    _context = context;
        //}


        [BindProperty]
        public IFormFile UploadedFullmakt { get; set; }

        [BindProperty]
        public Models.File Files { get; set; }

        public Models.NextOfKin User1 { get; set; }

        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync()
        {
            string fileName = string.Empty;
            if (UploadedFullmakt != null)
            {
                Random rnd = new();
                fileName = "fullmakt-" + rnd.Next(0, 100000) + "-" + UploadedFullmakt.FileName;
                var file = "./wwwroot/fullmakt/" + fileName;

                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await UploadedFullmakt.CopyToAsync(fileStream);
                }

                Files.UploadedFile = fileName;
                Files.DateOfUpload = DateTime.Now;
                //Files.PerishedId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                //_context.Add(Files);
               
                //User1 = _context.Users.Where(x => x.LoginId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
                //if (User1 == null)
                //{
                //    User1 = new Models.User();
                //    User1.Fullmakt = true;
                //    User1.LoginId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //    _context.Add(User1);
                //}
                //else
                //{
                //    User1.Fullmakt = true;
                //    _context.Update(User1);
                //}

                //await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Portal");
        }
    }
}
