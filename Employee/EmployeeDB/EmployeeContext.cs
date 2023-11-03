using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB
{
    public class EmployeeContext
    {
        EmployeeDBEntities _Ctx;

        public EmployeeContext()
        {
            _Ctx = new EmployeeDBEntities();
        }

        public EmployeeDBEntities Context
        {
            get
            {
                return this._Ctx;
            }
        }

        public void Dispose()
        {
            if (_Ctx != null)
                _Ctx.Dispose();
        }
    }
}
