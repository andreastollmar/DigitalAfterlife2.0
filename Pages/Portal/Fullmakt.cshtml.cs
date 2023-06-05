using DigitalAfterlife2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DigitalAfterlife2._0.Pages.Portal
{
    public class FullmaktModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public FullmaktModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }        

        [BindProperty]
        public IFormFile UploadedFullmakt { get; set; }

        [BindProperty]
        public Models.File Files { get; set; }
        public List<Models.File> FilesList { get; set; }

        public List<Models.Perished> PerishedList { get; set; }
        public Models.NextOfKin NextOfKin { get; set; }
        [BindProperty]
        public Models.Perished Perished { get; set; }
        public Perished PerishedToSave { get; set; }

        public async Task<IActionResult> OnGetAsync(int deleteId)
        {
            FilesList = new List<Models.File>();
            NextOfKin = _context.NextOfKin.Where(x => x.LoginId == User.FindFirstValue(ClaimTypes.NameIdentifier)).FirstOrDefault();
            PerishedList = _context.Perished.Where(x => x.NextOfKinId == NextOfKin.Id).ToList();
            foreach (var item in PerishedList)
            {
                var file = _context.File.Where(x => x.PerishedId == item.Id).ToList();
                if (file != null)
                {
                    FilesList.AddRange(file);
                }
            }

            ViewData["PerishedId"] = new SelectList(_context.Perished.Where(x => x.NextOfKinId == NextOfKin.Id && x.Fullmakt != true), "Id", "FirstName");

            if (deleteId != 0)
            {
                var file = _context.File.Where(x => x.Id == deleteId).FirstOrDefault();
                Perished = _context.Perished.Where(x => x.Id == file.PerishedId).FirstOrDefault();

                if (file != null)
                {
                    if (System.IO.File.Exists("wwwroot/fullmakt/" + file.UploadedFile))
                    {
                        System.IO.File.Delete("wwwroot/fullmakt/" + file.UploadedFile);
                    }
                    _context.File.Remove(file);
                    Perished.Fullmakt = false;
                    _context.Update(Perished);
                    await _context.SaveChangesAsync();

                    return RedirectToPage("Fullmakt");
                }
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            PerishedToSave = _context.Perished.Where(x => x.Id == Perished.NextOfKinId).FirstOrDefault();
            string fileName = string.Empty;
            if (PerishedToSave != null && PerishedToSave.Fullmakt != true && Files != null)
            {
                Random rnd = new();
                fileName = "fullmakt-" + rnd.Next(0, 100000) + "-" + PerishedToSave.FirstName + PerishedToSave.LastName + "-" + UploadedFullmakt.FileName;
                var file = "./wwwroot/fullmakt/" + fileName;

                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await UploadedFullmakt.CopyToAsync(fileStream);
                }

                Files.UploadedFile = fileName;
                Files.DateOfUpload = DateTime.Now;
                Files.PerishedId = Perished.Id;
                Files.Perished = PerishedToSave;
                _context.Add(Files);


                PerishedToSave.Fullmakt = true;
                _context.Update(PerishedToSave);

                await _context.SaveChangesAsync();
            }
            else
            {
                return Page();
            }

            return RedirectToPage("./Portal");
        }
    }
}
