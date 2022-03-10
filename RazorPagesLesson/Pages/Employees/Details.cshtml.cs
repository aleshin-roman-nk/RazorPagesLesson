using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLesson.Model;
using RazorPagesLesson.Services;

namespace RazorPagesLesson.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRepository _r;

        public DetailsModel(IEmployeeRepository r)
        {
            _r = r;
        }

        public Employee Employee { get; private set; }

        public IActionResult OnGet(int id)
        {
            Employee = _r.GetEmployee(id);

            if (Employee == null)
                return RedirectToPage("/NotFound");

            return Page();
        }
    }
}
