using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Consume.Models.ViewModels
{
    public class DealViewModel
    {
        public List<Contact> Contacts { get; set; }
        public Deal Deal { get; set; }
        public List<Task> DealTasks { get; set; }
    }
}
