using RazorPagesLesson.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesLesson.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;

        public MockEmployeeRepository()
        {
            _employees = new List<Employee>
            {
                new Employee{ Id = 1, Name ="Roman", Department = Dept.IT, PhotoPath = "1.png", Email = "rome@mail.ru"},
                new Employee{ Id = 2, Name ="Paha", Department = Dept.HR, PhotoPath = "2.png", Email = "pahas@mail.ru"},
                new Employee{ Id = 3, Name ="anna", Department = Dept.Payroll, PhotoPath = "3.png", Email = "anna@mail.ru"},
                new Employee{ Id = 4, Name ="mama", Department = Dept.Payroll, PhotoPath = "4.png", Email = "mama@mail.ru"},
                new Employee{ Id = 5, Name ="papa", Department = Dept.HR, PhotoPath = "5.png", Email = "papa@mail.ru"},
                new Employee{ Id = 6, Name ="vital", Department = Dept.IT, PhotoPath = "6.png", Email = "vitla@mail.ru"},
                new Employee{ Id = 7, Name ="daria", Department = Dept.HR, PhotoPath = "7.png", Email = "daha@mail.ru"}
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(x=>x.Id == id);
        }

        public Employee Update(Employee employee)
        {
            Employee employeeToUpdate = _employees.FirstOrDefault(x=>x.Id == employee.Id);

            if (employeeToUpdate != null)
            {
                employeeToUpdate.Name = employee.Name;
                employeeToUpdate.Email = employee.Email;
                employeeToUpdate.PhotoPath = employee.PhotoPath;
                employeeToUpdate.Department = employee.Department;
            }

            return employeeToUpdate;
        }
    }
}
