using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Consume.Models
{
    public class Contact
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Neighborhood { get; set; }
        public int? ZipCode { get; set; }
        public int? OriginId { get; set; }
        public int? CompanyId { get; set; }
        public string StreetAddressNumber { get; set; }
        public int? TypeId { get; set; }
        public List<Phone> Phones { get; set; }

        public Contact()
        {
            Phones = new List<Phone>();
            ZipCode = 1;
            OriginId = 1;
            CompanyId = null;
            StreetAddressNumber = "XXX";
            TypeId = 0;
        }
    }
}
