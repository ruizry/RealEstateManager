using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateManager.Models
{
    public class Property
    {
        public int ID { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string ContactNum { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<Listing> Listings { get; set; }
    }
}