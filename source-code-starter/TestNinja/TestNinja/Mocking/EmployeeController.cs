using System;
using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        private readonly IRepositorioEmployee _repositorioEmployee;

        public EmployeeController(IRepositorioEmployee repositorioEmployee)
        {
            _repositorioEmployee = repositorioEmployee;
        }

        public ActionResult DeleteEmployee(int id)
        {
            _repositorioEmployee.DeleteEmployee(id);
            
            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }
 
    public class RedirectResult : ActionResult { }
    
    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }

    public interface IRepositorioEmployee
    {
        bool DeleteEmployee(int id);
    }

    public class RepositorioEmployee : IRepositorioEmployee
    {
        private EmployeeContext _db;

        public RepositorioEmployee()
        {
            _db = new EmployeeContext();
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                var employee = _db.Employees.Find(id);

                if (employee == null) return true;

                _db.Employees.Remove(employee);
                _db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}