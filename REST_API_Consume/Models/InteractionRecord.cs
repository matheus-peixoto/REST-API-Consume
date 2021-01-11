using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Consume.Models
{
    public class InteractionRecord
    {
        public int Id { get; set; }
        public int ContactId { get; set; }

        [Display(Name = "Message")]
        public string Content { get; set; }
    }
}
