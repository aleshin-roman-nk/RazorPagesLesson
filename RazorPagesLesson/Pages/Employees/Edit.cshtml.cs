using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLesson.Model;
using RazorPagesLesson.Services;
using RazorPagesLesson.Tools;

namespace RazorPagesLesson.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository _r;
        private readonly IWebHostEnvironment _webHostEnvi;

        public EditModel(IEmployeeRepository r, IWebHostEnvironment webHostEnvi)
        {
            LoggerObj.Write($"constructor :: EditModel /{DateTime.Now.ToLongTimeString()}/");
            _r = r;
            _webHostEnvi = webHostEnvi;
        }
        public IActionResult OnGet(int id)
        {
            LoggerObj.Write("OnGet()");
            LoggerObj.Write($"id={id}");

            M_Employee = _r.GetEmployee(id);

            if (M_Employee == null)
                return RedirectToPage("/NotFound");

            return Page();
        }

        [BindProperty]
        public Employee M_Employee { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }

        public IActionResult OnPost()
        {
            LoggerObj.Write("OnPost()");
            LoggerObj.Write("m_employee=");
            LoggerObj.Write(M_Employee);

            if (Photo != null)
            {
                if(M_Employee.PhotoPath != null)
                {
                    string filePath = Path.Combine(_webHostEnvi.WebRootPath, M_Employee.PhotoPath);
                    System.IO.File.Delete(filePath);
                }
                M_Employee.PhotoPath = ProcessUploadedFile();
            }

            M_Employee = _r.Update(M_Employee);
            return RedirectToPage("Employees");
        }

        private string? ProcessUploadedFile()
        {
            string? uniqFileName = null;

            if(Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvi.WebRootPath, "images");
                uniqFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqFileName);

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                }
            }

            return uniqFileName;
        }
    }
}
