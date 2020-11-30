using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Entities
{
    public class UserInformations:BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Nip { get; set; }
    }
}
