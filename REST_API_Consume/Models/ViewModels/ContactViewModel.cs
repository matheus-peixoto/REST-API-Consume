using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Consume.Models.ViewModels
{
    public class ContactViewModel
    {
        public Contact Contact { get; set; }
        public List<Deal> Deals { get; set; }
    }
}
