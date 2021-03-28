using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HowdyNeighbor.Models
{
    public class SearchList
    {
        public int ID { get; set; }
        public string OwnerID { get; set; }
        public string Address { get; set; }
        public string SchoolImportance { get; set; }
        public string CrimeImportance { get; set; }
        public string TrafficImportance { get; set; }
        public string AgeImportance { get; set; }
        public string PointsOfInterestImportance { get; set; }
        public string CostOfLivingImportance { get; set; }
        public string InternetProvidersImportance { get; set; }
    }
}
