using AddressBookDB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDB
{
    public class AddressBookRepository : IAddressBookRepository
    {
        AddressBookContext _Ctx;

        public AddressBookRepository(AddressBookContext Context)
        {
            _Ctx = Context;
            _Ctx.Context.Configuration.LazyLoadingEnabled = false;
            _Ctx.Context.Configuration.ProxyCreationEnabled = false;
        }

        // Start Method Development
        public IQueryable<Address> GetAddress()
        {
            return _Ctx.Context.Addresses;
        }

        public bool AddAddress(string FirstName, string LastName, string Type, string ImageLink, string Address1)
        {
            return true;
        }
        // End Method Development

        public void Dispose()
        {
            if (_Ctx != null)
                _Ctx.Dispose();
        }

        public bool IsAddressExist(string FirstName, string LastName, string Type, string ImageLink, string Address1)
        {
            throw new NotImplementedException();
        }
    }
}
