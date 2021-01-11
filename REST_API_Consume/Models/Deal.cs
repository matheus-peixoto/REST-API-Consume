using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Consume.Models
{
    public class Deal
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Amount { get; set; }
        public int StageId { get; }
        public int ContactId { get; set; }

        public Deal()
        {
            StageId = 0;
        }
    }
}
