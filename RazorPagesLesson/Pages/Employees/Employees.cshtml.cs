using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLesson.Model;
using RazorPagesLesson.Services;

namespace RazorPagesLesson.Pages.Employees
{
    public class EmployeesModel : PageModel
    {
        private readonly IEmployeeRepository _db;

        public EmployeesModel(IEmployeeRepository db)
        {
            _db = db;
        }

        public IEnumerable<Employee> Employees { get; set; }

        public void OnGet()
        {
            Employees = _db.GetAllEmployees();
        }
    }
}
