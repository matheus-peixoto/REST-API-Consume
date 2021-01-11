using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Consume.Models
{
    public class Phone
    {
        public string PhoneNumber { get; set; }
        public int TypeId { get; set; }
        public int CountryId { get; set; }
    }
}
