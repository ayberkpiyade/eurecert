using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eurecert.Models
{
    public class Institution
    {
        public int Id { get; set; }
        [StringLength(200)]
        [Display(Name ="İşlev Adı")]
        public string FunctionName { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Informed { get; set; }
        public string SalesRepresentative { get; set; }
        public string PreBidInformation { get; set; }
        public string BidFile { get; set; }
        public string ReturnBid { get; set; }
        public string AdvencePayment { get; set; }
        public string TotalReceivable { get; set; }
        public Boolean ServicesProvided { get; set; }
        public string InstitutionRequests { get; set; }
        public int NumberOfVisits { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
