using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB.Interface
{
    public interface IEmployeeRepository : IDisposable
    {
        IQueryable<Employee> GetEmployee();
        bool IsEmployeeExist(string firstName, string lastName, string email, string occupation, int department_id, string phoneNumber, string address);
        bool AddEmployee(string firstName, string lastName, string email, string occupation, int department_id, string phoneNumber, string address);
    }
}
