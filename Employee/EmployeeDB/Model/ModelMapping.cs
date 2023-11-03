using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB.Model
{
    public class ModelMapping
    {
        public Employee LoadEmployee(EmployeeDB.Employee emp1)
        {
            return new Employee
            {
                ID = emp1.ID,
                firstName = emp1.firstName,
                lastName = emp1.lastName,
                occupation = emp1.occupation,
                email = emp1.email,
                department_id = emp1.department_id,
                phoneNumber = emp1.phoneNumber,
                address = emp1.address
            };
        }
    }
}
