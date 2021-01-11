using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Consume.Models.ViewModels
{
    public class TaskViewModel
    {
        public int ContactId { get; set; }
        public int dealId { get; set; }
        public Task Task { get; set; }
    }
}
