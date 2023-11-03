using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDB
{
    public class AddressBookContext
    {
        AddressBookDBEntities _Ctx;

        public AddressBookContext()
        {
            _Ctx = new AddressBookDBEntities();
        }

        public AddressBookDBEntities Context
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
