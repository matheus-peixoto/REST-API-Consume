using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Consume.Models
{
    public class Task
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int DealId { get; set; }

        [Display(Name = "Content")]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }
        public bool Finishable { get; set; }
    }
}
