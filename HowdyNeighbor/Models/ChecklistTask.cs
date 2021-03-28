using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HowdyNeighbor.Models
{
    public class ChecklistTask
    {
        public int ID { get; set; }
        public string OwnerID { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
