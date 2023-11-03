using EmployeeDB.Interface;
using EmployeeDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeContext _Ctx;

        public EmployeeRepository(EmployeeContext Context)
        {
            _Ctx = Context;
            _Ctx.Context.Configuration.LazyLoadingEnabled = false;
            _Ctx.Context.Configuration.ProxyCreationEnabled = false;
        }

        // Start Method Development
        public IQueryable<Employee> GetEmployee()
        {
            return _Ctx.Context.Employees;
        }

        public bool AddEmployee(string firstName, string lastName, string email, string occupation, int department_id, string phoneNumber, string address)
        {
            return true;
        }
        // End Method Development

        public void Dispose()
        {
            if (_Ctx != null)
                _Ctx.Dispose();
        }

        public bool IsEmployeeExist(string firstName, string lastName, string email, string occupation, int department_id, string phoneNumber, string address)
        {
            throw new NotImplementedException();
        }
    }
}
