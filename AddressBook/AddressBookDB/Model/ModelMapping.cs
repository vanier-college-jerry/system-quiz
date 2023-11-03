using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDB.Model
{
    public class ModelMapping
    {
        public Address2 LoadAddress(AddressBookDB.Address addr1)
        {
            return new Address2
            {
                ID = addr1.ID,
                FirstName = addr1.FirstName,
                LastName = addr1.LastName,
                Type = addr1.Type,
                ImageLink = addr1.ImageLink,
                Address1 = addr1.Address1
            };
        }
    }
}
