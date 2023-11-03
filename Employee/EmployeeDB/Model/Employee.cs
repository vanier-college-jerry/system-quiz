using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB.Model
{
    public class Employee
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string occupation { get; set; }
        public int department_id { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
    }
}
